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

            // demonstrates a simple script controlling multiple outputs 
            usb.Cmd(Out.Led.On, Out.Grip.Stop, Out.Wrist.Stop, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);
            wait(500);
            usb.Cmd(Out.Led.Off, Out.Grip.Open, Out.Wrist.Up, Out.Elbow.Up, Out.Stem.Stop, Out.Base.Stop);
            wait(3000);
            usb.Cmd(Out.Led.On, Out.Grip.Stop, Out.Wrist.Up, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);
            wait(500);
            usb.Cmd(Out.Led.Off, Out.Grip.Stop, Out.Wrist.Stop, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);
            wait(500);

            for (int i = 0; i < 7; i++)
            {
                usb.Cmd(Out.Led.On, Out.Grip.Open, Out.Wrist.Down, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);
                wait(800);
                usb.Cmd(Out.Led.Off, Out.Grip.Close, Out.Wrist.Up, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);
                wait(800);
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
