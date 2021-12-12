using RoboticArm535Library;
using System;
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

            Console.WriteLine("Press any key to abort script");

            // demonstrates a simple script controlling multiple outputs simultaneously in different ways
            //sendCommandsByOutputs();
            //sendCommandsByBytes();
            sendCommandsByTimedOpCodeMasks();
        }

        private static void sendCommandsByOutputs()
        {
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

        private static void sendCommandsByBytes()
        {
            usb.Cmd(Packet.Byte0.ArmStop, Packet.Byte1.BaseStop, Packet.Byte2.LedOn);
            wait(500);
            usb.Cmd(Packet.Byte0.GripOpen | Packet.Byte0.WristUp | Packet.Byte0.ElbowUp, Packet.Byte1.BaseStop, Packet.Byte2.LedOff);
            wait(1500);
            usb.Cmd(Packet.Byte0.ArmStop, Packet.Byte1.BaseStop, Packet.Byte2.LedOn);
            wait(500);

            for (int i = 0; i < 5; i++)
            {
                usb.Cmd(Packet.Byte0.GripOpen | Packet.Byte0.WristUp | Packet.Byte0.ElbowUp, Packet.Byte1.BaseStop, Packet.Byte2.LedOff);
                wait(800);
                usb.Cmd(Packet.Byte0.GripClose | Packet.Byte0.WristDown | Packet.Byte0.ElbowDown, Packet.Byte1.BaseStop, Packet.Byte2.LedOn);
                wait(800);
            }
            stopAll();
        }

        private static void sendCommandsByTimedOpCodeMasks()
        {
            usb.TurnLedOn(true);
            usb.Cmd(OpCode.WristUp, 1.0f);
            usb.Cmd(OpCode.ElbowUp, 1.0f);

            for (int i = 0; i < 5; i++)
            {
                usb.Cmd(OpCode.GripOpen | OpCode.WristUp, 0.8f);
                usb.TurnLedOn(true);
                usb.Cmd(OpCode.GripClose | OpCode.WristDown, 0.8f);
                usb.TurnLedOn(false);
            }
            stopAll();
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
