using System.Collections.Generic;

namespace TelemetryServer.Identifiers.f121
{
    public enum PenaltyId
    {
        DriveThrough = 0,
        StopGo = 1,
        GridPenalty = 2,
        PenaltyReminder = 3,
        TimePenalty = 4,
        Warning = 5,
        Disqualified = 6,
        RemovedFromFormationLap = 7,
        ParkedTooLongTimer = 8,
        TyreRegulations = 9,
        ThisLapInvalidated = 10,
        ThisAndNextLapInvalidated = 11,
        ThisLapInvalidatedWithoutReason = 12,
        ThisAndNextLapInvalidatedWithoutReason = 13,
        ThisAndPreviousLapInvalidated = 14,
        ThisAndPreviousLapInvalidatedWithoutReason = 15,
        Retired = 16,
        BlackFlagTimer = 17,
        Unknown = 255
    }

    public static class PenaltyTypesIdentifier
    {
        private static readonly Dictionary<PenaltyId, string> PenaltyMeanings = new Dictionary<PenaltyId, string>()
        {
            { PenaltyId.DriveThrough, "Drive through" },
            { PenaltyId.StopGo, "Stop Go" },
            { PenaltyId.GridPenalty, "Grid penalty" },
            { PenaltyId.PenaltyReminder, "Penalty reminder" },
            { PenaltyId.TimePenalty, "Time penalty" },
            { PenaltyId.Warning, "Warning" },
            { PenaltyId.Disqualified, "Disqualified" },
            { PenaltyId.RemovedFromFormationLap, "Removed from formation lap" },
            { PenaltyId.ParkedTooLongTimer, "Parked too long timer" },
            { PenaltyId.TyreRegulations, "Tyre regulations" },
            { PenaltyId.ThisLapInvalidated, "This lap invalidated" },
            { PenaltyId.ThisAndNextLapInvalidated, "This and next lap invalidated" },
            { PenaltyId.ThisLapInvalidatedWithoutReason, "This lap invalidated without reason" },
            { PenaltyId.ThisAndNextLapInvalidatedWithoutReason, "This and next lap invalidated without reason" },
            { PenaltyId.ThisAndPreviousLapInvalidated, "This and previous lap invalidated" },
            { PenaltyId.ThisAndPreviousLapInvalidatedWithoutReason, "This and previous lap invalidated without reason" },
            { PenaltyId.Retired, "Retired" },
            { PenaltyId.BlackFlagTimer, "Black flag timer" }
        };

        public static string GetPenaltyMeaning(byte penaltyId)
        {
            if (PenaltyMeanings.TryGetValue((PenaltyId)penaltyId, out string penaltyMeaning))
            {
                return penaltyMeaning;
            }
            return "Penalidade Desconhecida";
        }
    }
}
