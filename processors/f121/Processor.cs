using System;
using System.Net;
using System.Runtime.InteropServices;
using TelemetryServer.Structs.f121;
using TelemetryServer.Classes.f121;
using TelemetryServer.Identifiers.f121;
using TelemetryServer.Utilities;

namespace TelemetryServer.Processor
{
    public class PacketProcessorF12021 : GameProcessor
    {
        public event Action<PacketMotionDataClass> OnMotionPacketReceived;
        public event Action<PacketSessionDataClass> OnSessionPacketReceived;
        public event Action<PacketLapDataClass> OnLapDataPacketReceived;
        public event Action<PacketEventDataClass> OnEventPacketReceived;
        public event Action<PacketParticipantsDataClass> OnParticipantsPacketReceived;
        public event Action<PacketCarSetupDataClass> OnCarSetupPacketReceived;
        public event Action<PacketCarTelemetryDataClass> OnCarTelemetryPacketReceived;
        public event Action<PacketCarStatusDataClass> OnCarStatusPacketReceived;
        public event Action<PacketFinalClassificationDataClass> OnFinalClassificationPacketReceived;
        public event Action<PacketLobbyInfoDataClass> OnLobbyInfoPacketReceived;
        public event Action<PacketCarDamageDataClass> OnCarDamagePacketReceived;
        public event Action<PacketSessionHistoryDataClass> OnSessionHistoryPacketReceived;

        private static readonly string _gameName = "F1_2021";
        private string? _trackName;
        private Writer? _writer;
        private byte _currentLapNum;

        private bool _motionConfigLoaded;
        private bool _sessionConfigLoaded;
        private bool _lapDataConfigLoaded;
        private bool _eventConfigLoaded;
        private bool _participantsConfigLoaded;
        private bool _carSetupConfigLoaded;
        private bool _carTelemetryConfigLoaded;
        private bool _carStatusConfigLoaded;
        private bool _finalClassificationConfigLoaded;
        private bool _lobbyInfoConfigLoaded;
        private bool _carDamageConfigLoaded;
        private bool _sessionHistoryConfigLoaded;

        public void Process(IPEndPoint sender, byte[] data)
        {
            if (data.Length < Marshal.SizeOf<PacketHeaderStruct>())
            {
                Console.WriteLine($"Pacote do F1 2021 de {sender.Address} é muito pequeno.");
                return;
            }

            var handle = GCHandle.Alloc(data, GCHandleType.Pinned);

            try
            {
                var headerStruct = (PacketHeaderStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketHeaderStruct))!;
                var packetType = (PacketTypeIdentifier)headerStruct.m_packetId;

                switch (packetType)
                {
                    case PacketTypeIdentifier.MotionIdentifier:
                        var motionStruct = (PacketMotionDataStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketMotionDataStruct))!;
                        var motionClass = new PacketMotionDataClass(motionStruct);
                        
                        // 🔹 Apenas na primeira vez
                        if (!_motionConfigLoaded)
                        {
                            // motionClass.getConfigurationFile();
                            _motionConfigLoaded = true;
                        }

                        OnMotionPacketReceived?.Invoke(motionClass);
                        break;

                    case PacketTypeIdentifier.SessionIdentifier:
                        var sessionStruct = (PacketSessionDataStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketSessionDataStruct))!;
                        var sessionClass = new PacketSessionDataClass(sessionStruct);

                        if (!_sessionConfigLoaded)
                        {
                            // sessionClass.getConfigurationFile();
                            _sessionConfigLoaded = true;
                        }

                        OnSessionPacketReceived?.Invoke(sessionClass);
                        _trackName = TrackIdentifier.GetTrackName(sessionClass.TrackId);
                        break;

                    case PacketTypeIdentifier.LapDataIdentifier:
                        var lapDataStruct = (PacketLapDataStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketLapDataStruct))!;
                        var lapDataClass = new PacketLapDataClass(lapDataStruct);

                        if (!_lapDataConfigLoaded)
                        {
                            // lapDataClass.getConfigurationFile();
                            _lapDataConfigLoaded = true;
                        }

                        OnLapDataPacketReceived?.Invoke(lapDataClass);
                        _currentLapNum = lapDataClass.AllLapData[lapDataClass.PlayerCarIndex].CurrentLapNum;
                        break;

