using System.Runtime.InteropServices;

namespace TelemetryServer.Structs.f121
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TyreStintHistoryDataStruct
    {
        public byte m_endLap;                // Volta em que o pneu terminou (255 se for o pneu atual)
        public byte m_tyreActualCompound;    // Composto real do pneu usado
        public byte m_tyreVisualCompound;    // Composto visual do pneu usado
    }
}
