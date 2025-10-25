using System.Collections.Generic;
using System.Linq;
using TelemetryServer.Structs.f122;

namespace TelemetryServer.Classes.f122
{
    public class PacketCarStatusDataClass : HeaderClass
    {
        public List<CarStatusDataClass> AllCarStatusData { get; private set; }

        public PacketCarStatusDataClass(PacketCarStatusDataStruct packetStruct) : base(packetStruct.m_header)
        {
            AllCarStatusData = packetStruct.m_carStatusData.Select(s => new CarStatusDataClass(s)).ToList();
        }

        public class CarStatusDataClass
        {
            public byte TractionControl { get; private set; }
            public byte AntiLockBrakes { get; private set; }
            public byte FuelMix { get; private set; }
            public byte FrontBrakeBias { get; private set; }
            public byte PitLimiterStatus { get; private set; }
            public float FuelInTank { get; private set; }
            public float FuelCapacity { get; private set; }
            public float FuelRemainingLaps { get; private set; }
            public ushort MaxRpm { get; private set; }
            public ushort IdleRpm { get; private set; }
            public byte MaxGears { get; private set; }
            public byte DrsAllowed { get; private set; }
            public ushort DrsActivationDistance { get; private set; }
            public byte ActualTyreCompound { get; private set; }
            public byte TyreVisualCompound { get; private set; }
            public byte TyresAgeLaps { get; private set; }
            public sbyte VehicleFiaFlags { get; private set; }
            public float ErsStoreEnergy { get; private set; }
            public byte ErsDeployMode { get; private set; }
            public float ErsHarvestedThisLapMguk { get; private set; }
            public float ErsHarvestedThisLapMguh { get; private set; }
            public float ErsDeployedThisLap { get; private set; }
            public byte NetworkPaused { get; private set; }

            public CarStatusDataClass(CarStatusDataStruct statusStruct)
            {
                TractionControl = statusStruct.m_tractionControl;
                AntiLockBrakes = statusStruct.m_antiLockBrakes;
                FuelMix = statusStruct.m_fuelMix;
                FrontBrakeBias = statusStruct.m_frontBrakeBias;
                PitLimiterStatus = statusStruct.m_pitLimiterStatus;
                FuelInTank = statusStruct.m_fuelInTank;
                FuelCapacity = statusStruct.m_fuelCapacity;
                FuelRemainingLaps = statusStruct.m_fuelRemainingLaps;
                MaxRpm = statusStruct.m_maxRPM;
                IdleRpm = statusStruct.m_idleRPM;
                MaxGears = statusStruct.m_maxGears;
                DrsAllowed = statusStruct.m_drsAllowed;
                DrsActivationDistance = statusStruct.m_drsActivationDistance;
                ActualTyreCompound = statusStruct.m_actualTyreCompound;
                TyreVisualCompound = statusStruct.m_tyreVisualCompound;
                TyresAgeLaps = statusStruct.m_tyresAgeLaps;
                VehicleFiaFlags = statusStruct.m_vehicleFiaFlags;
                ErsStoreEnergy = statusStruct.m_ersStoreEnergy;
                ErsDeployMode = statusStruct.m_ersDeployMode;
                ErsHarvestedThisLapMguk = statusStruct.m_ersHarvestedThisLapMGUK;
                ErsHarvestedThisLapMguh = statusStruct.m_ersHarvestedThisLapMGUH;
                ErsDeployedThisLap = statusStruct.m_ersDeployedThisLap;
                NetworkPaused = statusStruct.m_networkPaused;
            }
        }
    }
}
