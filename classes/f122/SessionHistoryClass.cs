using System.Collections.Generic;
using System.Linq;
using TelemetryServer.Structs.f122;
using TelemetryServer.Classes.f122; 

namespace TelemetryServer.Classes.f122
{
    public class PacketSessionHistoryDataClass : HeaderClass
    {
        public byte CarIdx { get; private set; }
        public byte NumLaps { get; private set; }
        public byte NumTyreStints { get; private set; }
        public byte BestLapTimeLapNum { get; private set; }
        public byte BestSector1LapNum { get; private set; }
        public byte BestSector2LapNum { get; private set; }
        public byte BestSector3LapNum { get; private set; }
        public List<LapHistoryDataClass> LapHistoryData { get; private set; }
        public List<TyreStintHistoryDataClass> TyreStintsHistoryData { get; private set; }

        public PacketSessionHistoryDataClass(PacketSessionHistoryDataStruct packetStruct) : base(packetStruct.m_header)
        {
            CarIdx = packetStruct.m_carIdx;
            NumLaps = packetStruct.m_numLaps;
            NumTyreStints = packetStruct.m_numTyreStints;
            BestLapTimeLapNum = packetStruct.m_bestLapTimeLapNum;
            BestSector1LapNum = packetStruct.m_bestSector1LapNum;
            BestSector2LapNum = packetStruct.m_bestSector2LapNum;
            BestSector3LapNum = packetStruct.m_bestSector3LapNum;

            // Mapeia os arrays de structs para listas de classes
            LapHistoryData = packetStruct.m_lapHistoryData
                .Select(s => new LapHistoryDataClass(s))
                .Take(packetStruct.m_numLaps)
                .ToList();

            TyreStintsHistoryData = packetStruct.m_tyreStintsHistoryData
                .Select(s => new TyreStintHistoryDataClass(s))
                .Take(packetStruct.m_numTyreStints)
                .ToList();
        }

    }

    public class LapHistoryDataClass
    {
        public uint LapTimeInMs { get; private set; }
        public ushort Sector1TimeInMs { get; private set; }
        public ushort Sector2TimeInMs { get; private set; }
        public ushort Sector3TimeInMs { get; private set; }
        public byte LapValidBitFlags { get; private set; }

        public LapHistoryDataClass(LapHistoryDataStruct lapStruct)
        {
            LapTimeInMs = lapStruct.m_lapTimeInMS;
            Sector1TimeInMs = lapStruct.m_sector1TimeInMS;
            Sector2TimeInMs = lapStruct.m_sector2TimeInMS;
            Sector3TimeInMs = lapStruct.m_sector3TimeInMS;
            LapValidBitFlags = lapStruct.m_lapValidBitFlags;
        }
    }
    
    public class TyreStintHistoryDataClass
    {
        public byte EndLap { get; private set; }
        public byte TyreActualCompound { get; private set; }
        public byte TyreVisualCompound { get; private set; }

        public TyreStintHistoryDataClass(TyreStintHistoryDataStruct stintStruct)
        {
            EndLap = stintStruct.m_endLap;
            TyreActualCompound = stintStruct.m_tyreActualCompound;
            TyreVisualCompound = stintStruct.m_tyreVisualCompound;
        }
    }
}
