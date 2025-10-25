using System.Collections.Generic;
using System.Linq;
using TelemetryServer.Structs.f120;

namespace TelemetryServer.Classes.f120
{
    public class PacketSessionDataClass : HeaderClass
    {
        public byte Weather { get; private set; }
        public sbyte TrackTemperature { get; private set; }
        public sbyte AirTemperature { get; private set; }
        public byte TotalLaps { get; private set; }
        public ushort TrackLength { get; private set; }
        public byte SessionType { get; private set; }
        public sbyte TrackId { get; private set; }
        public byte Formula { get; private set; }
        public ushort SessionTimeLeft { get; private set; }
        public ushort SessionDuration { get; private set; }
        public byte PitSpeedLimit { get; private set; }
        public byte GamePaused { get; private set; }
        public byte IsSpectating { get; private set; }
        public byte SpectatorCarIndex { get; private set; }
        public byte SliProNativeSupport { get; private set; }
        public byte NumMarshalZones { get; private set; }
        public List<MarshalZoneStruct> MarshalZones { get; private set; }
        public byte SafetyCarStatus { get; private set; }
        public byte NetworkGame { get; private set; }
        public byte NumWeatherForecastSamples { get; private set; }
        public List<WeatherForecastSampleStruct> WeatherForecastSamples { get; private set; }

        public PacketSessionDataClass(PacketSessionDataStruct packetStruct) : base(packetStruct.m_header)
        {
            Weather = packetStruct.m_weather;
            TrackTemperature = packetStruct.m_trackTemperature;
            AirTemperature = packetStruct.m_airTemperature;
            TotalLaps = packetStruct.m_totalLaps;
            TrackLength = packetStruct.m_trackLength;
            SessionType = packetStruct.m_sessionType;
            TrackId = packetStruct.m_trackId;
            Formula = packetStruct.m_formula;
            SessionTimeLeft = packetStruct.m_sessionTimeLeft;
            SessionDuration = packetStruct.m_sessionDuration;
            PitSpeedLimit = packetStruct.m_pitSpeedLimit;
            GamePaused = packetStruct.m_gamePaused;
            IsSpectating = packetStruct.m_isSpectating;
            SpectatorCarIndex = packetStruct.m_spectatorCarIndex;
            SliProNativeSupport = packetStruct.m_sliProNativeSupport;
            NumMarshalZones = packetStruct.m_numMarshalZones;
            MarshalZones = packetStruct.m_marshalZones.ToList();
            SafetyCarStatus = packetStruct.m_safetyCarStatus;
            NetworkGame = packetStruct.m_networkGame;
            NumWeatherForecastSamples = packetStruct.m_numWeatherForecastSamples;
            WeatherForecastSamples = packetStruct.m_weatherForecastSamples.ToList();
        }
    }
}
