using System.Collections.Generic;
using System.Linq;
using TelemetryServer.Structs.f120;

namespace TelemetryServer.Classes.f120
{
    public class PacketLapDataClass : HeaderClass
    {
        public List<LapDataClass> AllLapData { get; private set; }

        public PacketLapDataClass(PacketLapDataStruct packetStruct) : base(packetStruct.m_header)
        {
            AllLapData = packetStruct.m_lapData.Select(s => new LapDataClass(s)).ToList();
        }

        public class LapDataClass
        {
            public float LastLapTime { get; private set; }
            public float CurrentLapTime { get; private set; }
            public ushort Sector1TimeInMS { get; private set; }
            public ushort Sector2TimeInMS { get; private set; }
            public float BestLapTime { get; private set; }
            public byte BestLapNum { get; private set; }
            public ushort BestLapSector1TimeInMS { get; private set; }
            public ushort BestLapSector2TimeInMS { get; private set; }
            public ushort BestLapSector3TimeInMS { get; private set; }
            public ushort BestOverallSector1TimeInMS { get; private set; }
            public byte BestOverallSector1LapNum { get; private set; }
            public ushort BestOverallSector2TimeInMS { get; private set; }
            public byte BestOverallSector2LapNum { get; private set; }
            public ushort BestOverallSector3TimeInMS { get; private set; }
            public byte BestOverallSector3LapNum { get; private set; }
            public float LapDistance { get; private set; }
            public float TotalDistance { get; private set; }
            public float SafetyCarDelta { get; private set; }
            public byte CarPosition { get; private set; }
            public byte CurrentLapNum { get; private set; }
            public byte PitStatus { get; private set; }
            public byte Sector { get; private set; }
            public byte CurrentLapInvalid { get; private set; }
            public byte Penalties { get; private set; }
            public byte GridPosition { get; private set; }
            public byte DriverStatus { get; private set; }
            public byte ResultStatus { get; private set; }

            public LapDataClass(LapDataStruct lapDataStruct)
            {
                LastLapTime = lapDataStruct.m_lastLapTime;
                CurrentLapTime = lapDataStruct.m_currentLapTime;
                Sector1TimeInMS = lapDataStruct.m_sector1TimeInMS;
                Sector2TimeInMS = lapDataStruct.m_sector2TimeInMS;
                BestLapTime = lapDataStruct.m_bestLapTime;
                BestLapNum = lapDataStruct.m_bestLapNum;
                BestLapSector1TimeInMS = lapDataStruct.m_bestLapSector1TimeInMS;
                BestLapSector2TimeInMS = lapDataStruct.m_bestLapSector2TimeInMS;
                BestLapSector3TimeInMS = lapDataStruct.m_bestLapSector3TimeInMS;
                BestOverallSector1TimeInMS = lapDataStruct.m_bestOverallSector1TimeInMS;
                BestOverallSector1LapNum = lapDataStruct.m_bestOverallSector1LapNum;
                BestOverallSector2TimeInMS = lapDataStruct.m_bestOverallSector2TimeInMS;
                BestOverallSector2LapNum = lapDataStruct.m_bestOverallSector2LapNum;
                BestOverallSector3TimeInMS = lapDataStruct.m_bestOverallSector3TimeInMS;
                BestOverallSector3LapNum = lapDataStruct.m_bestOverallSector3LapNum;
                LapDistance = lapDataStruct.m_lapDistance;
                TotalDistance = lapDataStruct.m_totalDistance;
                SafetyCarDelta = lapDataStruct.m_safetyCarDelta;
                CarPosition = lapDataStruct.m_carPosition;
                CurrentLapNum = lapDataStruct.m_currentLapNum;
                PitStatus = lapDataStruct.m_pitStatus;
                Sector = lapDataStruct.m_sector;
                CurrentLapInvalid = lapDataStruct.m_currentLapInvalid;
                Penalties = lapDataStruct.m_penalties;
                GridPosition = lapDataStruct.m_gridPosition;
                DriverStatus = lapDataStruct.m_driverStatus;
                ResultStatus = lapDataStruct.m_resultStatus;
            }
        }
    }
}
