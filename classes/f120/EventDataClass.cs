using System.Text;
using System.Runtime.InteropServices;
using TelemetryServer.Structs.f120;
using TelemetryServer.Identifiers.f120;

namespace TelemetryServer.Classes.f120
{
    public class PacketEventDataClass : HeaderClass
    {
        public string EventStringCode { get; private set; }
        public object EventDetails { get; private set; }

        public PacketEventDataClass(PacketEventDataStruct packetStruct) : base(packetStruct.m_header)
        {
            EventStringCode = Encoding.ASCII.GetString(packetStruct.m_eventStringCode);

            var eventType = EventIdentifier.IdentifyEvent(packetStruct.m_eventStringCode);

            switch (eventType)
            {
                case EventType.FastestLap:
                    EventDetails = new FastestLapEventClass(packetStruct.m_eventDetails.fastestLap);
                    break;
                case EventType.Retirement:
                    EventDetails = new RetirementEventClass(packetStruct.m_eventDetails.retirement);
                    break;
                case EventType.TeamMateInPits:
                    EventDetails = new TeamMateInPitsEventClass(packetStruct.m_eventDetails.teamMateInPits);
                    break;
                case EventType.RaceWinner:
                    EventDetails = new RaceWinnerEventClass(packetStruct.m_eventDetails.raceWinner);
                    break;
                case EventType.PenaltyIssued:
                    EventDetails = new PenaltyEventClass(packetStruct.m_eventDetails.penalty);
                    break;
                case EventType.SpeedTrapTriggered:
                    EventDetails = new SpeedTrapEventClass(packetStruct.m_eventDetails.speedTrap);
                    break;
                default:
                    EventDetails = null; 
                    break;
            }
        }
    }
}
