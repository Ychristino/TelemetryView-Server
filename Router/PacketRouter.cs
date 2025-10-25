using System.Net;
using TelemetryServer.Processor;

namespace TelemetryServer.Router
{
    public class PacketRouter
    {
        private readonly Dictionary<(string Game, string Version), GameProcessor> processors;

        public PacketRouter()
        {
            processors = new Dictionary<(string Game, string Version), GameProcessor>();
            processors.Add(("F1", "2020"), new PacketProcessorF12020());
            // processors.Add(("F1", "2021"), new PacketProcessorF12021());
            // processors.Add(("F1", "2022"), new PacketProcessorF12022());
            // processors.Add(("F1", "2023"), new PacketProcessorF12023());
            // processors.Add(("F1", "2024"), new PacketProcessorF12024());
            // processors.Add(("F1", "2025"), new PacketProcessorF12025());
        }

        public void RoutePacket(IPEndPoint sender, byte[] data)
        {
            var (game, version) = GameIdentifier.IdentifyGame(data);
            if (processors.TryGetValue((game, version), out var processor))
            {
                processor.Process(sender, data);
            }
            else
            {
                Console.WriteLine($"Pacote do jogo {game} ({version}) não tem processador.");
            }
        }
    }
}