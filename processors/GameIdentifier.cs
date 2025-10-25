namespace TelemetryServer
{
    public static class GameIdentifier
    {
        public static (string Game, string Version) IdentifyGame(byte[] data)
        {
            if (data.Length < 2)
            {
                return ("Desconhecido", "unknown");
            }

            // Lê os dois primeiros bytes (m_packetFormat) como um uint16 Little-Endian
            ushort packetFormat = BitConverter.ToUInt16(data, 0);

            switch (packetFormat)
            {
                case 2020:
                    return ("F1", "2020");
                case 2021:
                    return ("F1", "2021");
                case 2022:
                    return ("F1", "2022");
                case 2023:
                    return ("F1", "2023");
                case 2024:
                    return ("F1", "2024");
            }

            // Exemplo alternativo para outros jogos (pode ser impreciso)
            if (data.Length == 128)
            {
                return ("Assetto Corsa", "unknown");
            }

            return ("Desconhecido", "unknown");
        }
    }
}
