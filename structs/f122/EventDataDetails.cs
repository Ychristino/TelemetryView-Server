using System.Runtime.InteropServices;

namespace TelemetryServer.Structs.f122
{
    // Define as structs para cada tipo de evento

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FastestLapStruct
    {
        public byte vehicleIdx; // Vehicle index of car achieving fastest lap
        public float lapTime;    // Lap time is in seconds
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RetirementStruct
    {
        public byte vehicleIdx; // Vehicle index of car retiring
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TeamMateInPitsStruct
    {
        public byte vehicleIdx; // Vehicle index of team mate
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RaceWinnerStruct
    {
        public byte vehicleIdx; // Vehicle index of the race winner
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PenaltyStruct
    {
        public byte penaltyType;      // Penalty type – see Appendices
        public byte infringementType; // Infringement type – see Appendices
        public byte vehicleIdx;       // Vehicle index of the car the penalty is applied to
        public byte otherVehicleIdx;  // Vehicle index of the other car involved
        public byte time;             // Time gained, or time spent doing action in seconds
        public byte lapNum;           // Lap the penalty occurred on
        public byte placesGained;     // Number of places gained by this
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SpeedTrapStruct
    {
        public byte vehicleIdx; // Vehicle index of the vehicle triggering speed trap
        public float speed;        // Top speed achieved in kilometres per hour
        public byte isOverallFastestInSession; // Overall fastest speed in session = 1, otherwise 0
        public byte isDriverFastestInSession; // Fastest speed for driver in session = 1, otherwise 0
        public byte fastestVehicleIdxInSession; // Vehicle index of the vehicle that is the fastest in this session
        public float fastestSpeedInSession;     // Speed of the vehicle that is the fastest in this session
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct StartLightsStruct
    {
        public byte numLights; // Number of lights showing
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DriveThroughPenaltyServedStruct
    {
        public byte vehicleIdx; // Vehicle index of the vehicle serving drive through
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct StopGoPenaltyServedStruct
    {
        public byte vehicleIdx; // Vehicle index of the vehicle serving stop go
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FlashbackStruct
    {
        public uint flashbackFrameIdentifier; // Frame identifier flashed back to
        public float flashbackSessionTime; // Session time flashed back to
    }


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ButtonsStruct    {
        public uint m_buttonStatus; // Bit flags specifying which buttons are being pressed
    } 

    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public struct EventDataDetailsStruct
    {
        [FieldOffset(0)]
        public FastestLapStruct fastestLap;

        [FieldOffset(0)]
        public RetirementStruct retirement;

        [FieldOffset(0)]
        public TeamMateInPitsStruct teamMateInPits;

        [FieldOffset(0)]
        public RaceWinnerStruct raceWinner;

        [FieldOffset(0)]
        public PenaltyStruct penalty;

        [FieldOffset(0)]
        public SpeedTrapStruct speedTrap;

        [FieldOffset(0)]
        public StartLightsStruct startLight;

        [FieldOffset(0)]
        public DriveThroughPenaltyServedStruct driveThroughPenaltyServed;

        [FieldOffset(0)]
        public StopGoPenaltyServedStruct stopGoPenaltyServed;

        [FieldOffset(0)]
        public FlashbackStruct flashbackStruct;

        [FieldOffset(0)]
        public ButtonsStruct buttonStruct;
    }
}
