using TelemetryServer.Structs.f120;

namespace TelemetryServer.Classes.f120
{
    public class CarMotionDataClass
    {
        public float WorldPositionX { get; private set; }
        public float WorldPositionY { get; private set; }
        public float WorldPositionZ { get; private set; }
        public float WorldVelocityX { get; private set; }
        public float WorldVelocityY { get; private set; }
        public float WorldVelocityZ { get; private set; }
        public short WorldForwardDirX { get; private set; }
        public short WorldForwardDirY { get; private set; }
        public short WorldForwardDirZ { get; private set; }
        public short WorldRightDirX { get; private set; }
        public short WorldRightDirY { get; private set; }
        public short WorldRightDirZ { get; private set; }
        public float GForceLateral { get; private set; }
        public float GForceLongitudinal { get; private set; }
        public float GForceVertical { get; private set; }
        public float Yaw { get; private set; }
        public float Pitch { get; private set; }
        public float Roll { get; private set; }

        public CarMotionDataClass(CarMotionDataStruct motionStruct)
        {
            WorldPositionX = motionStruct.m_worldPositionX;
            WorldPositionY = motionStruct.m_worldPositionY;
            WorldPositionZ = motionStruct.m_worldPositionZ;
            WorldVelocityX = motionStruct.m_worldVelocityX;
            WorldVelocityY = motionStruct.m_worldVelocityY;
            WorldVelocityZ = motionStruct.m_worldVelocityZ;
            WorldForwardDirX = motionStruct.m_worldForwardDirX;
            WorldForwardDirY = motionStruct.m_worldForwardDirY;
            WorldForwardDirZ = motionStruct.m_worldForwardDirZ;
            WorldRightDirX = motionStruct.m_worldRightDirX;
            WorldRightDirY = motionStruct.m_worldRightDirY;
            WorldRightDirZ = motionStruct.m_worldRightDirZ;
            GForceLateral = motionStruct.m_gForceLateral;
            GForceLongitudinal = motionStruct.m_gForceLongitudinal;
            GForceVertical = motionStruct.m_gForceVertical;
            Yaw = motionStruct.m_yaw;
            Pitch = motionStruct.m_pitch;
            Roll = motionStruct.m_roll;
        }
    }
}
