using System.Runtime.InteropServices;

namespace TelemetryServer.Structs.f120
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
    }

    // A struct para simular a 'union' do C++
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
    }
}
