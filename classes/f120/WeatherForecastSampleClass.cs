using TelemetryServer.Structs.f120;

namespace TelemetryServer.Classes.f120
{
    public class WeatherForecastSampleClass
    {
        public byte SessionType { get; private set; }
        public byte TimeOffset { get; private set; }
        public byte Weather { get; private set; }
        public sbyte TrackTemperature { get; private set; }
        public sbyte AirTemperature { get; private set; }

        public WeatherForecastSampleClass(WeatherForecastSampleStruct structData)
        {
            SessionType = structData.m_sessionType;
            TimeOffset = structData.m_timeOffset;
            Weather = structData.m_weather;
            TrackTemperature = structData.m_trackTemperature;
            AirTemperature = structData.m_airTemperature;
        }
    }
}