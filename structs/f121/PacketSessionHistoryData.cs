using System.Runtime.InteropServices;

namespace TelemetryServer.Structs.f121
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketSessionHistoryDataStruct
    {
        public PacketHeaderStruct m_header;                 // Cabeçalho
        public byte m_carIdx;                         // Índice do carro a que se referem os dados
        public byte m_numLaps;                        // Número de voltas nos dados
        public byte m_numTyreStints;                  // Número de stints de pneu
        public byte m_bestLapTimeLapNum;              // Volta em que o melhor tempo foi alcançado
        public byte m_bestSector1LapNum;              // Volta em que o melhor tempo do setor 1 foi alcançado
        public byte m_bestSector2LapNum;              // Volta em que o melhor tempo do setor 2 foi alcançado
        public byte m_bestSector3LapNum;              // Volta em que o melhor tempo do setor 3 foi alcançado

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100)]
        public LapHistoryDataStruct[] m_lapHistoryData;  // Histórico de 100 voltas no máximo

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public TyreStintHistoryDataStruct[] m_tyreStintsHistoryData; // Histórico de 8 stints de pneu
    }
}
