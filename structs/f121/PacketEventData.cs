using System.Runtime.InteropServices;

namespace TelemetryServer.Structs.f121
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketEventDataStruct
    {
        public PacketHeaderStruct m_header;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] m_eventStringCode;

        public EventDataDetailsStruct m_eventDetails;
    }
}
