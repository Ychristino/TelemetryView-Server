using TelemetryServer.Classes.f122;

namespace TelemetryServer.Exporters.f122
{
    public class DataExporter
    {
        private PacketMotionDataClass? _motion = null;
        private PacketSessionDataClass? _session = null;
        private PacketLapDataClass? _lapData = null;
        private PacketEventDataClass? _eventData = null;
        private PacketParticipantsDataClass? _participants = null;
        private PacketCarSetupDataClass? _carSetup = null;
        private PacketCarTelemetryDataClass? _telemetry = null;
        private PacketCarStatusDataClass? _carStatus = null;
        private PacketFinalClassificationDataClass? _finalClassification = null;
        private PacketLobbyInfoDataClass? _lobbyInfo = null;
        private PacketCarDamageDataClass? _carDamage = null;
        private PacketSessionHistoryDataClass? _sessionHistory = null;

        public DataExporter(PacketMotionDataClass motion, PacketSessionDataClass session, PacketLapDataClass lapData, PacketEventDataClass eventData, PacketParticipantsDataClass participants, PacketCarSetupDataClass carSetup, PacketCarTelemetryDataClass telemetry, PacketCarStatusDataClass carStatus, PacketFinalClassificationDataClass finalClassification, PacketLobbyInfoDataClass lobbyInfo, PacketCarDamageDataClass carDamage, PacketSessionHistoryDataClass sessionHistory)
        {
            this._motion = motion;
            this._session = session;
            this._lapData = lapData;
            this._eventData = eventData;
            this._participants = participants;
            this._carSetup = carSetup;
            this._telemetry = telemetry;
            this._carStatus = carStatus;
            this._finalClassification = finalClassification;
            this._carDamage = carDamage;
            this._sessionHistory = sessionHistory;
        }

        public string exportConfigurationBasicData(string identifier)
        {
            return $"[{identifier}]" +
                   $"\n__currLapDistance=__currLapDistance,0" +
                   $"\n__currLapTime=__currLapTime,1" +
                   $"\n__currLapNum=__currLapNum,2" +

                   $"\nspeed=Speed,5" +
                   $"\nthrottle=Throttle,6" +
                   $"\nbrake=Brake,7" +
                   $"\nclutch=Clutch,8" +
                   $"\nsteer=Steer Angle,9" +
                   $"\ngear=Gear,10" +
                   $"\nenginerpm=Engine RPM,11"
            ;
        }

        public string exportConfigurationDetailsData(string identifier)
        {
            return $"[{identifier}]" +
                   $"\n__currLapDistance=__currLapDistance,0" +
                   $"\n__currLapTime=__currLapTime,1" +
                   $"\n__currLapNum=__currLapNum,2" +
                   $"\nbrakesTemperatureRL=brakesTemperatureRL,5" +
                   $"\nbrakesTemperatureRR=brakesTemperatureRR,6" +
                   $"\nbrakesTemperatureFL=brakesTemperatureFL,7" +
                   $"\nbrakesTemperatureFR=brakesTemperatureFR,8" +

                   $"\ntyreSurfaceTemperatureRL=tyreSurfaceTemperatureRL,9" +
                   $"\ntyreSurfaceTemperatureRR=tyreSurfaceTemperatureRR,10" +
                   $"\ntyreSurfaceTemperatureFL=tyreSurfaceTemperatureFL,11" +
                   $"\ntyreSurfaceTemperatureFR=tyreSurfaceTemperatureFR,12" +

                   $"\ntyreInnerTemperatureRL=tyreInnerTemperatureRL,13" +
                   $"\ntyreInnerTemperatureRR=tyreInnerTemperatureRR,14" +
                   $"\ntyreInnerTemperatureFL=tyreInnerTemperatureFL,15" +
                   $"\ntyreInnerTemperatureFR=tyreInnerTemperatureFR,16" +

                   $"\ntyrePressureTemperatureRL=tyrePressureTemperatureRL,17" +
                   $"\ntyrePressureTemperatureRR=tyrePressureTemperatureRR,18" +
                   $"\ntyrePressureTemperatureFL=tyrePressureTemperatureFL,19" +
                   $"\ntyrePressureTemperatureFR=tyrePressureTemperatureFR,20" +

                   $"\nsurfaceRL=surfaceRL,21" +
                   $"\nsurfaceRR=surfaceRR,22" +
                   $"\nsurfaceFL=surfaceFL,23" +
                   $"\nsurfaceFR=surfaceFR,24" +

                   $"\nengineTemperature=Throttle,25"
            ;
        }

        public string exportConfigurationDetailsData(int carIndex)
        {

            return $"{this._lapData.AllLapData[carIndex].LapDistance}" +
                   $";{this._lapData.AllLapData[carIndex].CurrentLapTime}" +
                   $";{this._lapData.AllLapData[carIndex].CurrentLapNum}" +

                   $";{this._telemetry.AllCarTelemetryData[carIndex].BrakesTemperature[0]}" +
                   $";{this._telemetry.AllCarTelemetryData[carIndex].BrakesTemperature[1]}" +
                   $";{this._telemetry.AllCarTelemetryData[carIndex].BrakesTemperature[2]}" +
                   $";{this._telemetry.AllCarTelemetryData[carIndex].BrakesTemperature[3]}" +

                   $";{this._telemetry.AllCarTelemetryData[carIndex].TyresSurfaceTemperature[0]}" +
                   $";{this._telemetry.AllCarTelemetryData[carIndex].TyresSurfaceTemperature[1]}" +
                   $";{this._telemetry.AllCarTelemetryData[carIndex].TyresSurfaceTemperature[2]}" +
                   $";{this._telemetry.AllCarTelemetryData[carIndex].TyresSurfaceTemperature[3]}" +

                   $";{this._telemetry.AllCarTelemetryData[carIndex].TyresPressure[0]}" +
                   $";{this._telemetry.AllCarTelemetryData[carIndex].TyresPressure[1]}" +
                   $";{this._telemetry.AllCarTelemetryData[carIndex].TyresPressure[2]}" +
                   $";{this._telemetry.AllCarTelemetryData[carIndex].TyresPressure[3]}" +

                   $";{this._telemetry.AllCarTelemetryData[carIndex].SurfaceType[0]}" +
                   $";{this._telemetry.AllCarTelemetryData[carIndex].SurfaceType[1]}" +
                   $";{this._telemetry.AllCarTelemetryData[carIndex].SurfaceType[2]}" +
                   $";{this._telemetry.AllCarTelemetryData[carIndex].SurfaceType[3]}" +

                   $";{this._telemetry.AllCarTelemetryData[carIndex].EngineTemperature}"
            ;
        }

        public string exportBasicData(int carIndex)
        {
            return $"{this._lapData.AllLapData[carIndex].LapDistance}" +
                   $";{this._lapData.AllLapData[carIndex].CurrentLapTime}" +
                   $";{this._lapData.AllLapData[carIndex].CurrentLapNum}" +

                   $";{this._telemetry.AllCarTelemetryData[carIndex].Speed}" +
                   $";{this._telemetry.AllCarTelemetryData[carIndex].Throttle}" +
                   $";{this._telemetry.AllCarTelemetryData[carIndex].Brake}" +
                   $";{this._telemetry.AllCarTelemetryData[carIndex].Clutch}" +
                   $";{this._telemetry.AllCarTelemetryData[carIndex].Steer}" +
                   $";{this._telemetry.AllCarTelemetryData[carIndex].Gear}" +
                   $";{this._telemetry.AllCarTelemetryData[carIndex].EngineRpm}"
            ;
        }

    }
}

