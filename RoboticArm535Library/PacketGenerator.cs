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
        /// Generate 3 byte packet to send to robotic arm with the given output requests.
        /// </summary>
        /// <param name="opCode"></param>
        /// <returns></returns>
        public static byte[] GenByOpCode(OpCode opCode)
        {
            Out.Led led        = Out.Led.Off;
            Out.Grip grip      = Out.Grip.Stop;
            Out.Wrist wrist    = Out.Wrist.Stop;
            Out.Elbow elbow    = Out.Elbow.Stop;
            Out.Stem stem      = Out.Stem.Stop;
            Out.Base baseMotor = Out.Base.Stop;
            var packet = new byte[3];

            if (opCode.HasFlag(OpCode.AllOff))
                return packet;

            if (opCode.HasFlag(OpCode.Wait))
                throw new InvalidOperationException("Wait is not a valid command to send to robotic arm.");

            if (opCode.HasFlag(OpCode.LedOff))
                led = Out.Led.Off;
            else if (opCode.HasFlag(OpCode.LedOn))
                led = Out.Led.On;

            if (opCode.HasFlag(OpCode.GripClose))
                grip = Out.Grip.Close;
            else if (opCode.HasFlag(OpCode.GripOpen))
                grip = Out.Grip.Open;

            if (opCode.HasFlag(OpCode.WristUp))
                wrist = Out.Wrist.Up;
            else if (opCode.HasFlag(OpCode.WristDown))
                wrist = Out.Wrist.Down;

            if (opCode.HasFlag(OpCode.ElbowUp))
                elbow = Out.Elbow.Up;
            else if (opCode.HasFlag(OpCode.ElbowDown))
                elbow = Out.Elbow.Down;

            if (opCode.HasFlag(OpCode.StemBack))
                stem = Out.Stem.Back;
            else if (opCode.HasFlag(OpCode.StemAhead))
                stem = Out.Stem.Ahead;

            if (opCode.HasFlag(OpCode.BaseLeft))
                baseMotor = Out.Base.Left;
            else if (opCode.HasFlag(OpCode.BaseRight))
                baseMotor = Out.Base.Right;

            return PacketGenerator.GenByOutputs(led, grip, wrist, elbow, stem, baseMotor);
        }

        /// <summary>
        /// Generate 3 byte packet to send to robotic arm with the given output requests.
        /// </summary>
        /// <param name="led"></param>
        /// <param name="grip"></param>
        /// <param name="wrist"></param>
        /// <param name="elbow"></param>
        /// <param name="stem"></param>
        /// <param name="baseMotor"></param>
        /// <returns></returns>
        public static byte[] GenByOutputs(Out.Led led, Out.Grip grip, Out.Wrist wrist,
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
