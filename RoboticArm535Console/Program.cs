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
            usb.Cmd(Outputs.Led.On, Outputs.Grip.Stop, Outputs.Wrist.Stop, Outputs.Elbow.Stop, Outputs.Stem.Stop, Outputs.Base.Stop);
            wait(500);
            usb.Cmd(Outputs.Led.Off, Outputs.Grip.Open, Outputs.Wrist.Up, Outputs.Elbow.Up, Outputs.Stem.Stop, Outputs.Base.Stop);
            wait(3000);
            usb.Cmd(Outputs.Led.On, Outputs.Grip.Stop, Outputs.Wrist.Up, Outputs.Elbow.Stop, Outputs.Stem.Stop, Outputs.Base.Stop);
            wait(500);
            usb.Cmd(Outputs.Led.Off, Outputs.Grip.Stop, Outputs.Wrist.Stop, Outputs.Elbow.Stop, Outputs.Stem.Stop, Outputs.Base.Stop);
            wait(500);

            for (int i = 0; i < 7; i++)
            {
                usb.Cmd(Outputs.Led.On, Outputs.Grip.Open, Outputs.Wrist.Down, Outputs.Elbow.Stop, Outputs.Stem.Stop, Outputs.Base.Stop);
                wait(800);
                usb.Cmd(Outputs.Led.Off, Outputs.Grip.Close, Outputs.Wrist.Up, Outputs.Elbow.Stop, Outputs.Stem.Stop, Outputs.Base.Stop);
                wait(800);
            }
            stopAll();
        }
        

        private static void wait(int millisecondsTimeout)
        {
            if (Console.KeyAvailable)
            {
                stopAll();
                Environment.Exit(0);
            }

            Thread.Sleep(millisecondsTimeout);
        }

        private static void stopAll()
        {
            usb.Cmd(Outputs.Led.Off, Outputs.Grip.Stop, Outputs.Wrist.Stop, Outputs.Elbow.Stop, Outputs.Stem.Stop, Outputs.Base.Stop);
        }
    }
}
