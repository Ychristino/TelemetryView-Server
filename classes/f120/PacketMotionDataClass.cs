using System.Runtime.InteropServices;
using TelemetryServer.Structs.f120;

namespace TelemetryServer.Classes.f120
{
    public class PacketMotionDataClass : HeaderClass
    {
        public CarMotionDataStruct[] CarMotionData { get; private set; }
        public float[] SuspensionPosition { get; private set; }
        public float[] SuspensionVelocity { get; private set; }
        public float[] SuspensionAcceleration { get; private set; }
        public float[] WheelSpeed { get; private set; }
        public float[] WheelSlip { get; private set; }
        public float LocalVelocityX { get; private set; }
        public float LocalVelocityY { get; private set; }
        public float LocalVelocityZ { get; private set; }
        public float AngularVelocityX { get; private set; }
        public float AngularVelocityY { get; private set; }
        public float AngularVelocityZ { get; private set; }
        public float AngularAccelerationX { get; private set; }
        public float AngularAccelerationY { get; private set; }
        public float AngularAccelerationZ { get; private set; }
        public float FrontWheelsAngle { get; private set; }

        public PacketMotionDataClass(PacketMotionDataStruct packetStruct) : base(packetStruct.m_header)
        {
            CarMotionData = packetStruct.m_carMotionData;
            SuspensionPosition = packetStruct.m_suspensionPosition;
            SuspensionVelocity = packetStruct.m_suspensionVelocity;
            SuspensionAcceleration = packetStruct.m_suspensionAcceleration;
            WheelSpeed = packetStruct.m_wheelSpeed;
            WheelSlip = packetStruct.m_wheelSlip;
            LocalVelocityX = packetStruct.m_localVelocityX;
            LocalVelocityY = packetStruct.m_localVelocityY;
            LocalVelocityZ = packetStruct.m_localVelocityZ;
            AngularVelocityX = packetStruct.m_angularVelocityX;
            AngularVelocityY = packetStruct.m_angularVelocityY;
            AngularVelocityZ = packetStruct.m_angularVelocityZ;
            AngularAccelerationX = packetStruct.m_angularAccelerationX;
            AngularAccelerationY = packetStruct.m_angularAccelerationY;
            AngularAccelerationZ = packetStruct.m_angularAccelerationZ;
            FrontWheelsAngle = packetStruct.m_frontWheelsAngle;
        }
    }
}
