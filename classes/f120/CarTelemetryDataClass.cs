using System.Collections.Generic;
using System.Linq;
using TelemetryServer.Structs.f120;

namespace TelemetryServer.Classes.f120
{
    public class PacketCarTelemetryDataClass : HeaderClass
    {
        public List<CarTelemetryDataClass> AllCarTelemetryData { get; private set; }
        public uint ButtonStatus { get; private set; }
        public byte MfdPanelIndex { get; private set; }
        public byte MfdPanelIndexSecondaryPlayer { get; private set; }
        public sbyte SuggestedGear { get; private set; }
        public static string identifier = "carTelemetry";

        public PacketCarTelemetryDataClass(PacketCarTelemetryDataStruct packetStruct) : base(packetStruct.m_header)
        {
            AllCarTelemetryData = packetStruct.m_carTelemetryData.Select(s => new CarTelemetryDataClass(s)).ToList();
            ButtonStatus = packetStruct.m_buttonStatus;
            MfdPanelIndex = packetStruct.m_mfdPanelIndex;
            MfdPanelIndexSecondaryPlayer = packetStruct.m_mfdPanelIndexSecondaryPlayer;
            SuggestedGear = packetStruct.m_suggestedGear;
        }

        public class CarTelemetryDataClass
        {
            public ushort Speed { get; private set; }
            public float Throttle { get; private set; }
            public float Steer { get; private set; }
            public float Brake { get; private set; }
            public byte Clutch { get; private set; }
            public sbyte Gear { get; private set; }
            public ushort EngineRpm { get; private set; }
            public byte Drs { get; private set; }
            public byte RevLightsPercent { get; private set; }
            public ushort[] BrakesTemperature { get; private set; }
            public byte[] TyresSurfaceTemperature { get; private set; }
            public byte[] TyresInnerTemperature { get; private set; }
            public ushort EngineTemperature { get; private set; }
            public float[] TyresPressure { get; private set; }
            public byte[] SurfaceType { get; private set; }

            public CarTelemetryDataClass(CarTelemetryDataStruct telemetryStruct)
            {
                Speed = telemetryStruct.m_speed;
                Throttle = telemetryStruct.m_throttle;
                Brake = telemetryStruct.m_brake;
                Clutch = telemetryStruct.m_clutch;
                Gear = telemetryStruct.m_gear;
                EngineRpm = telemetryStruct.m_engineRPM;
                Steer = telemetryStruct.m_steer;
                Drs = telemetryStruct.m_drs;
                RevLightsPercent = telemetryStruct.m_revLightsPercent;
                BrakesTemperature = telemetryStruct.m_brakesTemperature.ToArray();
                TyresSurfaceTemperature = telemetryStruct.m_tyresSurfaceTemperature.ToArray();
                TyresInnerTemperature = telemetryStruct.m_tyresInnerTemperature.ToArray();
                EngineTemperature = telemetryStruct.m_engineTemperature;
                TyresPressure = telemetryStruct.m_tyresPressure.ToArray();
                SurfaceType = telemetryStruct.m_surfaceType.ToArray();
            }
        }
        public string getConfigurationFile()
        {
            return $"[{identifier}]" +
                   $"\n__id=__id,0" +
                   $"\nthrottle=Throttle,1" +
                   $"\nbrake=Brake,2" +
                   $"\nclutch=Clutch,3" +
                   $"\ngear=Gear,4" +
                   $"\nspeed=Speed,5";
                //    $"\nengineRpm=EngineRpm,5" +
                //    $"\nsteer=Steer,6" +
        }
        
        public string getCurrentStatus()
        {
            var player = this.AllCarTelemetryData[this.PlayerCarIndex];

            return $"{this.FrameIdentifier};" +
                $"{player.Throttle};" +
                $"{player.Brake};" +
                $"{player.Clutch};" +
                $"{player.Gear};" +
                $"{player.Speed}";
                // $"{player.EngineRpm};" +
                // $"{player.Steer};" +
        }
    }
}
