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
            Out.Led led = Out.Led.Off;
            Out.Grip grip = Out.Grip.Stop;
            Out.Wrist wrist = Out.Wrist.Stop;
            Out.Elbow elbow = Out.Elbow.Stop;
            Out.Stem stem = Out.Stem.Stop;
            Out.Base baseMotor = Out.Base.Stop;
            var packet = new byte[3];

            if (opCode == OpCode.AllOff)
                return packet;

            if ((opCode & OpCode.LedOff) != 0)
                led = Out.Led.Off;
            else if ((opCode & OpCode.LedOn) != 0)
                led = Out.Led.On;

            if ((opCode & OpCode.GripStop) != 0)
                grip = Out.Grip.Stop;
            else if ((opCode & OpCode.GripClose) != 0)
                grip = Out.Grip.Close;
            else if ((opCode & OpCode.GripOpen) != 0)
                grip = Out.Grip.Open;

            if ((opCode & OpCode.WristStop) != 0)
                wrist = Out.Wrist.Stop;
            else if ((opCode & OpCode.WristUp) != 0)
                wrist = Out.Wrist.Up;
            else if ((opCode & OpCode.WristDown) != 0)
                wrist = Out.Wrist.Down;

            if ((opCode & OpCode.ElbowStop) != 0)
                elbow = Out.Elbow.Stop;
            else if ((opCode & OpCode.ElbowUp) != 0)
                elbow = Out.Elbow.Up;
            else if ((opCode & OpCode.ElbowDown) != 0)
                elbow = Out.Elbow.Down;

            if ((opCode & OpCode.StemStop) != 0)
                stem = Out.Stem.Stop;
            else if ((opCode & OpCode.StemBack) != 0)
                stem = Out.Stem.Back;
            else if ((opCode & OpCode.StemAhead) != 0)
                stem = Out.Stem.Ahead;

            if ((opCode & OpCode.BaseStop) != 0)
                baseMotor = Out.Base.Stop;
            else if ((opCode & OpCode.BaseLeft) != 0)
                baseMotor = Out.Base.Left;
            else if ((opCode & OpCode.BaseRight) != 0)
                baseMotor = Out.Base.Right;

            return PacketGenerator.GenMultiPress(led, grip, wrist, elbow, stem, baseMotor);
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
