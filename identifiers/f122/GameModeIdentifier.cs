using System.Collections.Generic;

namespace TelemetryServer.Identifiers.f122
{
    public enum GameModeId
    {
        EventMode = 0,
        GrandPrix = 3,
        TimeTrial = 5,
        Splitscreen = 6,
        OnlineCustom = 7,
        OnlineLeague = 8,
        CareerInvitational = 11,
        ChampionshipInvitational = 12,
        Championship = 13,
        OnlineChampionship = 14,
        OnlineWeeklyEvent = 15,
        Career22 = 19,
        Career22Online = 20,
        Benchmark = 127,
        Unknown = 255
    }

    public static class GameModeIdentifier
    {
        private static readonly Dictionary<GameModeId, string> GameModeNames = new Dictionary<GameModeId, string>()
        {
            { GameModeId.EventMode, "Event Mode" },
            { GameModeId.GrandPrix, "Grand Prix" },
            { GameModeId.TimeTrial, "Time Trial" },
            { GameModeId.Splitscreen, "Splitscreen" },
            { GameModeId.OnlineCustom, "Online Custom" },
            { GameModeId.OnlineLeague, "Online League" },
            { GameModeId.CareerInvitational, "Career Invitational" },
            { GameModeId.ChampionshipInvitational, "Championship Invitational" },
            { GameModeId.Championship, "Championship" },
            { GameModeId.OnlineChampionship, "Online Championship" },
            { GameModeId.OnlineWeeklyEvent, "Online Weekly Event" },
            { GameModeId.Career22, "Career ‘22" },
            { GameModeId.Career22Online, "Career ’22 Online" },
            { GameModeId.Benchmark, "Benchmark" }
        };

        public static string GetGameModeName(byte gameModeId)
        {
            if (GameModeNames.TryGetValue((GameModeId)gameModeId, out string gameModeName))
            {
                return gameModeName;
            }
            return "Modo de Jogo Desconhecido";
        }
    }
}
