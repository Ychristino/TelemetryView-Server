using System.Runtime.InteropServices;

namespace TelemetryServer.Structs.f122
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct LapHistoryDataStruct
    {
        public uint m_lapTimeInMS;      // Tempo da volta em milissegundos
        public ushort m_sector1TimeInMS;  // Tempo do setor 1 em milissegundos
        public ushort m_sector2TimeInMS;  // Tempo do setor 2 em milissegundos
        public ushort m_sector3TimeInMS;  // Tempo do setor 3 em milissegundos
        public byte m_lapValidBitFlags;   // Flags de validade da volta e setores
    }
}
