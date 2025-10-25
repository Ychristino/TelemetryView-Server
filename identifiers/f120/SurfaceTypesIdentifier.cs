using System.Collections.Generic;

namespace TelemetryServer.Identifiers.f120
{
    public enum SurfaceType
    {
        Tarmac = 0,
        RumbleStrip = 1,
        Concrete = 2,
        Rock = 3,
        Gravel = 4,
        Mud = 5,
        Sand = 6,
        Grass = 7,
        Water = 8,
        Cobblestone = 9,
        Metal = 10,
        Ridged = 11,
        Unknown = 255 // Para tipos de superfície desconhecidos
    }

    public static class SurfaceTypesIdentifier
    {
        private static readonly Dictionary<SurfaceType, string> SurfaceNames = new Dictionary<SurfaceType, string>()
        {
            { SurfaceType.Tarmac, "Tarmac" },
            { SurfaceType.RumbleStrip, "Rumble strip" },
            { SurfaceType.Concrete, "Concrete" },
            { SurfaceType.Rock, "Rock" },
            { SurfaceType.Gravel, "Gravel" },
            { SurfaceType.Mud, "Mud" },
            { SurfaceType.Sand, "Sand" },
            { SurfaceType.Grass, "Grass" },
            { SurfaceType.Water, "Water" },
            { SurfaceType.Cobblestone, "Cobblestone" },
            { SurfaceType.Metal, "Metal" },
            { SurfaceType.Ridged, "Ridged" }
        };

        public static string GetSurfaceName(byte surfaceId)
        {
            if (SurfaceNames.TryGetValue((SurfaceType)surfaceId, out string surfaceName))
            {
                return surfaceName;
            }
            return "Superfície Desconhecida";
        }
    }
}
