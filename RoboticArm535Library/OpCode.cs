namespace RoboticArm535Library
{
    public enum OpCode : uint
    {
        GripClose  = 0x000001,
        GripOpen   = 0x000002,
        WristUp    = 0x000004,
        WristDown  = 0x000008,
        ElbowUp    = 0x000010,
        ElbowDown  = 0x000020,
        StemBack   = 0x000040,
        StemAhead  = 0x000080,
        BaseRight  = 0x000100,
        BaseLeft   = 0x000200,
        AllOff     = 0x000000, // all off, including LED
        LedOn      = 0x010000
    }
}
