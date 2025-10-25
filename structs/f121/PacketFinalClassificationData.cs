using System.Runtime.InteropServices;

namespace TelemetryServer.Structs.f121
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketFinalClassificationDataStruct
    {
        public PacketHeaderStruct m_header;

        public byte m_numCars; // Number of cars in the final classification

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public FinalClassificationDataStruct[] m_classificationData;
    }
}
