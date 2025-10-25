using System.Runtime.InteropServices;

namespace TelemetryServer.Structs.f122
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketLobbyInfoDataStruct
    {
        public PacketHeaderStruct m_header;

        public byte m_numPlayers; // Number of players in the lobby data
        
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public LobbyInfoDataStruct[] m_lobbyPlayers;
    }
}
