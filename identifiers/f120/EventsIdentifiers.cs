using System;
using System.Text;

namespace TelemetryServer.Identifiers.f120
{
    public enum EventType
    {
        SessionStarted,
        SessionEnded,
        FastestLap,
        Retirement,
        DrsEnabled,
        DrsDisabled,
        TeamMateInPits,
        ChequeredFlag,
        RaceWinner,
        PenaltyIssued,
        SpeedTrapTriggered,
        Unknown
    }


    public static class EventIdentifier
    {
        public static EventType IdentifyEvent(byte[] eventCodeBytes)
        {
            if (eventCodeBytes == null || eventCodeBytes.Length != 4)
            {
                return EventType.Unknown;
            }

            string eventCode = Encoding.ASCII.GetString(eventCodeBytes);

            switch (eventCode)
            {
                case "SSTA":
                    return EventType.SessionStarted;
                case "SEND":
                    return EventType.SessionEnded;
                case "FTLP":
                    return EventType.FastestLap;
                case "RTMT":
                    return EventType.Retirement;
                case "DRSE":
                    return EventType.DrsEnabled;
                case "DRSD":
                    return EventType.DrsDisabled;
                case "TMPT":
                    return EventType.TeamMateInPits;
                case "CHQF":
                    return EventType.ChequeredFlag;
                case "RCWN":
                    return EventType.RaceWinner;
                case "PENA":
                    return EventType.PenaltyIssued;
                case "SPTP":
                    return EventType.SpeedTrapTriggered;
                default:
                    return EventType.Unknown;
            }
        }
    }
}
