using RoboticArm535Library;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RoboticArm535Console
{
    class Program
    {
        static readonly UsbComms usb = new UsbComms();
        static CancellationTokenSource tokenSource = new();

        static async Task Main(string[] args)
        {
            if (usb.Connect() != UsbConnErrorCode.NoError)
            {
                Console.WriteLine("Unable to connect to USB device.");
                Console.ReadKey();
                return;
            }
            Console.CancelKeyPress += Console_CancelKeyPress;
            Console.WriteLine("Press Ctrl-C to abort");

            // demonstrates a simple script controlling multiple outputs simultaneously in different ways
            try
            {
                //await sendCommandsByOutputs();
                await sendCommandsByTimedOpCodeMasks();
                //await sendCommandsByScriptInString();
            }
            catch (OperationCanceledException)
            {
                usb.Cmd(Out.Led.Off, Out.Grip.Stop, Out.Wrist.Stop, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);
            }
            finally
            {
                tokenSource.Dispose();
            }
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            tokenSource.Cancel();
            usb.AbortScript();
            e.Cancel = true;
        }

        private static async Task sendCommandsByOutputs()
        {
            usb.Cmd(Out.Led.On, Out.Grip.Stop, Out.Wrist.Stop, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);
            await wait(500);
            usb.Cmd(Out.Led.Off, Out.Grip.Open, Out.Wrist.Up, Out.Elbow.Up, Out.Stem.Stop, Out.Base.Stop);
            await wait(1000);
            usb.Cmd(Out.Led.On, Out.Grip.Stop, Out.Wrist.Up, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);
            await wait(500);
            usb.Cmd(Out.Led.Off, Out.Grip.Stop, Out.Wrist.Stop, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);
            await wait(500);

            for (int i = 0; i < 5; i++)
            {
                usb.Cmd(Out.Led.On, Out.Grip.Open, Out.Wrist.Down, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);
                await wait(800);
                usb.Cmd(Out.Led.Off, Out.Grip.Close, Out.Wrist.Up, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);
                await wait(800);
            }
            usb.Cmd(Out.Led.Off, Out.Grip.Stop, Out.Wrist.Stop, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);

            async Task wait(int millisecondsDelay)
            {
                await Task.Delay(millisecondsDelay, tokenSource.Token);
            }
        }

        private static async Task sendCommandsByTimedOpCodeMasks()
        {
            await Task.Run(() =>
            {
                usb.Cmd(OpCode.WristUp, 1.0f);
                usb.Cmd(OpCode.ElbowUp, 1.0f);

                for (int i = 0; i < 5; i++)
                {
                    if (tokenSource.IsCancellationRequested)
                        tokenSource.Token.ThrowIfCancellationRequested();

                    usb.Cmd(OpCode.GripOpen | OpCode.WristUp | OpCode.LedOn, 0.8f);
                    usb.Cmd(OpCode.GripClose | OpCode.WristDown | OpCode.LedOff, 0.8f);
                }
                usb.Cmd(OpCode.WristDown | OpCode.ElbowDown, 1.0f);
            }, tokenSource.Token);
        }

        private static async Task sendCommandsByScriptInString()
        {
            var script =
@"
WristUp 0.65
ElbowUp 1.05
GripOpen 0.92
GripClose 0.85
LedOn 0
GripOpen 1
LedOff 0
GripClose 1
LedOn 0
GripOpen 1
LedOff 0
GripClose 1
LedOn 0
WristDown 0.80
ElbowDown 0.77";
            var lines = script.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            await usb.RunScript(script, new Progress<int>(lineIndex => Console.WriteLine($"Line {lineIndex}: {lines[lineIndex]}")));
        }
    }
}
