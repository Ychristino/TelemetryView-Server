using TelemetryServer.Structs.f120;

namespace TelemetryServer.Classes.f120
{
    public class FastestLapEventClass
    {
        public byte VehicleIdx { get; private set; }
        public float LapTime { get; private set; }
        public FastestLapEventClass(FastestLapStruct structData)
        {
            VehicleIdx = structData.vehicleIdx;
            LapTime = structData.lapTime;
        }
    }

    public class RetirementEventClass
    {
        public byte VehicleIdx { get; private set; }
        public RetirementEventClass(RetirementStruct structData)
        {
            VehicleIdx = structData.vehicleIdx;
        }
    }

    public class TeamMateInPitsEventClass
    {
        public byte VehicleIdx { get; private set; }
        public TeamMateInPitsEventClass(TeamMateInPitsStruct structData)
        {
            VehicleIdx = structData.vehicleIdx;
        }
    }

    public class RaceWinnerEventClass
    {
        public byte VehicleIdx { get; private set; }
        public RaceWinnerEventClass(RaceWinnerStruct structData)
        {
            VehicleIdx = structData.vehicleIdx;
        }
    }

    public class PenaltyEventClass
    {
        public byte PenaltyType { get; private set; }
        public byte InfringementType { get; private set; }
        public byte VehicleIdx { get; private set; }
        public byte OtherVehicleIdx { get; private set; }
        public byte Time { get; private set; }
        public byte LapNum { get; private set; }
        public byte PlacesGained { get; private set; }
        public PenaltyEventClass(PenaltyStruct structData)
        {
            PenaltyType = structData.penaltyType;
            InfringementType = structData.infringementType;
            VehicleIdx = structData.vehicleIdx;
            OtherVehicleIdx = structData.otherVehicleIdx;
            Time = structData.time;
            LapNum = structData.lapNum;
            PlacesGained = structData.placesGained;
        }
    }

    public class SpeedTrapEventClass
    {
        public byte VehicleIdx { get; private set; }
        public float Speed { get; private set; }
        public SpeedTrapEventClass(SpeedTrapStruct structData)
        {
            VehicleIdx = structData.vehicleIdx;
            Speed = structData.speed;
        }
    }
}
