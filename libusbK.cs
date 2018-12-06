#region Copyright (c) Travis Robinson

// Copyright (c) 2012 Travis Robinson <libusbdotnet@gmail.com>
// All rights reserved.
//
// C# libusbK Bindings
// Auto-generated on: 04.28.2011
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
//
//     * Redistributions of source code must retain the above copyright
//       notice, this list of conditions and the following disclaimer.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS
// IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED
// TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
// PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL TRAVIS LEE ROBINSON
// BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR
// CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF
// SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
// CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF
// THE POSSIBILITY OF SUCH DAMAGE.

#endregion Copyright (c) Travis Robinson

using System;
using System.Runtime.InteropServices;

namespace libusbK
{
    public static class AllKOptions
    {
        public static string LIBUSBK_FULLPATH_TO_ALTERNATE_DLL;
    }

    public static class AllKConstants
    {
        public const int KLST_STRING_MAX_LEN = 256;
        public const string LIBUSBK_DLL = "libusbK.dll";
    }

    public struct KLST_HANDLE
    {
        public IntPtr Pointer { get; }

        public KLST_HANDLE(IntPtr Handle)
        {
            Pointer = Handle;
        }
    }

    public struct KUSB_HANDLE
    {
        public IntPtr Pointer { get; }
    }

