using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using TelemetryServer.Structs.f121;
using TelemetryServer.Classes.f121;
using TelemetryServer.Identifiers.f121;
using TelemetryServer.Exporters.f121;
using TelemetryServer.Utilities;

namespace TelemetryServer.Processor.f121
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
        public event EventHandler<FrameData>? OnFrameComplete;

        private static readonly string _gameName = "F1_2021";
        private string? _trackName;
        private string? _sessionId;
        private Writer? _writer;
        private byte _currentLapNum;
        private bool _generatedConfigFile = false;
        private List<string> _driversName = new();
        private string _basicDataFileIdentifier = "Basic Data";
        private string _carDetailsFileIdentifier = "Car Details";

        private static HashSet<PacketTypeIdentifier> requiredPacketTypes = new HashSet<PacketTypeIdentifier>
        {
            PacketTypeIdentifier.MotionIdentifier,
            PacketTypeIdentifier.LapDataIdentifier,
            PacketTypeIdentifier.CarTelemetryIdentifier,
            PacketTypeIdentifier.CarStatusIdentifier
        };

        private readonly FrameManager frameManager;
        
        public PacketProcessorF12021()
        {
            frameManager = new FrameManager(requiredPacketTypes);
            frameManager.OnFrameComplete += OnFrameCompleteHandler;
        }

        private void OnFrameCompleteHandler(object? sender, FrameData frameData)
        {
            
            // The Packets 
            //      PacketTypeIdentifier.MotionIdentifier 
            //      PacketTypeIdentifier.LapDataIdentifier 
            //      PacketTypeIdentifier.CarTelemetryIdentifie 
            //      PacketTypeIdentifier.CarStatusIdentifier 
            // Are always available... to use other packtes you should validate the usage...

            Console.WriteLine($"✅ Frame completo recebido: {frameData.FrameIdentifier}");

            PacketMotionDataClass? motion = null;
            PacketSessionDataClass? session = null;
            PacketLapDataClass? lapData = null;
            PacketEventDataClass? eventData = null;
            PacketParticipantsDataClass? participants = null;
            PacketCarSetupDataClass? carSetup = null;
            PacketCarTelemetryDataClass? telemetry = null;
            PacketCarStatusDataClass? carStatus = null;
            PacketFinalClassificationDataClass? finalClassification = null;
            PacketLobbyInfoDataClass? lobbyInfo = null;
            PacketCarDamageDataClass? carDamage = null;
            PacketSessionHistoryDataClass? sessionHistory = null;
            
            if (frameData.Packets.TryGetValue(PacketTypeIdentifier.MotionIdentifier, out var motionObj))
                motion = motionObj as PacketMotionDataClass;

            if (frameData.Packets.TryGetValue(PacketTypeIdentifier.SessionIdentifier, out var sessionObj))
                session = sessionObj as PacketSessionDataClass;

            if (frameData.Packets.TryGetValue(PacketTypeIdentifier.LapDataIdentifier, out var lapDataObj))
                lapData = lapDataObj as PacketLapDataClass;

            if (frameData.Packets.TryGetValue(PacketTypeIdentifier.EventIdentifier, out var eventDataObj))
                eventData = eventDataObj as PacketEventDataClass;

            if (frameData.Packets.TryGetValue(PacketTypeIdentifier.ParticipantsIdentifier, out var participantsObj))
                participants = participantsObj as PacketParticipantsDataClass;

            if (frameData.Packets.TryGetValue(PacketTypeIdentifier.CarSetupsIdentifier, out var carSetupObj))
                carSetup = carSetupObj as PacketCarSetupDataClass;

            if (frameData.Packets.TryGetValue(PacketTypeIdentifier.CarTelemetryIdentifier, out var telemetryObj))
                telemetry = telemetryObj as PacketCarTelemetryDataClass;

            if (frameData.Packets.TryGetValue(PacketTypeIdentifier.CarStatusIdentifier, out var carStatusObj))
                carStatus = carStatusObj as PacketCarStatusDataClass;

            if (frameData.Packets.TryGetValue(PacketTypeIdentifier.FinalClassificationIdentifier, out var finalClassificationObj))
                finalClassification = finalClassificationObj as PacketFinalClassificationDataClass;

            if (frameData.Packets.TryGetValue(PacketTypeIdentifier.LobbyInfoIdentifier, out var lobbyInfoObj))
                lobbyInfo = lobbyInfoObj as PacketLobbyInfoDataClass;

            if (frameData.Packets.TryGetValue(PacketTypeIdentifier.CarDamageIdentifier, out var carDamageObj))
                carDamage = carDamageObj as PacketCarDamageDataClass;

            if (frameData.Packets.TryGetValue(PacketTypeIdentifier.SessionHistoryIdentifier, out var sessionHistoryObj))
                sessionHistory = sessionHistoryObj as PacketSessionHistoryDataClass;
            
            DataExporter _exporter = new DataExporter(motion, session, lapData, eventData, participants, carSetup, telemetry, carStatus, finalClassification, lobbyInfo, carDamage, sessionHistory);

            if (_writer != null)
            {
                if (!_generatedConfigFile)
                {
                    _writer.writeConfigurationLine($"{_exporter.exportConfigurationBasicData(_basicDataFileIdentifier)}" +
                                                   $"\n{_exporter.exportConfigurationDetailsData(_carDetailsFileIdentifier)}");
                    _generatedConfigFile = true;
                }
                _writer.WriteLine(_basicDataFileIdentifier, _sessionId, _driversName[telemetry.PlayerCarIndex], _currentLapNum, _exporter.exportBasicData(telemetry.PlayerCarIndex));
                _writer.WriteLine(_carDetailsFileIdentifier, _sessionId, _driversName[telemetry.PlayerCarIndex], _currentLapNum, _exporter.exportConfigurationDetailsData(telemetry.PlayerCarIndex));
            }

            OnFrameComplete?.Invoke(this, frameData);
        }
   
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

                        OnMotionPacketReceived?.Invoke(motionClass);
                        frameManager.AddPacket(motionClass.FrameIdentifier, PacketTypeIdentifier.MotionIdentifier, motionClass);
                        break;

                    case PacketTypeIdentifier.SessionIdentifier:
                        var sessionStruct = (PacketSessionDataStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketSessionDataStruct))!;
                        var sessionClass = new PacketSessionDataClass(sessionStruct);

                        OnSessionPacketReceived?.Invoke(sessionClass);
                        _trackName = TrackIdentifier.GetTrackName(sessionClass.TrackId);
                        _sessionId = sessionClass.SessionUID.ToString();
                        frameManager.AddPacket(sessionClass.FrameIdentifier, PacketTypeIdentifier.SessionIdentifier, sessionClass);
                        break;

                    case PacketTypeIdentifier.LapDataIdentifier:
                        var lapDataStruct = (PacketLapDataStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketLapDataStruct))!;
                        var lapDataClass = new PacketLapDataClass(lapDataStruct);

                        OnLapDataPacketReceived?.Invoke(lapDataClass);
                        _currentLapNum = lapDataClass.AllLapData[lapDataClass.PlayerCarIndex].CurrentLapNum;
                        frameManager.AddPacket(lapDataClass.FrameIdentifier, PacketTypeIdentifier.LapDataIdentifier, lapDataClass);
                        break;

                    case PacketTypeIdentifier.EventIdentifier:
                        var eventDataStruct = (PacketEventDataStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketEventDataStruct))!;
                        var eventDataClass = new PacketEventDataClass(eventDataStruct);

                        OnEventPacketReceived?.Invoke(eventDataClass);
                        frameManager.AddPacket(eventDataClass.FrameIdentifier, PacketTypeIdentifier.EventIdentifier, eventDataClass);
                        break;

                    case PacketTypeIdentifier.ParticipantsIdentifier:
                        var participantsStruct = (PacketParticipantsDataStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketParticipantsDataStruct))!;
                        var participantsClass = new PacketParticipantsDataClass(participantsStruct);

                        OnParticipantsPacketReceived?.Invoke(participantsClass);
                        frameManager.AddPacket(participantsClass.FrameIdentifier, PacketTypeIdentifier.ParticipantsIdentifier, participantsClass);
                        _driversName = participantsClass.Participants.Select(p => p.Name).ToList();
                        break;

                    case PacketTypeIdentifier.CarSetupsIdentifier:
                        var carSetupStruct = (PacketCarSetupDataStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketCarSetupDataStruct))!;
                        var carSetupClass = new PacketCarSetupDataClass(carSetupStruct);

                        OnCarSetupPacketReceived?.Invoke(carSetupClass);
                        frameManager.AddPacket(carSetupClass.FrameIdentifier, PacketTypeIdentifier.CarSetupsIdentifier, carSetupClass);
                        break;

                    case PacketTypeIdentifier.CarTelemetryIdentifier:
                        var telemetryStruct = (PacketCarTelemetryDataStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketCarTelemetryDataStruct))!;
                        var telemetryClass = new PacketCarTelemetryDataClass(telemetryStruct);

                        OnCarTelemetryPacketReceived?.Invoke(telemetryClass);
                        frameManager.AddPacket(telemetryClass.FrameIdentifier, PacketTypeIdentifier.CarTelemetryIdentifier, telemetryClass);
                        break;
                    case PacketTypeIdentifier.CarStatusIdentifier:
                        var carStatusStruct = (PacketCarStatusDataStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketCarStatusDataStruct))!;
                        var carStatusClass = new PacketCarStatusDataClass(carStatusStruct);

                        OnCarStatusPacketReceived?.Invoke(carStatusClass);
                        frameManager.AddPacket(carStatusClass.FrameIdentifier, PacketTypeIdentifier.CarStatusIdentifier, carStatusClass);
                        break;

                    case PacketTypeIdentifier.FinalClassificationIdentifier:
                        var finalClassificationStruct = (PacketFinalClassificationDataStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketFinalClassificationDataStruct))!;
                        var finalClassificationClass = new PacketFinalClassificationDataClass(finalClassificationStruct);

                        OnFinalClassificationPacketReceived?.Invoke(finalClassificationClass);
                        frameManager.AddPacket(finalClassificationClass.FrameIdentifier, PacketTypeIdentifier.FinalClassificationIdentifier, finalClassificationClass);
                        break;

                    case PacketTypeIdentifier.LobbyInfoIdentifier:
                        var lobbyInfoStruct = (PacketLobbyInfoDataStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketLobbyInfoDataStruct))!;
                        var lobbyInfoClass = new PacketLobbyInfoDataClass(lobbyInfoStruct);

                        OnLobbyInfoPacketReceived?.Invoke(lobbyInfoClass);
                        frameManager.AddPacket(lobbyInfoClass.FrameIdentifier, PacketTypeIdentifier.LobbyInfoIdentifier, lobbyInfoClass);
                        break;
                    case PacketTypeIdentifier.CarDamageIdentifier:
                        var carDamageStruct = (PacketCarDamageDataStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketCarDamageDataStruct))!;
                        var carDamageClass = new PacketCarDamageDataClass(carDamageStruct);

                        OnCarDamagePacketReceived?.Invoke(carDamageClass);
                        frameManager.AddPacket(carDamageClass.FrameIdentifier, PacketTypeIdentifier.CarDamageIdentifier, carDamageClass);
                        break;
                    case PacketTypeIdentifier.SessionHistoryIdentifier:
                        var sessionHistoryStruct = (PacketSessionHistoryDataStruct)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(PacketSessionHistoryDataStruct))!;
                        var sessionHistoryClass = new PacketSessionHistoryDataClass(sessionHistoryStruct);

                        OnSessionHistoryPacketReceived?.Invoke(sessionHistoryClass);
                        frameManager.AddPacket(sessionHistoryClass.FrameIdentifier, PacketTypeIdentifier.SessionHistoryIdentifier, sessionHistoryClass);
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
