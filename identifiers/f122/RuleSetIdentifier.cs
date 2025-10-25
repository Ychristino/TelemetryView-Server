using System.Collections.Generic;

namespace TelemetryServer.Identifiers.f122
{
    public enum RuleSetId
    {
        PracticeAndQualifying = 0,
        Race = 1,
        TimeTrial = 2,
        TimeAttack = 4,
        CheckpointChallenge = 6,
        Autocross = 8,
        Drift = 9,
        AverageSpeedZone = 10,
        RivalDuel = 11,
        Unknown = 255
    }

    public static class RuleSetIdentifier
    {
        private static readonly Dictionary<RuleSetId, string> RuleSetNames = new Dictionary<RuleSetId, string>()
        {
            { RuleSetId.PracticeAndQualifying, "Practice & Qualifying" },
            { RuleSetId.Race, "Race" },
            { RuleSetId.TimeTrial, "Time Trial" },
            { RuleSetId.TimeAttack, "Time Attack" },
            { RuleSetId.CheckpointChallenge, "Checkpoint Challenge" },
            { RuleSetId.Autocross, "Autocross" },
            { RuleSetId.Drift, "Drift" },
            { RuleSetId.AverageSpeedZone, "Average Speed Zone" },
            { RuleSetId.RivalDuel, "Rival Duel" }
        };

        public static string GetRuleSetName(byte ruleSetId)
        {
            if (RuleSetNames.TryGetValue((RuleSetId)ruleSetId, out string ruleSetName))
            {
                return ruleSetName;
            }
            return "Conjunto de Regras Desconhecido";
        }
    }
}