    internal static class AllKFunctions
    {
        [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate void LibK_Context_FreeDelegate();

        [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate bool LibK_Context_InitDelegate(IntPtr Heap, IntPtr Reserved);

        [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate bool
            LibK_CopyDriverAPIDelegate([Out] out KUSB_DRIVER_API DriverAPI, [In] KUSB_HANDLE UsbHandle);

        [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate IntPtr LibK_GetContextDelegate([In] IntPtr Handle, KLIB_HANDLE_TYPE HandleType);

        [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate IntPtr LibK_GetDefaultContextDelegate(KLIB_HANDLE_TYPE HandleType);

        [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate bool LibK_GetProcAddressDelegate(IntPtr ProcAddress, int DriverID, int FunctionID);

        [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate bool LibK_LoadDriverAPIDelegate([Out] out KUSB_DRIVER_API DriverAPI, int DriverID);

        [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate bool LibK_SetContextDelegate([In] IntPtr Handle, KLIB_HANDLE_TYPE HandleType,
            IntPtr ContextValue);

        [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate bool LibK_SetDefaultContextDelegate(KLIB_HANDLE_TYPE HandleType, IntPtr ContextValue);

        [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate bool LstK_CountDelegate([In] KLST_HANDLE DeviceList, ref int Count);

        [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate bool LstK_CurrentDelegate([In] KLST_HANDLE DeviceList,
            [Out] out KLST_DEVINFO_HANDLE DeviceInfo);

        [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate bool LstK_FindByVidPidDelegate([In] KLST_HANDLE DeviceList, int Vid, int Pid,
            [Out] out KLST_DEVINFO_HANDLE DeviceInfo);

        [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate bool LstK_FreeDelegate([In] KLST_HANDLE DeviceList);

        [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate bool LstK_InitDelegate([Out] out KLST_HANDLE DeviceList, KLST_FLAG Flags);

        [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate bool LstK_InitExDelegate([Out] out KLST_HANDLE DeviceList, KLST_FLAG Flags,
            [In] ref KLST_PATTERN_MATCH PatternMatch);

        [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate bool LstK_MoveNextDelegate([In] KLST_HANDLE DeviceList,
            [Out] out KLST_DEVINFO_HANDLE DeviceInfo);

        [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
        public delegate void LstK_MoveResetDelegate([In] KLST_HANDLE DeviceList);

        public static LibK_Context_FreeDelegate LibK_Context_Free;
        public static LibK_Context_InitDelegate LibK_Context_Init;
        public static LibK_CopyDriverAPIDelegate LibK_CopyDriverAPI;
        public static LibK_GetContextDelegate LibK_GetContext;
        public static LibK_GetDefaultContextDelegate LibK_GetDefaultContext;
        public static LibK_GetProcAddressDelegate LibK_GetProcAddress;
        public static LibK_LoadDriverAPIDelegate LibK_LoadDriverAPI;
        public static LibK_SetContextDelegate LibK_SetContext;
        public static LibK_SetDefaultContextDelegate LibK_SetDefaultContext;
        public static LstK_CountDelegate LstK_Count;
        public static LstK_CurrentDelegate LstK_Current;
        public static LstK_FindByVidPidDelegate LstK_FindByVidPid;
        public static LstK_FreeDelegate LstK_Free;
        public static LstK_InitDelegate LstK_Init;
        public static LstK_InitExDelegate LstK_InitEx;
        public static LstK_MoveNextDelegate LstK_MoveNext;
        public static LstK_MoveResetDelegate LstK_MoveReset;

        private static readonly IntPtr mModuleLibusbK;

        static AllKFunctions()
        {
            if (string.IsNullOrEmpty(AllKOptions.LIBUSBK_FULLPATH_TO_ALTERNATE_DLL))
                mModuleLibusbK = LoadLibraryEx(AllKConstants.LIBUSBK_DLL, IntPtr.Zero, LoadLibraryFlags.NONE);
            else
                mModuleLibusbK = LoadLibraryEx(AllKOptions.LIBUSBK_FULLPATH_TO_ALTERNATE_DLL, IntPtr.Zero,
                    LoadLibraryFlags.LOAD_WITH_ALTERED_SEARCH_PATH);
            if (mModuleLibusbK == IntPtr.Zero)
                throw new DllNotFoundException(
                    "libusbK.dll not found.  Please install drivers/applications and retry.");
            LoadDynamicFunctions();
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        private static void LoadDynamicFunctions()
        {
            LibK_GetContext =
                (LibK_GetContextDelegate)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(mModuleLibusbK, "LibK_GetContext"), typeof(LibK_GetContextDelegate));
            LibK_SetContext =
                (LibK_SetContextDelegate)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(mModuleLibusbK, "LibK_SetContext"), typeof(LibK_SetContextDelegate));
            LibK_LoadDriverAPI = (LibK_LoadDriverAPIDelegate)Marshal.GetDelegateForFunctionPointer(
                GetProcAddress(mModuleLibusbK, "LibK_LoadDriverAPI"), typeof(LibK_LoadDriverAPIDelegate));
            LibK_CopyDriverAPI = (LibK_CopyDriverAPIDelegate)Marshal.GetDelegateForFunctionPointer(
                GetProcAddress(mModuleLibusbK, "LibK_CopyDriverAPI"), typeof(LibK_CopyDriverAPIDelegate));
            LibK_GetProcAddress = (LibK_GetProcAddressDelegate)Marshal.GetDelegateForFunctionPointer(
                GetProcAddress(mModuleLibusbK, "LibK_GetProcAddress"), typeof(LibK_GetProcAddressDelegate));
            LibK_SetDefaultContext = (LibK_SetDefaultContextDelegate)Marshal.GetDelegateForFunctionPointer(
                GetProcAddress(mModuleLibusbK, "LibK_SetDefaultContext"), typeof(LibK_SetDefaultContextDelegate));
            LibK_GetDefaultContext = (LibK_GetDefaultContextDelegate)Marshal.GetDelegateForFunctionPointer(
                GetProcAddress(mModuleLibusbK, "LibK_GetDefaultContext"), typeof(LibK_GetDefaultContextDelegate));
            LibK_Context_Init = (LibK_Context_InitDelegate)Marshal.GetDelegateForFunctionPointer(
                GetProcAddress(mModuleLibusbK, "LibK_Context_Init"), typeof(LibK_Context_InitDelegate));
            LibK_Context_Free = (LibK_Context_FreeDelegate)Marshal.GetDelegateForFunctionPointer(
                GetProcAddress(mModuleLibusbK, "LibK_Context_Free"), typeof(LibK_Context_FreeDelegate));
            LstK_Init = (LstK_InitDelegate)Marshal.GetDelegateForFunctionPointer(
                GetProcAddress(mModuleLibusbK, "LstK_Init"), typeof(LstK_InitDelegate));
            LstK_InitEx =
                (LstK_InitExDelegate)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(mModuleLibusbK, "LstK_InitEx"), typeof(LstK_InitExDelegate));
            LstK_Free = (LstK_FreeDelegate)Marshal.GetDelegateForFunctionPointer(
                GetProcAddress(mModuleLibusbK, "LstK_Free"), typeof(LstK_FreeDelegate));
            LstK_Current =
                (LstK_CurrentDelegate)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(mModuleLibusbK, "LstK_Current"), typeof(LstK_CurrentDelegate));
            LstK_MoveNext =
                (LstK_MoveNextDelegate)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(mModuleLibusbK, "LstK_MoveNext"), typeof(LstK_MoveNextDelegate));
            LstK_MoveReset =
                (LstK_MoveResetDelegate)Marshal.GetDelegateForFunctionPointer(
                    GetProcAddress(mModuleLibusbK, "LstK_MoveReset"), typeof(LstK_MoveResetDelegate));
            LstK_FindByVidPid = (LstK_FindByVidPidDelegate)Marshal.GetDelegateForFunctionPointer(
                GetProcAddress(mModuleLibusbK, "LstK_FindByVidPid"), typeof(LstK_FindByVidPidDelegate));
            LstK_Count =
                (LstK_CountDelegate)Marshal.GetDelegateForFunctionPointer(GetProcAddress(mModuleLibusbK, "LstK_Count"),
                    typeof(LstK_CountDelegate));
        }

        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibraryEx(string lpFileName, IntPtr hReservedNull, LoadLibraryFlags dwFlags);

        [Flags]
        private enum LoadLibraryFlags
        {
            NONE = 0,
            LOAD_WITH_ALTERED_SEARCH_PATH = 8
        }
    }

    public enum USBD_PIPE_TYPE
    {
    }

    public enum KLIB_HANDLE_TYPE
    {
    }

    [Flags]
    public enum KLST_SYNC_FLAG
    {
    }

    [Flags]
    public enum KLST_FLAG
    {
        NONE = 0
    }

    public enum KUSB_PROPERTY
    {
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct WINUSB_PIPE_INFORMATION
    {
        public USBD_PIPE_TYPE PipeType;
        public byte PipeId;
        public ushort MaximumPacketSize;
        public byte Interval;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct WINUSB_SETUP_PACKET
    {
        public byte RequestType;
        public byte Request;
        public ushort Value;
        public ushort Index;
        public ushort Length;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct KLST_DEV_COMMON_INFO
    {
        public int Vid;
        public int Pid;
        public int MI;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = AllKConstants.KLST_STRING_MAX_LEN)]
        public string InstanceID;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct KLST_DEVINFO_HANDLE
    {
        public IntPtr Pointer { get; }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private struct KLST_DEVINFO_MAP
        {
            private readonly KLST_DEV_COMMON_INFO Common;
            private readonly int DriverID;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = AllKConstants.KLST_STRING_MAX_LEN)]
            private readonly string DeviceInterfaceGUID;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = AllKConstants.KLST_STRING_MAX_LEN)]
            private readonly string DeviceID;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = AllKConstants.KLST_STRING_MAX_LEN)]
            private readonly string ClassGUID;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = AllKConstants.KLST_STRING_MAX_LEN)]
            private readonly string Mfg;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = AllKConstants.KLST_STRING_MAX_LEN)]
            private readonly string DeviceDesc;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = AllKConstants.KLST_STRING_MAX_LEN)]
            private readonly string Service;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = AllKConstants.KLST_STRING_MAX_LEN)]
            private readonly string SymbolicLink;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = AllKConstants.KLST_STRING_MAX_LEN)]
            private readonly string DevicePath;

