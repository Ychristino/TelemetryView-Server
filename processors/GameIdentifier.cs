
namespace TelemetryServer
{
    public static class GameIdentifier
    {
        public static (string Game, string Version) IdentifyGame(byte[] data)
        {
            // Exemplo: F1 2020 (usado nas respostas anteriores)
            if (data.Length >= 2 && data[0] == 0xE4 && data[1] == 0x07)
            {
                return ("F1", "2020");
            }
            // F1 2024: O formato UDP 2024 usa um cabeçalho que começa com 0x07E8 (2024 em decimal).
            // A especificação da EA para F1 24 detalha o m_packetFormat como 2024.
            else if (data.Length >= 2 && data[0] == 0xE8 && data[1] == 0x07)
            {
                return ("F1", "2024");
            }
            // Assetto Corsa: O formato UDP usa uma estrutura diferente e um tamanho de pacote fixo.
            // A documentação indica pacotes de tamanho 128 bytes para certos tipos de dados.
            else if (data.Length == 128)
            {
                // A inspeção de mais bytes pode ser necessária para evitar falsos positivos
                return ("Assetto Corsa", "1.9");
            }
            // Outros jogos...

            return ("Desconhecido", "unknown");
        }
    }
}