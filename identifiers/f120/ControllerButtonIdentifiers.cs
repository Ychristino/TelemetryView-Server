using System;
using System.Collections.Generic;

namespace TelemetryServer.Identifiers.f120
{
    [Flags]
    public enum ButtonFlags
    {
        None = 0x0000,
        Cross = 0x0001,
        Triangle = 0x0002,
        Circle = 0x0004,
        Square = 0x0008,
        DPadLeft = 0x0010,
        DPadRight = 0x0020,
        DPadUp = 0x0040,
        DPadDown = 0x0080,
        OptionsOrMenu = 0x0100,
        L1OrLB = 0x0200,
        R1OrRB = 0x0400,
        L2OrLT = 0x0800,
        R2OrRT = 0x1000,
        LeftStickClick = 0x2000,
        RightStickClick = 0x4000
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

            return pressedButtons;
        }
    }
}
