using System;

namespace RoboticArm535Library
{
    [Flags]
    public enum OpCode : uint
    {
        LedOff    = 1 << 0,
        LedOn     = 1 << 1,
        GripClose = 1 << 2,
        GripOpen  = 1 << 3,
        WristUp   = 1 << 4,
        WristDown = 1 << 5,
        ElbowUp   = 1 << 6,
        ElbowDown = 1 << 7,
        StemBack  = 1 << 8,
        StemAhead = 1 << 9,
        BaseRight = 1 << 10,
        BaseLeft  = 1 << 11,
        AllOff    = 1 << 12,
        Wait      = 1 << 13
    }
}
