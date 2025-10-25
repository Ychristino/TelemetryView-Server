using TelemetryServer.Structs.f122;

namespace TelemetryServer.Classes.f122
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
        public float IsOverallFastestInSession { get; private set; }
        public float IsDriverFastestInSession { get; private set; }
        public float FastestVehicleIdxInSession { get; private set; }
        public float FastestSpeedInSession { get; private set; }
        public SpeedTrapEventClass(SpeedTrapStruct structData)
        {
            VehicleIdx = structData.vehicleIdx;
            Speed = structData.speed;
            IsOverallFastestInSession = structData.isOverallFastestInSession;
            IsDriverFastestInSession = structData.isDriverFastestInSession;
            FastestVehicleIdxInSession = structData.fastestVehicleIdxInSession;
            FastestSpeedInSession = structData.fastestSpeedInSession;
        }
    }

    public class StartLightsEventClass
    {
        public byte NumLights { get; private set; }
        public StartLightsEventClass(StartLightsStruct structData)
        {
            NumLights = structData.numLights;
        }
    }

    public class LightOutClass
    {
        public bool lightsOut { get; private set; }
        public LightOutClass(bool lightsOut)
        {
            this.lightsOut = lightsOut;
        }
    }

    public class DriveThroughPenaltyServedEventClass
    {
        public byte VehicleIdx { get; private set; }
        public DriveThroughPenaltyServedEventClass(DriveThroughPenaltyServedStruct structData)
        {
            VehicleIdx = structData.vehicleIdx;
        }
    }

    public class StopGoPenaltyServedEventClass
    {
        public byte VehicleIdx { get; private set; }
        public StopGoPenaltyServedEventClass(StopGoPenaltyServedStruct structData)
        {
            VehicleIdx = structData.vehicleIdx;
        }
    }

    public class FlashbackEventClass
    {
        public uint FlashbackFrameIdentifier { get; private set; }
        public float FlashbackSessionTime { get; private set; }
        public FlashbackEventClass(FlashbackStruct structData)
        {
            FlashbackFrameIdentifier = structData.flashbackFrameIdentifier;
            FlashbackSessionTime = structData.flashbackSessionTime;
        }
    }
    
    public class ButtonsEventClass
    {
        public uint ButtonStatus {get; private set; }
        public ButtonsEventClass(ButtonsStruct structData)
        {
            ButtonStatus = structData.m_buttonStatus;
        }
    }
}
