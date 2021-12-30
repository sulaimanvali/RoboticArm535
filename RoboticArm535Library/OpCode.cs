using System;

namespace RoboticArm535Library
{
    [Flags]
    public enum OpCode : uint
    {
        LedOff    = 1 << 0,
        LedOn     = 1 << 1,
        GripStop  = 1 << 2,
        GripClose = 1 << 3,
        GripOpen  = 1 << 4,
        WristStop = 1 << 5,
        WristUp   = 1 << 6,
        WristDown = 1 << 7,
        ElbowStop = 1 << 8,
        ElbowUp   = 1 << 9,
        ElbowDown = 1 << 10,
        StemStop  = 1 << 11,
        StemBack  = 1 << 12,
        StemAhead = 1 << 13,
        BaseStop  = 1 << 14,
        BaseRight = 1 << 15,
        BaseLeft  = 1 << 16,
        AllOff    = 1 << 17,
    }
}
