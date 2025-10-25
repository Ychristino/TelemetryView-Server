using System.Collections.Generic;

namespace TelemetryServer.Identifiers.f120
{
    public enum TeamId
    {
        Mercedes = 0,
        Ferrari = 1,
        RedBullRacing = 2,
        Williams = 3,
        RacingPoint = 4,
        Renault = 5,
        AlphaTauri = 6,
        Haas = 7,
        McLaren = 8,
        AlfaRomeo = 9,
        McLaren1988 = 10,
        McLaren1991 = 11,
        Williams1992 = 12,
        Ferrari1995 = 13,
        Williams1996 = 14,
        McLaren1998 = 15,
        Ferrari2002 = 16,
        Ferrari2004 = 17,
        Renault2006 = 18,
        Ferrari2007 = 19,
        McLaren2008 = 20,
        RedBull2010 = 21,
        McLaren1990 = 31,
        Williams2003 = 38,
        Brawn2009 = 39,
        F1GenericCar = 41,
        ArtGrandPrix = 42,
        CamposRacing = 43,
        Carlin = 44,
        SauberJuniorTeamByCharouz = 45,
        Dams = 46,
        UniVirtuosi = 47,
        MpMotorsport = 48,
        PremaRacing = 49,
        Trident = 50,
        BwtArden = 51,
        Benetton1994 = 53,
        Benetton1995 = 54,
        Ferrari2000 = 55,
        Jordan1991 = 56,
        Ferrari1990 = 63,
        McLaren2010 = 64,
        Ferrari2010 = 65,
        MyTeam = 255
    }

    public static class TeamIdentifier
    {
        private static readonly Dictionary<TeamId, string> TeamNames = new Dictionary<TeamId, string>()
        {
            { TeamId.Mercedes, "Mercedes" },
            { TeamId.Ferrari, "Ferrari" },
            { TeamId.RedBullRacing, "Red Bull Racing" },
            { TeamId.Williams, "Williams" },
            { TeamId.RacingPoint, "Racing Point" },
            { TeamId.Renault, "Renault" },
            { TeamId.AlphaTauri, "AlphaTauri" },
            { TeamId.Haas, "Haas" },
            { TeamId.McLaren, "McLaren" },
            { TeamId.AlfaRomeo, "Alfa Romeo" },
            { TeamId.McLaren1988, "McLaren 1988" },
            { TeamId.McLaren1991, "McLaren 1991" },
            { TeamId.Williams1992, "Williams 1992" },
            { TeamId.Ferrari1995, "Ferrari 1995" },
            { TeamId.Williams1996, "Williams 1996" },
            { TeamId.McLaren1998, "McLaren 1998" },
            { TeamId.Ferrari2002, "Ferrari 2002" },
            { TeamId.Ferrari2004, "Ferrari 2004" },
            { TeamId.Renault2006, "Renault 2006" },
            { TeamId.Ferrari2007, "Ferrari 2007" },
            { TeamId.McLaren2008, "McLaren 2008" },
            { TeamId.RedBull2010, "Red Bull 2010" },
            { TeamId.McLaren1990, "McLaren 1990" },
            { TeamId.Williams2003, "Williams 2003" },
            { TeamId.Brawn2009, "Brawn 2009" },
            { TeamId.F1GenericCar, "F1 Generic car" },
            { TeamId.ArtGrandPrix, "ART Grand Prix" },
            { TeamId.CamposRacing, "Campos Racing" },
            { TeamId.Carlin, "Carlin" },
            { TeamId.SauberJuniorTeamByCharouz, "Sauber Junior Team by Charouz" },
            { TeamId.Dams, "DAMS" },
            { TeamId.UniVirtuosi, "UNI-Virtuosi" },
            { TeamId.MpMotorsport, "MP Motorsport" },
            { TeamId.PremaRacing, "PREMA Racing" },
            { TeamId.Trident, "Trident" },
            { TeamId.BwtArden, "BWT Arden" },
            { TeamId.Benetton1994, "Benetton 1994" },
            { TeamId.Benetton1995, "Benetton 1995" },
            { TeamId.Ferrari2000, "Ferrari 2000" },
            { TeamId.Jordan1991, "Jordan 1991" },
            { TeamId.Ferrari1990, "Ferrari 1990" },
            { TeamId.McLaren2010, "McLaren 2010" },
            { TeamId.Ferrari2010, "Ferrari 2010" },
            { TeamId.MyTeam, "My Team" }
        };

        public static string GetTeamName(byte teamId)
        {
            if (TeamNames.TryGetValue((TeamId)teamId, out string teamName))
            {
                return teamName;
            }
            return "Equipe Desconhecida";
        }
    }
}
