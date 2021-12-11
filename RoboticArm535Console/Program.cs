using RoboticArm535Library;
using System;
using System.Threading;

namespace RoboticArm535Console
{
    class Program
    {
        static readonly UsbComms usbComms = new UsbComms();

        static void Main(string[] args)
        {
            if (usbComms.Connect() != UsbConnErrorCode.NoError)
            {
                Console.WriteLine("Unable to connect to USB device.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Press any key to abort script");

            // demonstrates a simple script controlling multiple outputs 
            usbComms.SendCommandMulti(Outputs.Led.On, Outputs.Grip.Stop, Outputs.Wrist.Stop, Outputs.Elbow.Stop, Outputs.Stem.Stop, Outputs.Base.Stop);
            wait(500);
            usbComms.SendCommandMulti(Outputs.Led.Off, Outputs.Grip.Open, Outputs.Wrist.Up, Outputs.Elbow.Up, Outputs.Stem.Stop, Outputs.Base.Stop);
            wait(3000);
            usbComms.SendCommandMulti(Outputs.Led.On, Outputs.Grip.Stop, Outputs.Wrist.Up, Outputs.Elbow.Stop, Outputs.Stem.Stop, Outputs.Base.Stop);
            wait(500);
            usbComms.SendCommandMulti(Outputs.Led.Off, Outputs.Grip.Stop, Outputs.Wrist.Stop, Outputs.Elbow.Stop, Outputs.Stem.Stop, Outputs.Base.Stop);
            wait(500);

            for (int i = 0; i < 7; i++)
            {
                usbComms.SendCommandMulti(Outputs.Led.On, Outputs.Grip.Open, Outputs.Wrist.Down, Outputs.Elbow.Stop, Outputs.Stem.Stop, Outputs.Base.Stop);
                wait(800);
                usbComms.SendCommandMulti(Outputs.Led.Off, Outputs.Grip.Close, Outputs.Wrist.Up, Outputs.Elbow.Stop, Outputs.Stem.Stop, Outputs.Base.Stop);
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
            usbComms.SendCommandMulti(Outputs.Led.Off, Outputs.Grip.Stop, Outputs.Wrist.Stop, Outputs.Elbow.Stop, Outputs.Stem.Stop, Outputs.Base.Stop);
        }
    }
}
