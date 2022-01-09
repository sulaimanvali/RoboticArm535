using RoboticArm535Library;
using System;

UsbComms usb = new();
if (usb.Connect() != UsbConnErrorCode.NoError)
{
    Console.WriteLine("Unable to connect to USB device.");
    return;
}

var script =
@"
WristUp 0.65
ElbowUp 1.05
GripOpen 0.92
GripClose 0.85
LedOn 0.3
GripOpen 1
LedOn 0.3
GripClose 1
LedOn 0.3
GripOpen 1
LedOn 0.3
GripClose 1
LedOn 0.3
WristDown 0.80
ElbowDown 0.77";
await usb.RunScript(script, new Progress<int>(i => Console.WriteLine($"Line {i}")));