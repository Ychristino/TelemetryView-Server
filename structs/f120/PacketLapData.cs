using System.Runtime.InteropServices;

namespace TelemetryServer.Structs.f120
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketLapDataStruct
    {
        public PacketHeaderStruct m_header;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public LapDataStruct[] m_lapData;
    }
}
