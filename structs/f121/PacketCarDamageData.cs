using System.Runtime.InteropServices;

namespace TelemetryServer.Structs.f121
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketCarDamageDataStruct
    {
        public PacketHeaderStruct m_header; // Cabeçalho

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public CarDamageDataStruct[] m_carDamageData;
    }
}
