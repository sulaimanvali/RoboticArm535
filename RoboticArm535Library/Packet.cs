using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticArm535Library
{
    public class Packet
    {
        public const int CommandLength = 3;

        [Flags]
        public enum Byte0
        {
            ArmStop    = 0x00,
            GripClose  = 0x01,
            GripOpen   = 0x02,
            WristUp    = 0x04,
            WristDown  = 0x08,
            ElbowUp    = 0x10,
            ElbowDown  = 0x20,
            StemBack   = 0x40,
            StempAhead = 0x80
        }

        [Flags]
        public enum Byte1
        {
            BaseStop  = 0x00,
            BaseRight = 0x01,
            BaseLeft  = 0x02
        }

        [Flags]
        public enum Byte2
        {
            LedOff = 0x00,
            LedOn  = 0x01
        }
    }
}
