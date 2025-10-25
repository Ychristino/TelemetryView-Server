using System.Runtime.InteropServices;

namespace TelemetryServer.Structs.f121
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketMotionDataStruct
    {
        public PacketHeaderStruct m_header;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public CarMotionDataStruct[] m_carMotionData;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] m_suspensionPosition;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] m_suspensionVelocity;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] m_suspensionAcceleration;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] m_wheelSpeed;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public float[] m_wheelSlip;

        public float m_localVelocityX;
        public float m_localVelocityY;
        public float m_localVelocityZ;
        public float m_angularVelocityX;
        public float m_angularVelocityY;
        public float m_angularVelocityZ;
        public float m_angularAccelerationX;
        public float m_angularAccelerationY;
        public float m_angularAccelerationZ;
        public float m_frontWheelsAngle;
    }
}
