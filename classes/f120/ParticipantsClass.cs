using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelemetryServer.Structs.f120;

namespace TelemetryServer.Classes.f120
{
    public class PacketParticipantsDataClass : HeaderClass
    {
        public byte NumActiveCars { get; private set; }
        public List<ParticipantDataClass> Participants { get; private set; }

        public PacketParticipantsDataClass(PacketParticipantsDataStruct packetStruct) : base(packetStruct.m_header)
        {
            NumActiveCars = packetStruct.m_numActiveCars;
            Participants = packetStruct.m_participants.Select(s => new ParticipantDataClass(s)).ToList();
        }

        public class ParticipantDataClass
        {
            public byte AiControlled { get; private set; }
            public byte DriverId { get; private set; }
            public byte TeamId { get; private set; }
            public byte RaceNumber { get; private set; }
            public byte Nationality { get; private set; }
            public string Name { get; private set; }
            public byte YourTelemetry { get; private set; }

            public ParticipantDataClass(ParticipantDataStruct participantStruct)
            {
                AiControlled = participantStruct.m_aiControlled;
                DriverId = participantStruct.m_driverId;
                TeamId = participantStruct.m_teamId;
                RaceNumber = participantStruct.m_raceNumber;
                Nationality = participantStruct.m_nationality;
                int nullIndex = Array.IndexOf(participantStruct.m_name, (byte)0);
                Name = Encoding.UTF8.GetString(participantStruct.m_name, 0, nullIndex >= 0 ? nullIndex : participantStruct.m_name.Length);
                YourTelemetry = participantStruct.m_yourTelemetry;
            }
        }
    }
}
