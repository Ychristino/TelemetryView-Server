using TelemetryServer.Structs.f121;

namespace TelemetryServer.Classes.f121
{
    public class WeatherForecastSampleClass
    {
        public byte SessionType { get; private set; }
        public byte TimeOffset { get; private set; }
        public byte Weather { get; private set; }
        public sbyte TrackTemperature { get; private set; }
        public sbyte TrackTemperatureChange { get; private set; }
        public sbyte AirTemperature { get; private set; }
        public sbyte AirTemperatureChange { get; private set; }
        public sbyte RainPercentage { get; private set; }

        public WeatherForecastSampleClass(WeatherForecastSampleStruct structData)
        {
            SessionType = structData.m_sessionType;
            TimeOffset = structData.m_timeOffset;
            Weather = structData.m_weather;
            TrackTemperature = structData.m_trackTemperature;
            TrackTemperatureChange = structData.m_trackTemperatureChange;
            AirTemperature = structData.m_airTemperature;
            AirTemperatureChange = structData.m_airTemperatureChange;
            RainPercentage = structData.m_rainPercentage;
        }
    }
}