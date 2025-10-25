using System.Collections.Generic;

namespace TelemetryServer.Identifiers.f122
{
    public enum TrackId
    {
        Melbourne = 0,
        PaulRicard = 1,
        Shanghai = 2,
        SakhirBahrain = 3,
        Catalunya = 4,
        Monaco = 5,
        Montreal = 6,
        Silverstone = 7,
        Hockenheim = 8,
        Hungaroring = 9,
        Spa = 10,
        Monza = 11,
        Singapore = 12,
        Suzuka = 13,
        AbuDhabi = 14,
        Texas = 15,
        Brazil = 16,
        Austria = 17,
        Sochi = 18,
        Mexico = 19,
        BakuAzerbaijan = 20,
        SakhirShort = 21,
        SilverstoneShort = 22,
        TexasShort = 23,
        SuzukaShort = 24,
        Hanoi = 25,
        Zandvoort = 26,
        Imola = 27,
        Portimao = 28,
        Jeddah = 29,
        Miami = 30,
        Unknown = 255 // Para IDs desconhecidos ou inválidos
    }

    public static class TrackIdentifier
    {
        private static readonly Dictionary<TrackId, string> TrackNames = new Dictionary<TrackId, string>()
        {
            { TrackId.Melbourne, "Melbourne" },
            { TrackId.PaulRicard, "Paul Ricard" },
            { TrackId.Shanghai, "Shanghai" },
            { TrackId.SakhirBahrain, "Sakhir (Bahrain)" },
            { TrackId.Catalunya, "Catalunya" },
            { TrackId.Monaco, "Monaco" },
            { TrackId.Montreal, "Montreal" },
            { TrackId.Silverstone, "Silverstone" },
            { TrackId.Hockenheim, "Hockenheim" },
            { TrackId.Hungaroring, "Hungaroring" },
            { TrackId.Spa, "Spa" },
            { TrackId.Monza, "Monza" },
            { TrackId.Singapore, "Singapore" },
            { TrackId.Suzuka, "Suzuka" },
            { TrackId.AbuDhabi, "Abu Dhabi" },
            { TrackId.Texas, "Texas" },
            { TrackId.Brazil, "Brazil" },
            { TrackId.Austria, "Austria" },
            { TrackId.Sochi, "Sochi" },
            { TrackId.Mexico, "Mexico" },
            { TrackId.BakuAzerbaijan, "Baku (Azerbaijan)" },
            { TrackId.SakhirShort, "Sakhir Short" },
            { TrackId.SilverstoneShort, "Silverstone Short" },
            { TrackId.TexasShort, "Texas Short" },
            { TrackId.SuzukaShort, "Suzuka Short" },
            { TrackId.Hanoi, "Hanoi" },
            { TrackId.Zandvoort, "Zandvoort" },
            { TrackId.Imola, "Imola" },
            { TrackId.Portimao, "Portimão" },
            { TrackId.Jeddah, "Jeddah" },
            { TrackId.Miami, "Miami" }
        };

        public static string GetTrackName(int trackId)
        {
            if (TrackNames.TryGetValue((TrackId)trackId, out string trackName))
            {
                return trackName;
            }
            return "Pista Desconhecida";
        }
    }
}
