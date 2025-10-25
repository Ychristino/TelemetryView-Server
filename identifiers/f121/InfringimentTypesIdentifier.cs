using System.Collections.Generic;

namespace TelemetryServer.Identifiers.f121
{
    public enum InfringementId
    {
        BlockingBySlowDriving = 0,
        BlockingByWrongWayDriving = 1,
        ReversingOffStartLine = 2,
        BigCollision = 3,
        SmallCollision = 4,
        CollisionFailedToHandBackPositionSingle = 5,
        CollisionFailedToHandBackPositionMultiple = 6,
        CornerCuttingGainedTime = 7,
        CornerCuttingOvertakeSingle = 8,
        CornerCuttingOvertakeMultiple = 9,
        CrossedPitExitLane = 10,
        IgnoringBlueFlags = 11,
        IgnoringYellowFlags = 12,
        IgnoringDriveThrough = 13,
        TooManyDriveThroughs = 14,
        DriveThroughReminderServeWithinNLaps = 15,
        DriveThroughReminderServeThisLap = 16,
        PitLaneSpeeding = 17,
        ParkedForTooLong = 18,
        IgnoringTyreRegulations = 19,
        TooManyPenalties = 20,
        MultipleWarnings = 21,
        ApproachingDisqualification = 22,
        TyreRegulationsSelectSingle = 23,
        TyreRegulationsSelectMultiple = 24,
        LapInvalidatedCornerCutting = 25,
        LapInvalidatedRunningWide = 26,
        CornerCuttingRanWideGainedTimeMinor = 27,
        CornerCuttingRanWideGainedTimeSignificant = 28,
        CornerCuttingRanWideGainedTimeExtreme = 29,
        LapInvalidatedWallRiding = 30,
        LapInvalidatedFlashbackUsed = 31,
        LapInvalidatedResetToTrack = 32,
        BlockingThePitlane = 33,
        JumpStart = 34,
        SafetyCarToCarCollision = 35,
        SafetyCarIllegalOvertake = 36,
        SafetyCarExceedingAllowedPace = 37,
        VirtualSafetyCarExceedingAllowedPace = 38,
        FormationLapBelowAllowedSpeed = 39,
        RetiredMechanicalFailure = 40,
        RetiredTerminallyDamaged = 41,
        SafetyCarFallingTooFarBack = 42,
        BlackFlagTimer = 43,
        UnservedStopGoPenalty = 44,
        UnservedDriveThroughPenalty = 45,
        EngineComponentChange = 46,
        GearboxChange = 47,
        LeagueGridPenalty = 48,
        RetryPenalty = 49,
        IllegalTimeGain = 50,
        MandatoryPitstop = 51,
        Unknown = 255
    }

    public static class InfringementTypesIdentifier
    {
        private static readonly Dictionary<InfringementId, string> InfringementMeanings = new Dictionary<InfringementId, string>()
        {
            { InfringementId.BlockingBySlowDriving, "Blocking by slow driving" },
            { InfringementId.BlockingByWrongWayDriving, "Blocking by wrong way driving" },
            { InfringementId.ReversingOffStartLine, "Reversing off the start line" },
            { InfringementId.BigCollision, "Big Collision" },
            { InfringementId.SmallCollision, "Small Collision" },
            { InfringementId.CollisionFailedToHandBackPositionSingle, "Collision failed to hand back position single" },
            { InfringementId.CollisionFailedToHandBackPositionMultiple, "Collision failed to hand back position multiple" },
            { InfringementId.CornerCuttingGainedTime, "Corner cutting gained time" },
            { InfringementId.CornerCuttingOvertakeSingle, "Corner cutting overtake single" },
            { InfringementId.CornerCuttingOvertakeMultiple, "Corner cutting overtake multiple" },
            { InfringementId.CrossedPitExitLane, "Crossed pit exit lane" },
            { InfringementId.IgnoringBlueFlags, "Ignoring blue flags" },
            { InfringementId.IgnoringYellowFlags, "Ignoring yellow flags" },
            { InfringementId.IgnoringDriveThrough, "Ignoring drive through" },
            { InfringementId.TooManyDriveThroughs, "Too many drive throughs" },
            { InfringementId.DriveThroughReminderServeWithinNLaps, "Drive through reminder serve within n laps" },
            { InfringementId.DriveThroughReminderServeThisLap, "Drive through reminder serve this lap" },
            { InfringementId.PitLaneSpeeding, "Pit lane speeding" },
            { InfringementId.ParkedForTooLong, "Parked for too long" },
            { InfringementId.IgnoringTyreRegulations, "Ignoring tyre regulations" },
            { InfringementId.TooManyPenalties, "Too many penalties" },
            { InfringementId.MultipleWarnings, "Multiple warnings" },
            { InfringementId.ApproachingDisqualification, "Approaching disqualification" },
            { InfringementId.TyreRegulationsSelectSingle, "Tyre regulations select single" },
            { InfringementId.TyreRegulationsSelectMultiple, "Tyre regulations select multiple" },
            { InfringementId.LapInvalidatedCornerCutting, "Lap invalidated corner cutting" },
            { InfringementId.LapInvalidatedRunningWide, "Lap invalidated running wide" },
            { InfringementId.CornerCuttingRanWideGainedTimeMinor, "Corner cutting ran wide gained time minor" },
            { InfringementId.CornerCuttingRanWideGainedTimeSignificant, "Corner cutting ran wide gained time significant" },
            { InfringementId.CornerCuttingRanWideGainedTimeExtreme, "Corner cutting ran wide gained time extreme" },
            { InfringementId.LapInvalidatedWallRiding, "Lap invalidated wall riding" },
            { InfringementId.LapInvalidatedFlashbackUsed, "Lap invalidated flashback used" },
            { InfringementId.LapInvalidatedResetToTrack, "Lap invalidated reset to track" },
            { InfringementId.BlockingThePitlane, "Blocking the pitlane" },
            { InfringementId.JumpStart, "Jump start" },
            { InfringementId.SafetyCarToCarCollision, "Safety car to car collision" },
            { InfringementId.SafetyCarIllegalOvertake, "Safety car illegal overtake" },
            { InfringementId.SafetyCarExceedingAllowedPace, "Safety car exceeding allowed pace" },
            { InfringementId.VirtualSafetyCarExceedingAllowedPace, "Virtual safety car exceeding allowed pace" },
            { InfringementId.FormationLapBelowAllowedSpeed, "Formation lap below allowed speed" },
            { InfringementId.RetiredMechanicalFailure, "Retired mechanical failure" },
            { InfringementId.RetiredTerminallyDamaged, "Retired terminally damaged" },
            { InfringementId.SafetyCarFallingTooFarBack, "Safety car falling too far back" },
            { InfringementId.BlackFlagTimer, "Black flag timer" },
            { InfringementId.UnservedStopGoPenalty, "Unserved stop go penalty" },
            { InfringementId.UnservedDriveThroughPenalty, "Unserved drive through penalty" },
            { InfringementId.EngineComponentChange, "Engine component change" },
            { InfringementId.GearboxChange, "Gearbox change" },
            { InfringementId.LeagueGridPenalty, "League grid penalty" },
            { InfringementId.RetryPenalty, "Retry penalty" },
            { InfringementId.IllegalTimeGain, "Illegal time gain" },
            { InfringementId.MandatoryPitstop, "Mandatory pitstop" }
        };

        public static string GetInfringementMeaning(byte infringementId)
        {
            if (InfringementMeanings.TryGetValue((InfringementId)infringementId, out string infringementMeaning))
            {
                return infringementMeaning;
            }
            return "Infração Desconhecida";
        }
    }
}
