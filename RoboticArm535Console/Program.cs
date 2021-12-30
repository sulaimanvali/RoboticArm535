﻿using RoboticArm535Library;
using System;
using System.Collections.Generic;
using System.Threading;

namespace RoboticArm535Console
{
    class Program
    {
        static readonly UsbComms usb = new UsbComms();

        static void Main(string[] args)
        {
            if (usb.Connect() != UsbConnErrorCode.NoError)
            {
                Console.WriteLine("Unable to connect to USB device.");
                Console.ReadKey();
                return;
            }

            // demonstrates a simple script controlling multiple outputs simultaneously in different ways
            //sendCommandsByOutputs();
            //sendCommandsByTimedOpCodeMasks();
            sendCommandsByScriptInString();
        }

        private static void sendCommandsByOutputs()
        {
            Console.WriteLine("Press any key to abort script");
            usb.Cmd(Out.Led.On, Out.Grip.Stop, Out.Wrist.Stop, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);
            Thread.Sleep(500);
            usb.Cmd(Out.Led.Off, Out.Grip.Open, Out.Wrist.Up, Out.Elbow.Up, Out.Stem.Stop, Out.Base.Stop);
            Thread.Sleep(1000);
            usb.Cmd(Out.Led.On, Out.Grip.Stop, Out.Wrist.Up, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);
            Thread.Sleep(500);
            usb.Cmd(Out.Led.Off, Out.Grip.Stop, Out.Wrist.Stop, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);
            Thread.Sleep(500);

            for (int i = 0; i < 5; i++)
            {
                usb.Cmd(Out.Led.On, Out.Grip.Open, Out.Wrist.Down, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);
                Thread.Sleep(800);
                usb.Cmd(Out.Led.Off, Out.Grip.Close, Out.Wrist.Up, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);
                Thread.Sleep(800);
            }
            usb.Cmd(Out.Led.Off, Out.Grip.Stop, Out.Wrist.Stop, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);
        }

        private static void sendCommandsByTimedOpCodeMasks()
        {
            usb.Cmd(OpCode.WristUp, 1.0f);
            usb.Cmd(OpCode.ElbowUp, 1.0f);

            for (int i = 0; i < 5; i++)
            {
                usb.Cmd(OpCode.GripOpen | OpCode.WristUp | OpCode.LedOn, 0.8f);
                usb.Cmd(OpCode.GripClose | OpCode.WristDown | OpCode.LedOff, 0.8f);
            }
            usb.Cmd(OpCode.WristDown | OpCode.ElbowDown, 1.0f);
        }

        private static void sendCommandsByScriptInString()
        {
            var script =
@"
WristUp 0.65
ElbowUp 1.05
GripOpen 0.92
GripClose 0.85
LedOn 0.5
GripOpen 0.92
LedOff 0.5
GripClose 0.94
LedOn 0.5
GripOpen 0.92
LedOff 0.5
GripClose 0.94
LedOff 0.5
WristDown 0.80
ElbowDown 0.77";

            usb.RunScript(script);
        }
    }
}
