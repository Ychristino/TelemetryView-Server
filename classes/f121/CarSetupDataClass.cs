using System.Collections.Generic;
using System.Linq;
using TelemetryServer.Structs.f121;
using TelemetryServer.Classes.f121;

namespace TelemetryServer.Classes.f121
{
    public class PacketCarSetupDataClass : HeaderClass
    {
        public List<CarSetupDataClass> CarSetups { get; private set; }

        public PacketCarSetupDataClass(PacketCarSetupDataStruct packetStruct) : base(packetStruct.m_header)
        {
            CarSetups = packetStruct.m_carSetups.Select(s => new CarSetupDataClass(s)).ToList();
        }

        public class CarSetupDataClass
        {
            public byte FrontWing { get; private set; }
            public byte RearWing { get; private set; }
            public byte OnThrottle { get; private set; }
            public byte OffThrottle { get; private set; }
            public float FrontCamber { get; private set; }
            public float RearCamber { get; private set; }
            public float FrontToe { get; private set; }
            public float RearToe { get; private set; }
            public byte FrontSuspension { get; private set; }
            public byte RearSuspension { get; private set; }
            public byte FrontAntiRollBar { get; private set; }
            public byte RearAntiRollBar { get; private set; }
            public byte FrontSuspensionHeight { get; private set; }
            public byte RearSuspensionHeight { get; private set; }
            public byte BrakePressure { get; private set; }
            public byte BrakeBias { get; private set; }
            public float RearLeftTyrePressure { get; private set; }
            public float RearRightTyrePressure { get; private set; }
            public float FrontLeftTyrePressure { get; private set; }
            public float FrontRightTyrePressure { get; private set; }
            public byte Ballast { get; private set; }
            public float FuelLoad { get; private set; }

            public CarSetupDataClass(CarSetupDataStruct setupStruct)
            {
                FrontWing = setupStruct.m_frontWing;
                RearWing = setupStruct.m_rearWing;
                OnThrottle = setupStruct.m_onThrottle;
                OffThrottle = setupStruct.m_offThrottle;
                FrontCamber = setupStruct.m_frontCamber;
                RearCamber = setupStruct.m_rearCamber;
                FrontToe = setupStruct.m_frontToe;
                RearToe = setupStruct.m_rearToe;
                FrontSuspension = setupStruct.m_frontSuspension;
                RearSuspension = setupStruct.m_rearSuspension;
                FrontAntiRollBar = setupStruct.m_frontAntiRollBar;
                RearAntiRollBar = setupStruct.m_rearAntiRollBar;
                FrontSuspensionHeight = setupStruct.m_frontSuspensionHeight;
                RearSuspensionHeight = setupStruct.m_rearSuspensionHeight;
                BrakePressure = setupStruct.m_brakePressure;
                BrakeBias = setupStruct.m_brakeBias;
                RearLeftTyrePressure = setupStruct.m_rearLeftTyrePressure;
                RearRightTyrePressure = setupStruct.m_rearRightTyrePressure;
                FrontLeftTyrePressure = setupStruct.m_frontLeftTyrePressure;
                FrontRightTyrePressure = setupStruct.m_frontRightTyrePressure;
                Ballast = setupStruct.m_ballast;
                FuelLoad = setupStruct.m_fuelLoad;
            }
        }
    }
}
