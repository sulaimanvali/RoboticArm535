using RoboticArm535Library;
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
            //sendCommandsByBytes();
            //sendCommandsByTimedOpCodeMasks();
            sendCommandsByScriptInAppConfig();
            //sendCommandsByScriptInString();
        }

        private static void sendCommandsByOutputs()
        {
            Console.WriteLine("Press any key to abort script");
            usb.Cmd(Out.Led.On, Out.Grip.Stop, Out.Wrist.Stop, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);
            wait(500);
            usb.Cmd(Out.Led.Off, Out.Grip.Open, Out.Wrist.Up, Out.Elbow.Up, Out.Stem.Stop, Out.Base.Stop);
            wait(1000);
            usb.Cmd(Out.Led.On, Out.Grip.Stop, Out.Wrist.Up, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);
            wait(500);
            usb.Cmd(Out.Led.Off, Out.Grip.Stop, Out.Wrist.Stop, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);
            wait(500);

            for (int i = 0; i < 5; i++)
            {
                usb.Cmd(Out.Led.On, Out.Grip.Open, Out.Wrist.Down, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);
                wait(800);
                usb.Cmd(Out.Led.Off, Out.Grip.Close, Out.Wrist.Up, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);
                wait(800);
            }
            stopAll();
        }

        private static void sendCommandsByTimedOpCodeMasks()
        {
            usb.TurnLed(true);
            usb.Cmd(OpCode.WristUp, 1.0f);
            usb.Cmd(OpCode.ElbowUp, 1.0f);

            for (int i = 0; i < 5; i++)
            {
                usb.Cmd(OpCode.GripOpen | OpCode.WristUp, 0.8f);
                usb.TurnLed(true);
                usb.Cmd(OpCode.GripClose | OpCode.WristDown, 0.8f);
                usb.TurnLed(false);
            }
            usb.Cmd(OpCode.WristDown | OpCode.ElbowDown, 1.0f);
            stopAll();
        }

        private static void sendCommandsByScriptInAppConfig()
        {
            try
            {
                foreach (var action in TimedAction.ParseLines(Properties.Resources.script1_roundOfApplause))
                    usb.Cmd(action.OpCode, action.DurationSecs);
            }
            catch (Exception ex)
            {
                stopAll();
                Console.WriteLine(ex.Message);
            }
        }

        private static void sendCommandsByScriptInString()
        {
            var script =
@"LedOn 0.00
WristUp 0.65
ElbowUp 1.05
GripOpen 0.92
AllOff 0.00
GripClose 0.85
LedOn 0.00
GripOpen 0.92
AllOff 0.00
GripClose 0.94
LedOn 0.00
GripOpen 0.92
AllOff 0.00
GripClose 0.94
AllOff 0.00
WristDown 0.80
ElbowDown 0.77";

            try
            {
                foreach (var action in TimedAction.ParseLines(script))
                    usb.Cmd(action.OpCode, action.DurationSecs);
            }
            catch (Exception ex)
            {
                stopAll();
                Console.WriteLine(ex.Message);
            }
        }

        private static void wait(int durationMs)
        {
            int intervalsMs = 200;
            int sleepTime = 0;
            while (sleepTime < durationMs)
            {
                if (Console.KeyAvailable)
                {
                    stopAll();
                    Environment.Exit(0);
                    return;
                }

                if (sleepTime + intervalsMs > durationMs)
                    intervalsMs = durationMs - sleepTime;
                sleepTime += intervalsMs;
                Thread.Sleep(intervalsMs);
            }
        }

        private static void stopAll()
        {
            usb.Cmd(Out.Led.Off, Out.Grip.Stop, Out.Wrist.Stop, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);
        }
    }
}
