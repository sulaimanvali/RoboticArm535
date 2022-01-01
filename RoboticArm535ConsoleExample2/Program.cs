using RoboticArm535Library;
using System;
using System.Threading;
using System.Threading.Tasks;

UsbComms usb = new UsbComms();
CancellationTokenSource tokenSource = new();
if (usb.Connect() != UsbConnErrorCode.NoError)
{
    Console.WriteLine("Unable to connect to USB device.");
    Console.ReadKey();
    return;
}
Console.CancelKeyPress += (sender, e) => { tokenSource.Cancel(); e.Cancel = true; };
Console.WriteLine("Press Ctrl-C to abort");

// demonstrates a simple script
try
{
    await sendCommandsByTimedOpCodeMasks();
}
catch (OperationCanceledException)
{
    Console.WriteLine("Script aborted.");
}
finally
{
    tokenSource.Dispose();
}

async Task sendCommandsByTimedOpCodeMasks()
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
