using System.Collections.Generic;
using System.Linq;
using TelemetryServer.Structs.f122;

namespace TelemetryServer.Classes.f122
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

        public byte ForecastAccuracy;
        public byte AiDifficulty;
        public uint SeasonLinkIdentifier;
        public uint WeekendLinkIdentifier;
        public uint SessionLinkIdentifier;
        public byte pitStopWindowIdealLap;
        public byte PitStopWindowLatestLap;
        public byte PitStopRejoinPosition;
        public byte SteeringAssist;
        public byte BrakingAssist;
        public byte GearboxAssist;
        public byte PitAssist;
        public byte PitReleaseAssist;
        public byte ERSAssist;
        public byte DRSAssist;
        public byte DynamicRacingLine;
        public byte DynamicRacingLineType;
        public byte GameMode;
        public byte RuleSet;
        public uint TimeOfDay;
        public byte SessionLength;

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
            ForecastAccuracy = packetStruct.m_forecastAccuracy;
            AiDifficulty = packetStruct.m_aiDifficulty;
            SeasonLinkIdentifier = packetStruct.m_seasonLinkIdentifier;
            WeekendLinkIdentifier = packetStruct.m_weekendLinkIdentifier;
            SessionLinkIdentifier = packetStruct.m_sessionLinkIdentifier;
            pitStopWindowIdealLap = packetStruct.m_pitStopWindowIdealLap;
            PitStopWindowLatestLap = packetStruct.m_pitStopWindowLatestLap;
            PitStopRejoinPosition = packetStruct.m_pitStopRejoinPosition;
            SteeringAssist = packetStruct.m_steeringAssist;
            BrakingAssist = packetStruct.m_brakingAssist;
            GearboxAssist = packetStruct.m_gearboxAssist;
            PitAssist = packetStruct.m_pitAssist;
            PitReleaseAssist = packetStruct.m_pitReleaseAssist;
            ERSAssist = packetStruct.m_ERSAssist;
            DRSAssist = packetStruct.m_DRSAssist;
            DynamicRacingLine = packetStruct.m_dynamicRacingLine;
            DynamicRacingLineType = packetStruct.m_dynamicRacingLineType;
            GameMode = packetStruct.m_gameMode;
            RuleSet = packetStruct.m_ruleSet;
            TimeOfDay = packetStruct.m_timeOfDay;
            SessionLength = packetStruct.m_sessionLength;
        }
    }
}
