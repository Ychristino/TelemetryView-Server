using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TelemetryServer.Structs.f121;

namespace TelemetryServer.Classes.f121
{
    public class PacketLobbyInfoDataClass : HeaderClass
    {
        public byte NumPlayers { get; private set; }
        public List<LobbyInfoData> LobbyPlayers { get; private set; }

        public PacketLobbyInfoDataClass(PacketLobbyInfoDataStruct packetStruct) : base(packetStruct.m_header)
        {
            NumPlayers = packetStruct.m_numPlayers;
            LobbyPlayers = packetStruct.m_lobbyPlayers.Select(s => new LobbyInfoData(s)).ToList();
        }

        public class LobbyInfoData
        {
            public byte AiControlled { get; private set; }
            public byte TeamId { get; private set; }
            public byte Nationality { get; private set; }
            public string Name { get; private set; }
            public byte ReadyStatus { get; private set; }

            public LobbyInfoData(LobbyInfoDataStruct lobbyStruct)
            {
                AiControlled = lobbyStruct.m_aiControlled;
                TeamId = lobbyStruct.m_teamId;
                Nationality = lobbyStruct.m_nationality;
                int nullIndex = Array.IndexOf(lobbyStruct.m_name, (byte)0);
                Name = Encoding.UTF8.GetString(lobbyStruct.m_name, 0, nullIndex >= 0 ? nullIndex : lobbyStruct.m_name.Length);
                ReadyStatus = lobbyStruct.m_readyStatus;
            }
        }
    }
}
