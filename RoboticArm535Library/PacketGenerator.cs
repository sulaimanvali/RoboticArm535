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
        public static byte[] GenSinglePress(ControlTriggered control, bool isPressed)
        {
            var led       = Outputs.Led.Off;
            var grip      = Outputs.Grip.Stop;
            var wrist     = Outputs.Wrist.Stop;
            var elbow     = Outputs.Elbow.Stop;
            var stem      = Outputs.Stem.Stop;
            var baseMotor = Outputs.Base.Stop;

            if (isPressed)
            {
                switch (control)
                {
                    // byte 0
                    case ControlTriggered.GripClose: grip =  Outputs.Grip.Close; break;
                    case ControlTriggered.GripOpen:  grip =  Outputs.Grip.Open; break;
                    case ControlTriggered.WristUp:   wrist = Outputs.Wrist.Up; break;
                    case ControlTriggered.WristDown: wrist = Outputs.Wrist.Down; break;
                    case ControlTriggered.ElbowUp:   elbow = Outputs.Elbow.Up; break;
                    case ControlTriggered.ElbowDown: elbow = Outputs.Elbow.Down; break;
                    case ControlTriggered.StemBack:  stem =  Outputs.Stem.Back; break;
                    case ControlTriggered.StemAhead: stem =  Outputs.Stem.Ahead; break;
                    // byte 1
                    case ControlTriggered.BaseRight: baseMotor = Outputs.Base.Right; break;
                    case ControlTriggered.BaseLeft:  baseMotor = Outputs.Base.Left; break;
                    // byte 2
                    case ControlTriggered.Led: led = Outputs.Led.On; break;
                    default: throw new NotSupportedException();
                }
            }
            else
            {
                switch (control)
                {
                    // byte 0
                    case ControlTriggered.GripClose:
                    case ControlTriggered.GripOpen:
                    case ControlTriggered.WristUp:
                    case ControlTriggered.WristDown:
                    case ControlTriggered.ElbowUp:
                    case ControlTriggered.ElbowDown:
                    case ControlTriggered.StemBack:
                    case ControlTriggered.StemAhead:
                        grip  = Outputs.Grip.Stop;
                        wrist = Outputs.Wrist.Stop;
                        elbow = Outputs.Elbow.Stop;
                        stem  = Outputs.Stem.Stop;
                        break;
                    // byte 1
                    case ControlTriggered.BaseRight:
                    case ControlTriggered.BaseLeft:
                        baseMotor = Outputs.Base.Stop;
                        break;
                    // byte 2
                    case ControlTriggered.Led:
                        led = Outputs.Led.Off;
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
        public static byte[] GenMultiPress(Outputs.Led led,
                                           Outputs.Grip grip,
                                           Outputs.Wrist wrist,
                                           Outputs.Elbow elbow,
                                           Outputs.Stem stem,
                                           Outputs.Base baseMotor)
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
