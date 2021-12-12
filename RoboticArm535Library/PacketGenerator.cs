using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticArm535Library
{
    public class PacketGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="opCode"></param>
        /// <returns></returns>
        public static byte[] GenSinglePress(OpCode opCode)
        {
            var bytes = BitConverter.GetBytes((uint)opCode);
            return new byte[] { bytes[0], bytes[1], bytes[2] };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="led"></param>
        /// <param name="grip"></param>
        /// <param name="wrist"></param>
        /// <param name="elbow"></param>
        /// <param name="stem"></param>
        /// <param name="baseMotor"></param>
        /// <returns></returns>
        public static byte[] GenMultiPress(Out.Led led, Out.Grip grip, Out.Wrist wrist,
            Out.Elbow elbow, Out.Stem stem, Out.Base baseMotor)
        {
            var bytes = new byte[Packet.CommandLength];
            bytes[0] = (byte)((byte)grip | (byte)wrist | (byte)elbow | (byte)stem);
            bytes[1] = (byte)baseMotor;
            bytes[2] = (byte)led;
            return bytes;
        }
    }
}
