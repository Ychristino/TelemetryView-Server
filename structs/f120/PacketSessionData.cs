using System.Runtime.InteropServices;

namespace TelemetryServer.Structs.f120
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

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public WeatherForecastSampleStruct[] m_weatherForecastSamples;
    }
}
