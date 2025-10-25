using System.Runtime.InteropServices;

namespace TelemetryServer.Structs.f120
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PacketCarTelemetryDataStruct
    {
        public PacketHeaderStruct m_header;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
        public CarTelemetryDataStruct[] m_carTelemetryData;

        public uint m_buttonStatus;        // Bit flags specifying which buttons are being pressed
        public byte m_mfdPanelIndex;       // Index of MFD panel open - 255 = MFD closed
        public byte m_mfdPanelIndexSecondaryPlayer;   // See above
        public sbyte m_suggestedGear;       // Suggested gear for the player (1-8)
                                            // 0 if no gear suggested
    }
}
