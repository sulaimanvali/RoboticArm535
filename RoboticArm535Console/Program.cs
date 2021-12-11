﻿using RoboticArm535Library;
using System;
using System.Threading;

namespace RoboticArm535Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var usbComms = new UsbComms();
            if (usbComms.Connect() != UsbConnErrorCode.NoError)
            {
                Console.WriteLine("Unable to connect to USB device.");
                Console.ReadKey();
                return;
            }

            // demonstrates a simple script controlling multiple outputs 
            usbComms.SendCommandMulti(true, Outputs.Grip.Stop, Outputs.Wrist.Stop, Outputs.Elbow.Stop, Outputs.Stem.Stop, Outputs.Base.Stop);
            Thread.Sleep(500);
            usbComms.SendCommandMulti(false, Outputs.Grip.Open, Outputs.Wrist.Stop, Outputs.Elbow.Up, Outputs.Stem.Stop, Outputs.Base.Stop);
            Thread.Sleep(500);
            usbComms.SendCommandMulti(true, Outputs.Grip.Stop, Outputs.Wrist.Up, Outputs.Elbow.Stop, Outputs.Stem.Stop, Outputs.Base.Stop);
            Thread.Sleep(500);
            usbComms.SendCommandMulti(false, Outputs.Grip.Stop, Outputs.Wrist.Stop, Outputs.Elbow.Stop, Outputs.Stem.Stop, Outputs.Base.Stop);
            Thread.Sleep(500);

            for (int i = 0; i < 3; i++)
            {
                usbComms.SendCommandMulti(true, Outputs.Grip.Open, Outputs.Wrist.Down, Outputs.Elbow.Stop, Outputs.Stem.Stop, Outputs.Base.Stop);
                Thread.Sleep(3000);
                usbComms.SendCommandMulti(false, Outputs.Grip.Close, Outputs.Wrist.Up, Outputs.Elbow.Stop, Outputs.Stem.Stop, Outputs.Base.Stop);
                Thread.Sleep(3000);
            }
            usbComms.SendCommandMulti(false, Outputs.Grip.Stop, Outputs.Wrist.Stop, Outputs.Elbow.Stop, Outputs.Stem.Stop, Outputs.Base.Stop);
        }
    }
}
