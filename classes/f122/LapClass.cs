using System.Collections.Generic;
using System.Linq;
using TelemetryServer.Structs.f122;

namespace TelemetryServer.Classes.f122
{
    public class PacketLapDataClass : HeaderClass
    {
        public List<LapDataClass> AllLapData { get; private set; }
        public byte TimeTrialPBCarIdx;
        public byte TimeTrialRivalCarIdx;

        public PacketLapDataClass(PacketLapDataStruct packetStruct) : base(packetStruct.m_header)
        {
            AllLapData = packetStruct.m_lapData.Select(s => new LapDataClass(s)).ToList();
            TimeTrialPBCarIdx = packetStruct.m_timeTrialPBCarIdx;
            TimeTrialRivalCarIdx = packetStruct.m_timeTrialRivalCarIdx;
        }

        public class LapDataClass
        {
            public float LastLapTime { get; private set; }
            public float CurrentLapTime { get; private set; }
            public ushort Sector1TimeInMS { get; private set; }
            public ushort Sector2TimeInMS { get; private set; }
            public float LapDistance { get; private set; }
            public float TotalDistance { get; private set; }
            public float SafetyCarDelta { get; private set; }
            public byte CarPosition { get; private set; }
            public byte CurrentLapNum { get; private set; }
            public byte PitStatus { get; private set; }
            public byte NumPitStops { get; private set; }
            public byte Sector { get; private set; }
            public byte CurrentLapInvalid { get; private set; }
            public byte Penalties { get; private set; }
            public byte Warnings { get; private set; }
            public byte NumUnservedDriveThroughPens { get; private set; }
            public byte NumUnservedStopGoPens { get; private set; }
            public byte GridPosition { get; private set; }
            public byte DriverStatus { get; private set; }
            public byte ResultStatus { get; private set; }
            public byte PitLaneTimerActive { get; private set; }
            public ushort PitLaneTimeInLaneInMS { get; private set; }
            public ushort PitStopTimerInMS { get; private set; }
            public byte PitStopShouldServePen { get; private set; }

            public LapDataClass(LapDataStruct lapDataStruct)
            {
                LastLapTime =lapDataStruct.m_lastLapTime;
                CurrentLapTime =lapDataStruct.m_currentLapTime;
                Sector1TimeInMS =lapDataStruct.m_sector1TimeInMS;
                Sector2TimeInMS =lapDataStruct.m_sector2TimeInMS;
                LapDistance =lapDataStruct.m_lapDistance;
                TotalDistance =lapDataStruct.m_totalDistance;
                SafetyCarDelta =lapDataStruct.m_safetyCarDelta;
                CarPosition =lapDataStruct.m_carPosition;
                CurrentLapNum =lapDataStruct.m_currentLapNum;
                PitStatus =lapDataStruct.m_pitStatus;
                NumPitStops =lapDataStruct.m_numPitStops;
                Sector =lapDataStruct.m_sector;
                CurrentLapInvalid =lapDataStruct.m_currentLapInvalid;
                Penalties =lapDataStruct.m_penalties;
                Warnings =lapDataStruct.m_warnings;
                NumUnservedDriveThroughPens =lapDataStruct.m_numUnservedDriveThroughPens;
                NumUnservedStopGoPens =lapDataStruct.m_numUnservedStopGoPens;
                GridPosition =lapDataStruct.m_gridPosition;
                DriverStatus =lapDataStruct.m_driverStatus;
                ResultStatus =lapDataStruct.m_resultStatus;
                PitLaneTimerActive =lapDataStruct.m_pitLaneTimerActive;
                PitLaneTimeInLaneInMS =lapDataStruct.m_pitLaneTimeInLaneInMS;
                PitStopTimerInMS =lapDataStruct.m_pitStopTimerInMS;
                PitStopShouldServePen =lapDataStruct.m_pitStopShouldServePen;
            }
        }
    }
}
