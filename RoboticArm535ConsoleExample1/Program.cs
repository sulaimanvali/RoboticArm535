using RoboticArm535Library;
using System;
using System.Threading;
using System.Threading.Tasks;

UsbComms usb = new();
CancellationTokenSource tokenSource = new();
if (usb.Connect() != UsbConnErrorCode.NoError)
{
    Console.WriteLine("Unable to connect to USB device.");
    return;
}
Console.CancelKeyPress += (sender, e) => { tokenSource.Cancel(); e.Cancel = true; };
Console.WriteLine("Press Ctrl-C to abort");

// demonstrates a simple script controlling multiple outputs simultaneously in different ways
try
{
    await sendCommandsByOutputs();
}
catch (OperationCanceledException)
{
    usb.Cmd(Out.Led.Off, Out.Grip.Stop, Out.Wrist.Stop, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);
    Console.WriteLine("Script aborted.");
}
finally
{
    tokenSource.Dispose();
}

async Task sendCommandsByOutputs()
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

    async Task wait(int ms)
    {
        await Task.Delay(ms, tokenSource.Token);
    }
}
