using System.Collections.Generic;
using TelemetryServer.Identifiers.f121;
namespace TelemetryServer.Processor.f121
{
    public class FrameData
    {
        public uint FrameIdentifier { get; }
        public Dictionary<PacketTypeIdentifier, object> Packets { get; }

        public FrameData(uint frameIdentifier)
        {
            FrameIdentifier = frameIdentifier;
            Packets = new Dictionary<PacketTypeIdentifier, object>();
        }

        public bool IsComplete(HashSet<PacketTypeIdentifier> requiredPacketTypes)
        {
            foreach (var requiredType in requiredPacketTypes)
            {
                if (!Packets.ContainsKey(requiredType))
                {
                    return false;
                }
            }
            return true;
        }
    }
}