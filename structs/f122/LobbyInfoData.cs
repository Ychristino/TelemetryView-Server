using System.Runtime.InteropServices;
using System.Text;
using System;

namespace TelemetryServer.Structs.f122
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct LobbyInfoDataStruct
    {
        public byte m_aiControlled; // Whether the vehicle is AI (1) or Human (0) controlled
        public byte m_teamId;       // Team id - see appendix (255 if no team currently selected)
        public byte m_nationality;  // Nationality of the driver
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
        public byte[] m_name;       // Name of participant in UTF-8 format – null terminated

        public byte m_readyStatus;  // 0 = not ready, 1 = ready, 2 = spectating

        public string GetName()
        {
            // Converte o array de bytes para string, tratando o terminador nulo
            int nullIndex = Array.IndexOf(m_name, (byte)0);
            return Encoding.UTF8.GetString(m_name, 0, nullIndex >= 0 ? nullIndex : m_name.Length);
        }
    }
}
