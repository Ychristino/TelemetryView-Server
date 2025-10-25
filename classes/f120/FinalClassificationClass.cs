using System.Collections.Generic;
using System.Linq;
using TelemetryServer.Structs.f120;

namespace TelemetryServer.Classes.f120
{
    public class PacketFinalClassificationDataClass : HeaderClass
    {
        public byte NumCars { get; private set; }
        public List<FinalClassificationDataClass> ClassificationData { get; private set; }

        public PacketFinalClassificationDataClass(PacketFinalClassificationDataStruct packetStruct) : base(packetStruct.m_header)
        {
            NumCars = packetStruct.m_numCars;
            ClassificationData = packetStruct.m_classificationData.Select(s => new FinalClassificationDataClass(s)).ToList();
        }

        public class FinalClassificationDataClass
        {
            public byte Position { get; private set; }
            public byte NumLaps { get; private set; }
            public byte GridPosition { get; private set; }
            public byte Points { get; private set; }
            public byte NumPitStops { get; private set; }
            public byte ResultStatus { get; private set; }
            public float BestLapTime { get; private set; }
            public double TotalRaceTime { get; private set; }
            public byte PenaltiesTime { get; private set; }
            public byte NumPenalties { get; private set; }
            public byte NumTyreStints { get; private set; }
            public byte[] TyreStintsActual { get; private set; }
            public byte[] TyreStintsVisual { get; private set; }

            public FinalClassificationDataClass(FinalClassificationDataStruct finalClassificationStruct)
            {
                Position = finalClassificationStruct.m_position;
                NumLaps = finalClassificationStruct.m_numLaps;
                GridPosition = finalClassificationStruct.m_gridPosition;
                Points = finalClassificationStruct.m_points;
                NumPitStops = finalClassificationStruct.m_numPitStops;
                ResultStatus = finalClassificationStruct.m_resultStatus;
                BestLapTime = finalClassificationStruct.m_bestLapTime;
                TotalRaceTime = finalClassificationStruct.m_totalRaceTime;
                PenaltiesTime = finalClassificationStruct.m_penaltiesTime;
                NumPenalties = finalClassificationStruct.m_numPenalties;
                NumTyreStints = finalClassificationStruct.m_numTyreStints;
                TyreStintsActual = finalClassificationStruct.m_tyreStintsActual.ToArray();
                TyreStintsVisual = finalClassificationStruct.m_tyreStintsVisual.ToArray();
            }
        }
    }
}
