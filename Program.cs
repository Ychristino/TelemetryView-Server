using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using TelemetryServer.Networking;
using TelemetryServer.Router;

namespace TelemetryServer
{
    internal class Program
    {
        static async Task Main()
        {
            var server = new UdpTelemetryServer(IPAddress.Any, 20777);
            var router = new PacketRouter(); 
            
            using var cts = new CancellationTokenSource();

            Console.CancelKeyPress += (sender, e) =>
            {
                Console.WriteLine("\n🛑 Sinal de interrupção recebido (Ctrl+C). Encerrando...");
                e.Cancel = true;
                cts.Cancel();
            };

            AppDomain.CurrentDomain.ProcessExit += (sender, e) =>
            {
                Console.WriteLine("\n🟡 Processo está sendo encerrado...");
                cts.Cancel();
            };

            server.OnDataReceived += (IPEndPoint sender, byte[] data) =>
            {
                Console.WriteLine($"Pacote recebido de: {sender.Address}:{sender.Port}");
                try
                {
                    router.RoutePacket(sender, data);
                }
                catch (Exception)
                {
                    Console.WriteLine("Packet will be ignored!");
                }
            };

            var serverTask = server.StartAsync();

            try
            {
                await Task.WhenAny(serverTask, WaitForCancellation(cts.Token));
            }
            finally
            {
                server.Stop();
                Console.WriteLine("✅ Servidor encerrado com segurança.");
            }
        }

        static async Task WaitForCancellation(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
                await Task.Delay(100, token);
        }
    }
}
