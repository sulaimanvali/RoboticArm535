using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticArm535
{
    public class Motors
    {
        public enum Grip : byte
        {
            Stop  = Packet.Byte0.ArmStop,
            Close = Packet.Byte0.GripClose,
            Open  = Packet.Byte0.GripOpen
        }

        public enum Wrist : byte
        {
            Stop = Packet.Byte0.ArmStop,
            Up   = Packet.Byte0.WristUp,
            Down = Packet.Byte0.WristDown
        }

        public enum Elbow : byte
        {
            Stop = Packet.Byte0.ArmStop,
            Up   = Packet.Byte0.ElbowUp,
            Down = Packet.Byte0.ElbowDown
        }

        public enum Stem : byte
        {
            Stop  = Packet.Byte0.ArmStop,
            Back  = Packet.Byte0.StemBack,
            Ahead = Packet.Byte0.StempAhead
        }

        public enum Base : byte
        {
            Stop  = Packet.Byte1.BaseStop,
            Right = Packet.Byte1.BaseRight,
            Left  = Packet.Byte1.BaseLeft
        }
    }
}
