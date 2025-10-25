using System.Runtime.InteropServices;
using System.Text;

namespace TelemetryServer.Structs.f120
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ParticipantDataStruct
    {
        public byte m_aiControlled;    // Whether the vehicle is AI (1) or Human (0) controlled
        public byte m_driverId;        // Driver id - see appendix
        public byte m_teamId;          // Team id - see appendix
        public byte m_raceNumber;      // Race number of the car
        public byte m_nationality;     // Nationality of the driver

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public byte[] m_name;          // Name of participant in UTF-8 format – null terminated

        public byte m_yourTelemetry;   // The player's UDP setting, 0 = restricted, 1 = public

        public string GetName()
        {
            // Converte o array de bytes para string, tratando o terminador nulo
            int nullIndex = Array.IndexOf(m_name, (byte)0);
            return Encoding.UTF8.GetString(m_name, 0, nullIndex >= 0 ? nullIndex : m_name.Length);
        }
    }
}
