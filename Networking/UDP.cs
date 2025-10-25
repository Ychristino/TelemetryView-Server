using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace TelemetryServer.Networking
{
    public class UdpTelemetryServer
    {
        private readonly IPAddress _ipAddress;
        private readonly int _port;
        private readonly UdpClient _udpClient;
        private CancellationTokenSource? _cts;

        public event Action<IPEndPoint, byte[]>? OnDataReceived;

        public bool IsRunning { get; private set; }

        public UdpTelemetryServer(IPAddress ip, int port)
        {
            _ipAddress = ip;
            _port = port;
            _udpClient = new UdpClient(new IPEndPoint(_ipAddress, _port));
        }

        public async Task StartAsync()
        {
            if (IsRunning) return;
            IsRunning = true;
            _cts = new CancellationTokenSource();

            Console.WriteLine($"🟢 Servidor UDP iniciado em {_ipAddress}:{_port}");

            try
            {
                while (!_cts.Token.IsCancellationRequested)
                {
                    var result = await _udpClient.ReceiveAsync(_cts.Token);
                    OnDataReceived?.Invoke(result.RemoteEndPoint, result.Buffer);
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("🟡 Servidor UDP parado.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"🔴 Erro no servidor UDP: {ex.Message}");
            }
            finally
            {
                _udpClient.Close();
                IsRunning = false;
            }
        }

        public void Stop()
        {
            if (!IsRunning) return;

            Console.WriteLine("🛑 Parando servidor UDP...");
            _cts?.Cancel();
            IsRunning = false;
        }
    }
}
