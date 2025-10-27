using System;
using System.Collections.Generic;
using TelemetryServer.Identifiers.f120;

namespace TelemetryServer.Processor
{
    public class FrameManager
    {
        private Dictionary<uint, FrameData> frames = new Dictionary<uint, FrameData>();
        private uint nextFrameIdentifierToProcess = 0;

        private HashSet<PacketTypeIdentifier> requiredPacketTypes;

        public event EventHandler<FrameData> OnFrameComplete;

        public FrameManager(HashSet<PacketTypeIdentifier> requiredPacketTypes)
        {
            this.requiredPacketTypes = requiredPacketTypes;
        }

        public void AddPacket(uint frameIdentifier, PacketTypeIdentifier packetType, object packet)
        {
            if (frameIdentifier < nextFrameIdentifierToProcess)
            {
                return;
            }

            if (!frames.ContainsKey(frameIdentifier))
            {
                frames[frameIdentifier] = new FrameData(frameIdentifier);
                if (frameIdentifier > nextFrameIdentifierToProcess)
                {
                    nextFrameIdentifierToProcess = frameIdentifier;
                }
            }

            if (!frames[frameIdentifier].Packets.ContainsKey(packetType))
            {
                frames[frameIdentifier].Packets[packetType] = packet;
            }

            ProcessReadyFrames();
        }

        private void ProcessReadyFrames()
        {
            for (uint i = nextFrameIdentifierToProcess; frames.ContainsKey(i); i--)
            {
                if (frames[i].IsComplete(requiredPacketTypes))
                {
                    OnFrameComplete?.Invoke(this, frames[i]);
                    frames.Remove(i);
                    nextFrameIdentifierToProcess++;
                }
            }

            CleanUpOldFrames();
        }

        private void CleanUpOldFrames()
        {
            var framesToRemove = new List<uint>();
            foreach (var frameId in frames.Keys)
            {
                if (frameId < nextFrameIdentifierToProcess - 100)
                {
                    framesToRemove.Add(frameId);
                }
            }

            foreach (var frameId in framesToRemove)
            {
                frames.Remove(frameId);
            }
        }
    }
}