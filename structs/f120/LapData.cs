using System.Runtime.InteropServices;

namespace TelemetryServer.Structs.f120
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct LapDataStruct
    {
        public float m_lastLapTime;               // Last lap time in seconds
        public float m_currentLapTime;            // Current time around the lap in seconds
        public ushort m_sector1TimeInMS;           // Sector 1 time in milliseconds
        public ushort m_sector2TimeInMS;           // Sector 2 time in milliseconds
        public float m_bestLapTime;               // Best lap time of the session in seconds
        public byte m_bestLapNum;                // Lap number best time achieved on
        public ushort m_bestLapSector1TimeInMS;    // Sector 1 time of best lap in the session in milliseconds
        public ushort m_bestLapSector2TimeInMS;    // Sector 2 time of best lap in the session in milliseconds
        public ushort m_bestLapSector3TimeInMS;    // Sector 3 time of best lap in the session in milliseconds
        public ushort m_bestOverallSector1TimeInMS;// Best overall sector 1 time of the session in milliseconds
        public byte m_bestOverallSector1LapNum;  // Lap number best overall sector 1 time achieved on
        public ushort m_bestOverallSector2TimeInMS;// Best overall sector 2 time of the session in milliseconds
        public byte m_bestOverallSector2LapNum;  // Lap number best overall sector 2 time achieved on
        public ushort m_bestOverallSector3TimeInMS;// Best overall sector 3 time of the session in milliseconds
        public byte m_bestOverallSector3LapNum;  // Lap number best overall sector 3 time achieved on
        public float m_lapDistance;               // Distance vehicle is around current lap in metres
        public float m_totalDistance;             // Total distance travelled in session in metres
        public float m_safetyCarDelta;            // Delta in seconds for safety car
        public byte m_carPosition;               // Car race position
        public byte m_currentLapNum;             // Current lap number
        public byte m_pitStatus;                 // 0 = none, 1 = pitting, 2 = in pit area
        public byte m_sector;                    // 0 = sector1, 1 = sector2, 2 = sector3
        public byte m_currentLapInvalid;         // Current lap invalid - 0 = valid, 1 = invalid
        public byte m_penalties;                 // Accumulated time penalties in seconds to be added
        public byte m_gridPosition;              // Grid position the vehicle started the race in
        public byte m_driverStatus;              // Status of driver
        public byte m_resultStatus;              // Result status
    }
}
