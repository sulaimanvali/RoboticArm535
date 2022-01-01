using RoboticArm535Library;
using System;

UsbComms usb = new();
if (usb.Connect() != UsbConnErrorCode.NoError)
{
    Console.WriteLine("Unable to connect to USB device.");
    return;
}
Console.CancelKeyPress += (sender, e) => { usb.AbortScript(); e.Cancel = true; };
Console.WriteLine("Press Ctrl-C to abort");

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
