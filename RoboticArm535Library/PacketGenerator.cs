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
        /// <param name="control"></param>
        /// <param name="isPressed"></param>
        /// <returns></returns>
        public static byte[] GenSinglePress(OpCode control, bool isPressed)
        {
            var led       = Out.Led.Off;
            var grip      = Out.Grip.Stop;
            var wrist     = Out.Wrist.Stop;
            var elbow     = Out.Elbow.Stop;
            var stem      = Out.Stem.Stop;
            var baseMotor = Out.Base.Stop;

            if (isPressed)
            {
                switch (control)
                {
                    // byte 0
                    case OpCode.GripClose: grip =  Out.Grip.Close; break;
                    case OpCode.GripOpen:  grip =  Out.Grip.Open; break;
                    case OpCode.WristUp:   wrist = Out.Wrist.Up; break;
                    case OpCode.WristDown: wrist = Out.Wrist.Down; break;
                    case OpCode.ElbowUp:   elbow = Out.Elbow.Up; break;
                    case OpCode.ElbowDown: elbow = Out.Elbow.Down; break;
                    case OpCode.StemBack:  stem =  Out.Stem.Back; break;
                    case OpCode.StemAhead: stem =  Out.Stem.Ahead; break;
                    // byte 1
                    case OpCode.BaseRight: baseMotor = Out.Base.Right; break;
                    case OpCode.BaseLeft:  baseMotor = Out.Base.Left; break;
                    // byte 2
                    case OpCode.Led: led = Out.Led.On; break;
                    default: throw new NotSupportedException();
                }
            }
            else
            {
                switch (control)
                {
                    // byte 0
                    case OpCode.GripClose:
                    case OpCode.GripOpen:
                    case OpCode.WristUp:
                    case OpCode.WristDown:
                    case OpCode.ElbowUp:
                    case OpCode.ElbowDown:
                    case OpCode.StemBack:
                    case OpCode.StemAhead:
                        grip  = Out.Grip.Stop;
                        wrist = Out.Wrist.Stop;
                        elbow = Out.Elbow.Stop;
                        stem  = Out.Stem.Stop;
                        break;
                    // byte 1
                    case OpCode.BaseRight:
                    case OpCode.BaseLeft:
                        baseMotor = Out.Base.Stop;
                        break;
                    // byte 2
                    case OpCode.Led:
                        led = Out.Led.Off;
                        break;
                    default:
                        throw new NotSupportedException();
                }
            }
            return GenMultiPress(led, grip, wrist, elbow, stem, baseMotor);
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
        public static byte[] GenMultiPress(Out.Led led,
                                           Out.Grip grip,
                                           Out.Wrist wrist,
                                           Out.Elbow elbow,
                                           Out.Stem stem,
                                           Out.Base baseMotor)
        {
            var bytes = new byte[Packet.CommandLength];

            bytes[0] = (byte)grip;
             bytes[0] |= (byte)wrist;
             bytes[0] |= (byte)elbow;
             bytes[0] |= (byte)stem;
            bytes[1] = (byte)baseMotor;
            bytes[2] = (byte)led;

            return bytes;
        }
    }
}