                    case PacketTypeIdentifier.EventIdentifier:
                        var eventDataStruct = (PacketEventDataStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketEventDataStruct))!;
                        var eventDataClass = new PacketEventDataClass(eventDataStruct);

                        if (!_eventConfigLoaded)
                        {
                            // eventDataClass.getConfigurationFile();
                            _eventConfigLoaded = true;
                        }

                        OnEventPacketReceived?.Invoke(eventDataClass);
                        break;

                    case PacketTypeIdentifier.ParticipantsIdentifier:
                        var participantsStruct = (PacketParticipantsDataStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketParticipantsDataStruct))!;
                        var participantsClass = new PacketParticipantsDataClass(participantsStruct);

                        if (!_participantsConfigLoaded)
                        {
                            // participantsClass.getConfigurationFile();
                            _participantsConfigLoaded = true;
                        }

                        OnParticipantsPacketReceived?.Invoke(participantsClass);
                        break;

                    case PacketTypeIdentifier.CarSetupsIdentifier:
                        var carSetupStruct = (PacketCarSetupDataStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketCarSetupDataStruct))!;
                        var carSetupClass = new PacketCarSetupDataClass(carSetupStruct);

                        if (!_carSetupConfigLoaded)
                        {
                            // carSetupClass.getConfigurationFile();
                            _carSetupConfigLoaded = true;
                        }

                        OnCarSetupPacketReceived?.Invoke(carSetupClass);
                        break;

                    case PacketTypeIdentifier.CarTelemetryIdentifier:
                        var telemetryStruct = (PacketCarTelemetryDataStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketCarTelemetryDataStruct))!;
                        var telemetryClass = new PacketCarTelemetryDataClass(telemetryStruct);

                        OnCarTelemetryPacketReceived?.Invoke(telemetryClass);

                        if (_writer != null)
                        {
                            if (!_carTelemetryConfigLoaded)
                            {
                                _writer.writeConfigurationLine(telemetryClass.getConfigurationFile());
                                _carTelemetryConfigLoaded = true;
                            }
                            
                            _writer.WriteLine(PacketCarTelemetryDataClass.identifier, "Brum", _currentLapNum, telemetryClass.getCurrentStatus());
                        }
                        break;

                    case PacketTypeIdentifier.CarStatusIdentifier:
                        var carStatusStruct = (PacketCarStatusDataStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketCarStatusDataStruct))!;
                        var carStatusClass = new PacketCarStatusDataClass(carStatusStruct);

                        if (!_carStatusConfigLoaded)
                        {
                            // carStatusClass.getConfigurationFile();
                            _carStatusConfigLoaded = true;
                        }

                        OnCarStatusPacketReceived?.Invoke(carStatusClass);
                        break;

                    case PacketTypeIdentifier.FinalClassificationIdentifier:
                        var finalClassificationStruct = (PacketFinalClassificationDataStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketFinalClassificationDataStruct))!;
                        var finalClassificationClass = new PacketFinalClassificationDataClass(finalClassificationStruct);

                        if (!_finalClassificationConfigLoaded)
                        {
                            // finalClassificationClass.getConfigurationFile();
                            _finalClassificationConfigLoaded = true;
                        }

                        OnFinalClassificationPacketReceived?.Invoke(finalClassificationClass);
                        break;

                    case PacketTypeIdentifier.LobbyInfoIdentifier:
                        var lobbyInfoStruct = (PacketLobbyInfoDataStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketLobbyInfoDataStruct))!;
                        var lobbyInfoClass = new PacketLobbyInfoDataClass(lobbyInfoStruct);

                        if (!_lobbyInfoConfigLoaded)
                        {
                            // lobbyInfoClass.getConfigurationFile();
                            _lobbyInfoConfigLoaded = true;
                        }

                        OnLobbyInfoPacketReceived?.Invoke(lobbyInfoClass);
                        break;
                    case PacketTypeIdentifier.CarDamageIdentifier:
                        var carDamageStruct = (PacketCarDamageDataStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketCarDamageDataStruct))!;
                        var carDamageClass = new PacketCarDamageDataClass(carDamageStruct);

                        if (!_carDamageConfigLoaded)
                        {
                            // carDamageClass.getConfigurationFile();
                            _carDamageConfigLoaded = true;
                        }

                        OnCarDamagePacketReceived?.Invoke(carDamageClass);
                        break;
                    case PacketTypeIdentifier.SessionHistoryIdentifier:
                        var sessionHistoryStruct = (PacketSessionHistoryDataStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketSessionHistoryDataStruct))!;
                        var sessionHistoryClass = new PacketSessionHistoryDataClass(sessionHistoryStruct);

                        if (!_sessionHistoryConfigLoaded)
                        {
                            // sessionHistoryClass.getConfigurationFile();
                            _sessionHistoryConfigLoaded = true;
                        }

                        OnSessionHistoryPacketReceived?.Invoke(sessionHistoryClass);
                        break;
                    default:
                        Console.WriteLine($"Pacote de ID desconhecido ({packetType}) recebido de {sender.Address}.");
                        break;
                }

                if (_trackName != null && _writer == null)
                {
                    _writer = new Writer(_gameName, _trackName);
                }
            }
            finally
            {
                if (handle.IsAllocated)
                    handle.Free();
            }
        }
    }
}
