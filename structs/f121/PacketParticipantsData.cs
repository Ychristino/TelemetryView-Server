using System.Runtime.InteropServices;

namespace TelemetryServer.Structs.f121
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketParticipantsDataStruct
    {
        public PacketHeaderStruct m_header;

        public byte m_numActiveCars; // Number of active cars in the data

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public ParticipantDataStruct[] m_participants;
    }
}
