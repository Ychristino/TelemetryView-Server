using System.Runtime.InteropServices;

namespace TelemetryServer.Structs.f122
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FinalClassificationDataStruct
    {
        public byte m_position;              // Finishing position
        public byte m_numLaps;               // Number of laps completed
        public byte m_gridPosition;          // Grid position of the car
        public byte m_points;                // Number of points scored
        public byte m_numPitStops;           // Number of pit stops made
        public byte m_resultStatus;          // Result status
        public float m_bestLapTime;           // Best lap time of the session in seconds
        public double m_totalRaceTime;         // Total race time in seconds without penalties
        public byte m_penaltiesTime;         // Total penalties accumulated in seconds
        public byte m_numPenalties;          // Number of penalties applied to this driver
        public byte m_numTyreStints;         // Number of tyres stints up to maximum
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] m_tyreStintsActual;    // Actual tyres used by this driver

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] m_tyreStintsVisual;    // Visual tyres used by this driver
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] m_tyreStintsEndLaps;    // The lap number stints end on
    }
}
