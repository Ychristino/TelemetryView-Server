using TelemetryServer.Structs.f121;

namespace TelemetryServer.Classes.f121
{
    public class MarshalZoneClass
    {
        public float ZoneStart { get; private set; }
        public sbyte ZoneFlag { get; private set; }

        public MarshalZoneClass(MarshalZoneStruct structData)
        {
            ZoneStart = structData.m_zoneStart;
            ZoneFlag = structData.m_zoneFlag;
        }
    }
}