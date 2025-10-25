using System.Runtime.InteropServices;

namespace TelemetryServer.Structs.f122
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketLapDataStruct
    {
        public PacketHeaderStruct m_header;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public LapDataStruct[] m_lapData;
        public byte m_timeTrialPBCarIdx;    // Index of Personal Best car in time trial (255 if invalid)
        public byte m_timeTrialRivalCarIdx;	// Index of Rival car in time trial (255 if invalid)

    }
}
