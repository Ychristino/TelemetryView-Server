using System.Runtime.InteropServices;

namespace TelemetryServer.Structs.f122
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketSessionDataStruct
    {
        public PacketHeaderStruct m_header;

        public byte m_weather;
        public sbyte m_trackTemperature;
        public sbyte m_airTemperature;
        public byte m_totalLaps;
        public ushort m_trackLength;
        public byte m_sessionType;
        public sbyte m_trackId;
        public byte m_formula;
        public ushort m_sessionTimeLeft;
        public ushort m_sessionDuration;
        public byte m_pitSpeedLimit;
        public byte m_gamePaused;
        public byte m_isSpectating;
        public byte m_spectatorCarIndex;
        public byte m_sliProNativeSupport;
        public byte m_numMarshalZones;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 21)]
        public MarshalZoneStruct[] m_marshalZones;

        public byte m_safetyCarStatus;
        public byte m_networkGame;
        public byte m_numWeatherForecastSamples;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 56)]
        public WeatherForecastSampleStruct[] m_weatherForecastSamples;
        public byte m_forecastAccuracy; // 0 = Perfect, 1 = Approximate
        public byte m_aiDifficulty; // AI Difficulty rating – 0-110
        public uint m_seasonLinkIdentifier; // Identifier for season - persists across saves
        public uint m_weekendLinkIdentifier; // Identifier for weekend - persists across saves
        public uint m_sessionLinkIdentifier; // Identifier for session - persists across saves
        public byte m_pitStopWindowIdealLap; // Ideal lap to pit on for current strategy (player)
        public byte m_pitStopWindowLatestLap; // Latest lap to pit on for current strategy (player)
        public byte m_pitStopRejoinPosition; // Predicted position to rejoin at (player)
        public byte m_steeringAssist; // 0 = off, 1 = on
        public byte m_brakingAssist; // 0 = off, 1 = low, 2 = medium, 3 = high
        public byte m_gearboxAssist; // 1 = manual, 2 = manual & suggested gear, 3 = auto
        public byte m_pitAssist; // 0 = off, 1 = on
        public byte m_pitReleaseAssist; // 0 = off, 1 = on
        public byte m_ERSAssist; // 0 = off, 1 = on
        public byte m_DRSAssist; // 0 = off, 1 = on
        public byte m_dynamicRacingLine; // 0 = off, 1 = corners only, 2 = full
        public byte m_dynamicRacingLineType; // 0 = 2D, 1 = 3D 
        public byte m_gameMode;              // Game mode id - see appendix
        public byte m_ruleSet;               // Ruleset - see appendix
        public uint m_timeOfDay;             // Local time of day - minutes since midnight
        public byte m_sessionLength;         // 0 = None, 2 = Very Short, 3 = Short, 4 = Medium, 5 = Medium Long, 6 = Long, 7 = Full
    }
}
