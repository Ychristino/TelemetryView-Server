using TelemetryServer.Structs.f122;

namespace TelemetryServer.Classes.f122
{
    public class HeaderClass
    {
        public ushort PacketFormat { get; set; }
        public byte GameMajorVersion { get; set; }
        public byte GameMinorVersion { get; set; }
        public byte PacketVersion { get; set; }
        public byte PacketId { get; set; }
        public ulong SessionUID { get; set; }
        public float SessionTime { get; set; }
        public uint FrameIdentifier { get; set; }
        public byte PlayerCarIndex { get; set; }
        public byte SecondaryPlayerCarIndex { get; set; }

        public HeaderClass(PacketHeaderStruct headerStruct)
        {
            PacketFormat = headerStruct.m_packetFormat;
            GameMajorVersion = headerStruct.m_gameMajorVersion;
            GameMinorVersion = headerStruct.m_gameMinorVersion;
            PacketVersion = headerStruct.m_packetVersion;
            PacketId = headerStruct.m_packetId;
            SessionUID = headerStruct.m_sessionUID;
            SessionTime = headerStruct.m_sessionTime;
            FrameIdentifier = headerStruct.m_frameIdentifier;
            PlayerCarIndex = headerStruct.m_playerCarIndex;
            SecondaryPlayerCarIndex = headerStruct.m_secondaryPlayerCarIndex;
        }

        public HeaderClass() { }
    }
}
