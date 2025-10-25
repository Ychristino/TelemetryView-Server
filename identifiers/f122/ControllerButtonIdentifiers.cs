using System;
using System.Collections.Generic;

namespace TelemetryServer.Identifiers.f122
{
    [Flags]
    public enum ButtonFlags
    {
        None = 0x00000000,
        Cross = 0x00000001,
        Triangle = 0x00000002,
        Circle = 0x00000004,
        Square = 0x00000008,
        DPadLeft = 0x00000010,
        DPadRight = 0x00000020,
        DPadUp = 0x00000040,
        DPadDown = 0x00000080,
        OptionsOrMenu = 0x00000100,
        L1OrLB = 0x00000200,
        R1OrRB = 0x00000400,
        L2OrLT = 0x00000800,
        R2OrRT = 0x00001000,
        LeftStickClick = 0x00002000,
        RightStickClick = 0x00004000,
        RightStickLeft = 0x00008000,
        RightStickRight = 0x00010000,
        RightStickUp = 0x00020000,
        RightStickDown = 0x00040000,
        Special = 0x00080000,
        UdpAction1 = 0x00100000,
        UdpAction2 = 0x00200000,
        UdpAction3 = 0x00400000,
        UdpAction4 = 0x00800000,
        UdpAction5 = 0x01000000,
        UdpAction6 = 0x02000000,
        UdpAction7 = 0x04000000,
        UdpAction8 = 0x08000000,
        UdpAction9 = 0x10000000,
        UdpAction10 = 0x20000000,
        UdpAction11 = 0x40000000,
        // UdpAction12 = 0x80000000 // its throwing an exception... should we change the type? i believe its a overflow error when trying to make the conversion
    }

    public static class ControllerButtonIdentifier
    {
        public static List<string> IdentifyPressedButtons(uint buttonStatus)
        {
            var pressedButtons = new List<string>();
            var flags = (ButtonFlags)buttonStatus;

            if (flags.HasFlag(ButtonFlags.Cross)) pressedButtons.Add("Cross / A");
            if (flags.HasFlag(ButtonFlags.Triangle)) pressedButtons.Add("Triangle / Y");
            if (flags.HasFlag(ButtonFlags.Circle)) pressedButtons.Add("Circle / B");
            if (flags.HasFlag(ButtonFlags.Square)) pressedButtons.Add("Square / X");
            if (flags.HasFlag(ButtonFlags.DPadLeft)) pressedButtons.Add("D-pad Left");
            if (flags.HasFlag(ButtonFlags.DPadRight)) pressedButtons.Add("D-pad Right");
            if (flags.HasFlag(ButtonFlags.DPadUp)) pressedButtons.Add("D-pad Up");
            if (flags.HasFlag(ButtonFlags.DPadDown)) pressedButtons.Add("D-pad Down");
            if (flags.HasFlag(ButtonFlags.OptionsOrMenu)) pressedButtons.Add("Options / Menu");
            if (flags.HasFlag(ButtonFlags.L1OrLB)) pressedButtons.Add("L1 / LB");
            if (flags.HasFlag(ButtonFlags.R1OrRB)) pressedButtons.Add("R1 / RB");
            if (flags.HasFlag(ButtonFlags.L2OrLT)) pressedButtons.Add("L2 / LT");
            if (flags.HasFlag(ButtonFlags.R2OrRT)) pressedButtons.Add("R2 / RT");
            if (flags.HasFlag(ButtonFlags.LeftStickClick)) pressedButtons.Add("Left Stick Click");
            if (flags.HasFlag(ButtonFlags.RightStickClick)) pressedButtons.Add("Right Stick Click");
            if (flags.HasFlag(ButtonFlags.RightStickLeft)) pressedButtons.Add("Right Stick Left");
            if (flags.HasFlag(ButtonFlags.RightStickRight)) pressedButtons.Add("Right Stick Right");
            if (flags.HasFlag(ButtonFlags.RightStickUp)) pressedButtons.Add("Right Stick Up");
            if (flags.HasFlag(ButtonFlags.RightStickDown)) pressedButtons.Add("Right Stick Down");
            if (flags.HasFlag(ButtonFlags.Special)) pressedButtons.Add("Special");
            if (flags.HasFlag(ButtonFlags.UdpAction1)) pressedButtons.Add("UDP Action 1");
            if (flags.HasFlag(ButtonFlags.UdpAction2)) pressedButtons.Add("UDP Action 2");
            if (flags.HasFlag(ButtonFlags.UdpAction3)) pressedButtons.Add("UDP Action 3");
            if (flags.HasFlag(ButtonFlags.UdpAction4)) pressedButtons.Add("UDP Action 4");
            if (flags.HasFlag(ButtonFlags.UdpAction5)) pressedButtons.Add("UDP Action 5");
            if (flags.HasFlag(ButtonFlags.UdpAction6)) pressedButtons.Add("UDP Action 6");
            if (flags.HasFlag(ButtonFlags.UdpAction7)) pressedButtons.Add("UDP Action 7");
            if (flags.HasFlag(ButtonFlags.UdpAction8)) pressedButtons.Add("UDP Action 8");
            if (flags.HasFlag(ButtonFlags.UdpAction9)) pressedButtons.Add("UDP Action 9");
            if (flags.HasFlag(ButtonFlags.UdpAction10)) pressedButtons.Add("UDP Action 10");
            if (flags.HasFlag(ButtonFlags.UdpAction11)) pressedButtons.Add("UDP Action 11");
            // if (flags.HasFlag(ButtonFlags.UdpAction12)) pressedButtons.Add("UDP Action 12");

            return pressedButtons;
        }
    }
}
