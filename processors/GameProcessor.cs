using System.Net;

namespace TelemetryServer.Processor
{
    public interface GameProcessor
    {
        void Process(IPEndPoint sender, byte[] data);
    }
}