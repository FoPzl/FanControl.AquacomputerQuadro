using System.Runtime.InteropServices;

namespace FanControl.AquacomputerQuadro {
    static class DataStructs {
        // 15 bytes
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Header {
            public byte IsValid; // If it's != 0

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Version;

            [MarshalAs(UnmanagedType.U4)]
            [Endian(Endianness.BigEndian)]
            public uint SerialNumber;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Hardware;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort DeviceType;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Bootloader;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort FirmwareVersion;

            public static string SerialToText(uint sn) {
                return ((sn & 0xFFFF0000L) >> 16).ToString("D5") + "-" + (sn & 0xFFFFL).ToString("D5");
            }
        }

        // 20 bytes
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Firmware {
            [MarshalAs(UnmanagedType.U4)]
            [Endian(Endianness.BigEndian)]
            public uint SystemState;

            public byte Features;

            [MarshalAs(UnmanagedType.U4)]
            [Endian(Endianness.BigEndian)]
            public uint Time;

            [MarshalAs(UnmanagedType.U4)]
            [Endian(Endianness.BigEndian)]
            public uint PowerCycles;

            [MarshalAs(UnmanagedType.U4)]
            [Endian(Endianness.BigEndian)]
            public uint RuntimeTotal;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Unknown;

            public byte Language; // ==0 english, !=0 german
        }

        // 185 bytes
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SensorData {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
            [Endian(Endianness.BigEndian)]
            public byte[] Unknown1;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Sensor1;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Sensor2;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Sensor3;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Sensor4;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Sensor5;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Unknown2;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Temperature1;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Temperature2;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Temperature3;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Temperature4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            [Endian(Endianness.BigEndian)]
            public byte[] SoftSensors;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            [Endian(Endianness.BigEndian)]
            public byte[] Unknown3;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort PowerInput12V;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Flow; // l/h

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan1OutputPower;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan1Voltage;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan1Current; // amps

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan1Power; // watts

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan1Speed; // rpm

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan1PulseWidth; // ms

            public byte Fan1StartBoost;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan2OutputPower;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan2Voltage;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan2Current; // amps

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan2Power; // watts

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan2Speed; // rpm

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan2PulseWidth; // ms

            public byte Fan2StartBoost;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan3OutputPower;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan3Voltage;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan3Current; // amps

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan3Power; // watts

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan3Speed; // rpm

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan3PulseWidth; // ms

            public byte Fan3StartBoost;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan4OutputPower;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan4Voltage;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan4Current; // amps

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan4Power; // watts

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan4Speed; // rpm

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan4PulseWidth; // ms

            public byte Fan4StartBoost;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan1InputOffset;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan1OutputOffset;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan1OutputScale;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan1PowerSelected;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan2InputOffset;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan2OutputOffset;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan2OutputScale;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan2PowerSelected;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan3InputOffset;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan3OutputOffset;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan3OutputScale;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan3PowerSelected;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan4InputOffset;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan4OutputOffset;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan4OutputScale;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort Fan4PowerSelected;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            [Endian(Endianness.BigEndian)]
            public byte[] Unknown4;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort LightingOutputScale;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort LightingLEDOutput;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
            [Endian(Endianness.BigEndian)]
            public byte[] Unknown5;

            [MarshalAs(UnmanagedType.U2)]
            [Endian(Endianness.BigEndian)]
            public ushort LightingUnknown1;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            [Endian(Endianness.BigEndian)]
            public byte[] Unknown6;

            public byte LightingBrightnessSelected;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            [Endian(Endianness.BigEndian)]
            public byte[] Unknown7;
        }
    }
}
