using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticArm535
{
    public class PacketGenerator
    {
        public const int CommandLength = 3;

        // byte 0
        private const byte STOP_GRIP_WRIST_ELBOW_BASE = 0x00;
        private const byte GRIP_CLOSE                 = 0x01;
        private const byte GRIP_OPEN                  = 0x02;
        private const byte WRIST_UP                   = 0x04;
        private const byte WRIST_DOWN                 = 0x08;
        private const byte ELBOW_UP                   = 0x10;
        private const byte ELBOW_DOWN                 = 0x20;
        private const byte STEM_BACKWARD              = 0x40;
        private const byte STEM_FORWARD               = 0x80;
        // byte 1
        private const byte BASE_STOP  = 0x00;
        private const byte BASE_RIGHT = 0x01;
        private const byte BASE_LEFT  = 0x02;
        // byte 2
        private const byte LED_OFF = 0x00;
        private const byte LED_ON  = 0x01;

        public static byte[] GenerateFor(ControlTriggered control, bool isPressed)
        {
            byte byte0 = 0, byte1 = 0, byte2 = 0;

            if (isPressed)
            {
                switch (control)
                {
                    // byte 0
                    case ControlTriggered.GripClose: byte0 = GRIP_CLOSE; break;
                    case ControlTriggered.GripOpen : byte0 = GRIP_OPEN; break;
                    case ControlTriggered.WristUp  : byte0 = WRIST_UP; break;
                    case ControlTriggered.WristDown: byte0 = WRIST_DOWN; break;
                    case ControlTriggered.ElbowUp  : byte0 = ELBOW_UP; break;
                    case ControlTriggered.ElbowDown: byte0 = ELBOW_DOWN; break;
                    case ControlTriggered.StemBack : byte0 = STEM_BACKWARD; break;
                    case ControlTriggered.StemAhead: byte0 = STEM_FORWARD; break;
                    // byte 1
                    case ControlTriggered.BaseRight: byte1 = BASE_RIGHT; break;
                    case ControlTriggered.BaseLeft:  byte1 = BASE_LEFT; break;
                    // byte 2
                    case ControlTriggered.Led:       byte2 = LED_ON; break;
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
                        byte0 = STOP_GRIP_WRIST_ELBOW_BASE;
                        break;
                    // byte 1
                    case ControlTriggered.BaseRight:
                    case ControlTriggered.BaseLeft:
                        byte1 = BASE_STOP;
                        break;
                    // byte 2
                    case ControlTriggered.Led:
                        byte2 = LED_OFF;
                        break;
                    default:
                        throw new NotSupportedException();
                }
            }
            return new byte[] { byte0, byte1, byte2 };
        }
    }
}