            private readonly int LUsb0FilterIndex;
            private readonly bool Connected;
            private readonly KLST_SYNC_FLAG SyncFlags;
            private readonly int BusNumber;
            private readonly int DeviceAddress;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = AllKConstants.KLST_STRING_MAX_LEN)]
            private readonly string SerialNumber;
        }

        private static readonly int ofsCommon = Marshal.OffsetOf(typeof(KLST_DEVINFO_MAP), "Common").ToInt32();
        private static readonly int ofsDriverID = Marshal.OffsetOf(typeof(KLST_DEVINFO_MAP), "DriverID").ToInt32();

        private static readonly int ofsDeviceInterfaceGUID =
            Marshal.OffsetOf(typeof(KLST_DEVINFO_MAP), "DeviceInterfaceGUID").ToInt32();

        private static readonly int ofsDeviceID = Marshal.OffsetOf(typeof(KLST_DEVINFO_MAP), "DeviceID").ToInt32();
        private static readonly int ofsClassGUID = Marshal.OffsetOf(typeof(KLST_DEVINFO_MAP), "ClassGUID").ToInt32();
        private static readonly int ofsMfg = Marshal.OffsetOf(typeof(KLST_DEVINFO_MAP), "Mfg").ToInt32();
        private static readonly int ofsDeviceDesc = Marshal.OffsetOf(typeof(KLST_DEVINFO_MAP), "DeviceDesc").ToInt32();
        private static readonly int ofsService = Marshal.OffsetOf(typeof(KLST_DEVINFO_MAP), "Service").ToInt32();

        private static readonly int ofsSymbolicLink =
            Marshal.OffsetOf(typeof(KLST_DEVINFO_MAP), "SymbolicLink").ToInt32();

        private static readonly int ofsDevicePath = Marshal.OffsetOf(typeof(KLST_DEVINFO_MAP), "DevicePath").ToInt32();

        private static readonly int ofsLUsb0FilterIndex =
            Marshal.OffsetOf(typeof(KLST_DEVINFO_MAP), "LUsb0FilterIndex").ToInt32();

        private static readonly int ofsConnected = Marshal.OffsetOf(typeof(KLST_DEVINFO_MAP), "Connected").ToInt32();
        private static readonly int ofsSyncFlags = Marshal.OffsetOf(typeof(KLST_DEVINFO_MAP), "SyncFlags").ToInt32();
        private static readonly int ofsBusNumber = Marshal.OffsetOf(typeof(KLST_DEVINFO_MAP), "BusNumber").ToInt32();

        private static readonly int ofsDeviceAddress =
            Marshal.OffsetOf(typeof(KLST_DEVINFO_MAP), "DeviceAddress").ToInt32();

        private static readonly int ofsSerialNumber =
            Marshal.OffsetOf(typeof(KLST_DEVINFO_MAP), "SerialNumber").ToInt32();

        public int DriverID => Marshal.ReadInt32(Pointer, ofsDriverID);
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Size = 1024)]
    public struct KLST_PATTERN_MATCH
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = AllKConstants.KLST_STRING_MAX_LEN)]
        public string DeviceID;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = AllKConstants.KLST_STRING_MAX_LEN)]
        public string DeviceInterfaceGUID;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = AllKConstants.KLST_STRING_MAX_LEN)]
        public string ClassGUID;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct USB_INTERFACE_DESCRIPTOR
    {
        public byte bLength;
        public byte bDescriptorType;
        public byte bInterfaceNumber;
        public byte bAlternateSetting;
        public byte bNumEndpoints;
        public byte bInterfaceClass;
        public byte bInterfaceSubClass;
        public byte bInterfaceProtocol;
        public byte iInterface;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct KUSB_DRIVER_API_INFO
    {
        public int DriverID;
        public int FunctionCount;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Size = 512)]
    public struct KUSB_DRIVER_API
    {
        public KUSB_DRIVER_API_INFO Info;

        [MarshalAs(UnmanagedType.FunctionPtr)] public KUSB_InitDelegate Init;
        [MarshalAs(UnmanagedType.FunctionPtr)] public KUSB_FreeDelegate Free;
        [MarshalAs(UnmanagedType.FunctionPtr)] public KUSB_ClaimInterfaceDelegate ClaimInterface;
        [MarshalAs(UnmanagedType.FunctionPtr)] public KUSB_ReleaseInterfaceDelegate ReleaseInterface;
        [MarshalAs(UnmanagedType.FunctionPtr)] public KUSB_SetAltInterfaceDelegate SetAltInterface;
        [MarshalAs(UnmanagedType.FunctionPtr)] public KUSB_GetAltInterfaceDelegate GetAltInterface;
        [MarshalAs(UnmanagedType.FunctionPtr)] public KUSB_GetDescriptorDelegate GetDescriptor;
        [MarshalAs(UnmanagedType.FunctionPtr)] public KUSB_ControlTransferDelegate ControlTransfer;
        [MarshalAs(UnmanagedType.FunctionPtr)] public KUSB_SetPowerPolicyDelegate SetPowerPolicy;
        [MarshalAs(UnmanagedType.FunctionPtr)] public KUSB_GetPowerPolicyDelegate GetPowerPolicy;
        [MarshalAs(UnmanagedType.FunctionPtr)] public KUSB_SetConfigurationDelegate SetConfiguration;
        [MarshalAs(UnmanagedType.FunctionPtr)] public KUSB_GetConfigurationDelegate GetConfiguration;
        [MarshalAs(UnmanagedType.FunctionPtr)] public KUSB_ResetDeviceDelegate ResetDevice;
        [MarshalAs(UnmanagedType.FunctionPtr)] public KUSB_InitializeDelegate Initialize;
        [MarshalAs(UnmanagedType.FunctionPtr)] public KUSB_SelectInterfaceDelegate SelectInterface;
        [MarshalAs(UnmanagedType.FunctionPtr)] public KUSB_GetAssociatedInterfaceDelegate GetAssociatedInterface;
        [MarshalAs(UnmanagedType.FunctionPtr)] public KUSB_CloneDelegate Clone;
        [MarshalAs(UnmanagedType.FunctionPtr)] public KUSB_QueryInterfaceSettingsDelegate QueryInterfaceSettings;
        [MarshalAs(UnmanagedType.FunctionPtr)] public KUSB_QueryDeviceInformationDelegate QueryDeviceInformation;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public KUSB_SetCurrentAlternateSettingDelegate SetCurrentAlternateSetting;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public KUSB_GetCurrentAlternateSettingDelegate GetCurrentAlternateSetting;

        [MarshalAs(UnmanagedType.FunctionPtr)] public KUSB_QueryPipeDelegate QueryPipe;
        [MarshalAs(UnmanagedType.FunctionPtr)] public KUSB_SetPipePolicyDelegate SetPipePolicy;
        [MarshalAs(UnmanagedType.FunctionPtr)] public KUSB_GetPipePolicyDelegate GetPipePolicy;
        [MarshalAs(UnmanagedType.FunctionPtr)] public KUSB_ReadPipeDelegate ReadPipe;
        [MarshalAs(UnmanagedType.FunctionPtr)] public KUSB_WritePipeDelegate WritePipe;
        [MarshalAs(UnmanagedType.FunctionPtr)] public KUSB_ResetPipeDelegate ResetPipe;
        [MarshalAs(UnmanagedType.FunctionPtr)] public KUSB_AbortPipeDelegate AbortPipe;
        [MarshalAs(UnmanagedType.FunctionPtr)] public KUSB_FlushPipeDelegate FlushPipe;
        [MarshalAs(UnmanagedType.FunctionPtr)] public KUSB_GetCurrentFrameNumberDelegate GetCurrentFrameNumber;
        [MarshalAs(UnmanagedType.FunctionPtr)] public KUSB_GetOverlappedResultDelegate GetOverlappedResult;
        [MarshalAs(UnmanagedType.FunctionPtr)] public KUSB_GetPropertyDelegate GetProperty;
    }

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_InitDelegate([Out] out KUSB_HANDLE InterfaceHandle, [In] KLST_DEVINFO_HANDLE DevInfo);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_FreeDelegate([In] KUSB_HANDLE InterfaceHandle);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool
        KUSB_ClaimInterfaceDelegate([In] KUSB_HANDLE InterfaceHandle, byte NumberOrIndex, bool IsIndex);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_ReleaseInterfaceDelegate([In] KUSB_HANDLE InterfaceHandle, byte NumberOrIndex,
        bool IsIndex);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_SetAltInterfaceDelegate([In] KUSB_HANDLE InterfaceHandle, byte NumberOrIndex,
        bool IsIndex, byte AltSettingNumber);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_GetAltInterfaceDelegate([In] KUSB_HANDLE InterfaceHandle, byte NumberOrIndex,
        bool IsIndex, out byte AltSettingNumber);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_GetDescriptorDelegate([In] KUSB_HANDLE InterfaceHandle, byte DescriptorType, byte Index,
        ushort LanguageID, IntPtr Buffer, int BufferLength, out int LengthTransferred);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_ControlTransferDelegate([In] KUSB_HANDLE InterfaceHandle, WINUSB_SETUP_PACKET SetupPacket,
        IntPtr Buffer, int BufferLength, out int LengthTransferred, IntPtr Overlapped);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_SetPowerPolicyDelegate([In] KUSB_HANDLE InterfaceHandle, int PolicyType, int ValueLength,
        IntPtr Value);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_GetPowerPolicyDelegate([In] KUSB_HANDLE InterfaceHandle, int PolicyType,
        ref int ValueLength, IntPtr Value);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_SetConfigurationDelegate([In] KUSB_HANDLE InterfaceHandle, byte ConfigurationNumber);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_GetConfigurationDelegate([In] KUSB_HANDLE InterfaceHandle, out byte ConfigurationNumber);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_ResetDeviceDelegate([In] KUSB_HANDLE InterfaceHandle);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_InitializeDelegate(IntPtr DeviceHandle, [Out] out KUSB_HANDLE InterfaceHandle);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_SelectInterfaceDelegate([In] KUSB_HANDLE InterfaceHandle, byte NumberOrIndex,
        bool IsIndex);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_GetAssociatedInterfaceDelegate([In] KUSB_HANDLE InterfaceHandle,
        byte AssociatedInterfaceIndex, [Out] out KUSB_HANDLE AssociatedInterfaceHandle);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_CloneDelegate([In] KUSB_HANDLE InterfaceHandle, [Out] out KUSB_HANDLE DstInterfaceHandle);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_QueryInterfaceSettingsDelegate([In] KUSB_HANDLE InterfaceHandle, byte AltSettingIndex,
        [Out] out USB_INTERFACE_DESCRIPTOR UsbAltInterfaceDescriptor);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_QueryDeviceInformationDelegate([In] KUSB_HANDLE InterfaceHandle, int InformationType,
        ref int BufferLength, IntPtr Buffer);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_SetCurrentAlternateSettingDelegate([In] KUSB_HANDLE InterfaceHandle,
        byte AltSettingNumber);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_GetCurrentAlternateSettingDelegate([In] KUSB_HANDLE InterfaceHandle,
        out byte AltSettingNumber);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_QueryPipeDelegate([In] KUSB_HANDLE InterfaceHandle, byte AltSettingNumber, byte PipeIndex,
        [Out] out WINUSB_PIPE_INFORMATION PipeInformation);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_SetPipePolicyDelegate([In] KUSB_HANDLE InterfaceHandle, byte PipeID, int PolicyType,
        int ValueLength, IntPtr Value);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_GetPipePolicyDelegate([In] KUSB_HANDLE InterfaceHandle, byte PipeID, int PolicyType,
        ref int ValueLength, IntPtr Value);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_ReadPipeDelegate([In] KUSB_HANDLE InterfaceHandle, byte PipeID, IntPtr Buffer,
        int BufferLength, out int LengthTransferred, IntPtr Overlapped);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_WritePipeDelegate([In] KUSB_HANDLE InterfaceHandle, byte PipeID, IntPtr Buffer,
        int BufferLength, out int LengthTransferred, IntPtr Overlapped);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_ResetPipeDelegate([In] KUSB_HANDLE InterfaceHandle, byte PipeID);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_AbortPipeDelegate([In] KUSB_HANDLE InterfaceHandle, byte PipeID);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_FlushPipeDelegate([In] KUSB_HANDLE InterfaceHandle, byte PipeID);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_GetCurrentFrameNumberDelegate([In] KUSB_HANDLE InterfaceHandle, out int FrameNumber);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_GetOverlappedResultDelegate([In] KUSB_HANDLE InterfaceHandle, IntPtr Overlapped,
        out int lpNumberOfBytesTransferred, bool bWait);

    [UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Ansi, SetLastError = true)]
    public delegate bool KUSB_GetPropertyDelegate([In] KUSB_HANDLE InterfaceHandle, KUSB_PROPERTY PropertyType,
        ref int PropertySize, IntPtr Value);

    public class LstK
    {
        protected KLST_HANDLE mHandleStruct;

        public LstK(KLST_FLAG Flags, ref KLST_PATTERN_MATCH PatternMatch)
        {
            var success = AllKFunctions.LstK_InitEx(out mHandleStruct, Flags, ref PatternMatch);

            if (!success)
                throw new Exception();
        }

        public virtual bool MoveNext(out KLST_DEVINFO_HANDLE DeviceInfo)
        {
            return AllKFunctions.LstK_MoveNext(mHandleStruct, out DeviceInfo);
        }
    }

    public class UsbK
    {
        protected KUSB_DRIVER_API driverAPI;
        protected KUSB_HANDLE mHandleStruct;

        public UsbK(KLST_DEVINFO_HANDLE DevInfo)
        {
            var success = AllKFunctions.LibK_LoadDriverAPI(out driverAPI, DevInfo.DriverID);
            if (!success)
                throw new Exception();
            success = driverAPI.Init(out mHandleStruct, DevInfo);
            if (!success)
                throw new Exception();
        }

        public virtual bool ControlTransfer(WINUSB_SETUP_PACKET SetupPacket, Array Buffer, int BufferLength,
            out int LengthTransferred, IntPtr Overlapped)
        {
            return driverAPI.ControlTransfer(mHandleStruct, SetupPacket,
                Marshal.UnsafeAddrOfPinnedArrayElement(Buffer, 0), BufferLength, out LengthTransferred, Overlapped);
        }

        public virtual bool QueryInterfaceSettings(byte AltSettingIndex,
            out USB_INTERFACE_DESCRIPTOR UsbAltInterfaceDescriptor)
        {
            return driverAPI.QueryInterfaceSettings(mHandleStruct, AltSettingIndex, out UsbAltInterfaceDescriptor);
        }

        public virtual bool QueryPipe(byte AltSettingNumber, byte PipeIndex,
            out WINUSB_PIPE_INFORMATION PipeInformation)
        {
            return driverAPI.QueryPipe(mHandleStruct, AltSettingNumber, PipeIndex, out PipeInformation);
        }

        public virtual bool ReadPipe(byte PipeID, Array Buffer, int BufferLength, out int LengthTransferred,
            IntPtr Overlapped)
        {
            return driverAPI.ReadPipe(mHandleStruct, PipeID, Marshal.UnsafeAddrOfPinnedArrayElement(Buffer, 0),
                BufferLength, out LengthTransferred, Overlapped);
        }

        public virtual bool SelectInterface(byte NumberOrIndex, bool IsIndex)
        {
            return driverAPI.SelectInterface(mHandleStruct, NumberOrIndex, IsIndex);
        }

        public virtual bool SetAltInterface(byte NumberOrIndex, bool IsIndex, byte AltSettingNumber)
        {
            return driverAPI.SetAltInterface(mHandleStruct, NumberOrIndex, IsIndex, AltSettingNumber);
        }

        public virtual bool WritePipe(byte PipeID, Array Buffer, int BufferLength, out int LengthTransferred,
            IntPtr Overlapped)
        {
            return driverAPI.WritePipe(mHandleStruct, PipeID, Marshal.UnsafeAddrOfPinnedArrayElement(Buffer, 0),
                BufferLength, out LengthTransferred, Overlapped);
        }
    }
}