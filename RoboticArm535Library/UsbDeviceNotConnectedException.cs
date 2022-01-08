using System;

namespace RoboticArm535Library
{
    public class UsbDeviceNotConnectedException : Exception
    {
        public UsbDeviceNotConnectedException() { }

        public UsbDeviceNotConnectedException(string message) : base(message) { }

        public UsbDeviceNotConnectedException(string message, Exception inner) : base(message, inner) { }
    } 
}
