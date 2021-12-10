using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticArm535Library
{
    public class PacketGenerator
    {
        public static byte[] GenSinglePress(ControlTriggered control, bool isPressed)
        {
            var ledOn = false;
            var grip      = Motors.Grip.Stop;
            var wrist     = Motors.Wrist.Stop;
            var elbow     = Motors.Elbow.Stop;
            var stem      = Motors.Stem.Stop;
            var baseMotor = Motors.Base.Stop;

            if (isPressed)
            {
                switch (control)
                {
                    // byte 0
                    case ControlTriggered.GripClose: grip =  Motors.Grip.Close; break;
                    case ControlTriggered.GripOpen:  grip =  Motors.Grip.Open; break;
                    case ControlTriggered.WristUp:   wrist = Motors.Wrist.Up; break;
                    case ControlTriggered.WristDown: wrist = Motors.Wrist.Down; break;
                    case ControlTriggered.ElbowUp:   elbow = Motors.Elbow.Up; break;
                    case ControlTriggered.ElbowDown: elbow = Motors.Elbow.Down; break;
                    case ControlTriggered.StemBack:  stem =  Motors.Stem.Back; break;
                    case ControlTriggered.StemAhead: stem =  Motors.Stem.Ahead; break;
                    // byte 1
                    case ControlTriggered.BaseRight: baseMotor = Motors.Base.Right; break;
                    case ControlTriggered.BaseLeft:  baseMotor = Motors.Base.Left; break;
                    // byte 2
                    case ControlTriggered.Led: ledOn = true; break;
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
                        grip  = Motors.Grip.Stop;
                        wrist = Motors.Wrist.Stop;
                        elbow = Motors.Elbow.Stop;
                        stem  = Motors.Stem.Stop;
                        break;
                    // byte 1
                    case ControlTriggered.BaseRight:
                    case ControlTriggered.BaseLeft:
                        baseMotor = Motors.Base.Stop;
                        break;
                    // byte 2
                    case ControlTriggered.Led:
                        ledOn = false;
                        break;
                    default:
                        throw new NotSupportedException();
                }
            }
            return GenMultiPress(ledOn, grip, wrist, elbow, stem, baseMotor);
        }

        public static byte[] GenMultiPress(bool ledOn,
                                         Motors.Grip grip,
                                         Motors.Wrist wrist,
                                         Motors.Elbow elbow,
                                         Motors.Stem stem,
                                         Motors.Base baseMotor)
        {
            var bytes = new byte[Packet.CommandLength];

            bytes[0] = (byte)grip;
             bytes[0] |= (byte)wrist;
             bytes[0] |= (byte)elbow;
             bytes[0] |= (byte)stem;
            bytes[1] = (byte)baseMotor;
            bytes[2] = (byte)(ledOn ? Packet.Byte2.LedOn : Packet.Byte2.LedOff);

            return bytes;
        }
    }
}
