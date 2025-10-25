using System.Collections.Generic;
using System.Linq;
using TelemetryServer.Structs.f122;
using TelemetryServer.Classes.f122; 

namespace TelemetryServer.Classes.f122
{
    public class PacketCarDamageDataClass : HeaderClass
    {
        public List<CarDamageDataClass> CarDamageData { get; private set; }

        public PacketCarDamageDataClass(PacketCarDamageDataStruct packetStruct) : base(packetStruct.m_header)
        {
            CarDamageData = packetStruct.m_carDamageData.Select(s => new CarDamageDataClass(s)).ToList();
        }

        public class CarDamageDataClass
        {
            public float[] TyresWear { get; private set; }
            public byte[] TyresDamage { get; private set; }
            public byte[] BrakesDamage { get; private set; }
            public byte FrontLeftWingDamage { get; private set; }
            public byte FrontRightWingDamage { get; private set; }
            public byte RearWingDamage { get; private set; }
            public byte FloorDamage { get; private set; }
            public byte DiffuserDamage { get; private set; }
            public byte SidepodDamage { get; private set; }
            public byte DrsFault { get; private set; }
            public byte GearBoxDamage { get; private set; }
            public byte EngineDamage { get; private set; }
            public byte EngineMGUHWear { get; private set; }
            public byte EngineESWear { get; private set; }
            public byte EngineCEWear { get; private set; }
            public byte EngineICEWear { get; private set; }
            public byte EngineMGUKWear { get; private set; }
            public byte EngineTCWear { get; private set; }
            public byte EngineBlown { get; private set; }
            public byte EngineSeized { get; private set; }

            public CarDamageDataClass(CarDamageDataStruct setupStruct)
            {
                TyresWear = setupStruct.m_tyresWear;
                TyresDamage = setupStruct.m_tyresDamage;
                BrakesDamage = setupStruct.m_brakesDamage;
                FrontLeftWingDamage = setupStruct.m_frontLeftWingDamage;
                FrontRightWingDamage = setupStruct.m_frontRightWingDamage;
                RearWingDamage = setupStruct.m_rearWingDamage;
                FloorDamage = setupStruct.m_floorDamage;
                DiffuserDamage = setupStruct.m_diffuserDamage;
                SidepodDamage = setupStruct.m_sidepodDamage;
                DrsFault = setupStruct.m_drsFault;
                GearBoxDamage = setupStruct.m_gearBoxDamage;
                EngineDamage = setupStruct.m_engineDamage;
                EngineMGUHWear = setupStruct.m_engineMGUHWear;
                EngineESWear = setupStruct.m_engineESWear;
                EngineCEWear = setupStruct.m_engineCEWear;
                EngineICEWear = setupStruct.m_engineICEWear;
                EngineMGUKWear = setupStruct.m_engineMGUKWear;
                EngineTCWear = setupStruct.m_engineTCWear;
                EngineBlown = setupStruct.m_engineBlown;
                EngineSeized = setupStruct.m_engineSeized;
            }
        }
    }
}
