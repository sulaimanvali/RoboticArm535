using RoboticArm535Library;
using System;
using System.IO;

if (args.Length < 1)
{
    Console.WriteLine("Pass in filepath of 535script to run.");
    return;
}
var filepath = args[0];
if (!File.Exists(filepath))
{
    Console.WriteLine($"File not found: {filepath}");
    return;
}
string script = File.ReadAllText(filepath);

UsbComms usb = new();
if (usb.Connect() != UsbConnErrorCode.NoError)
{
    Console.WriteLine("Unable to connect to USB device.");
    return;
}
Console.CancelKeyPress += (sender, e) => { usb.AbortScript(); e.Cancel = true; };
Console.WriteLine("Press Ctrl-C to abort");

// demonstrates a simple script in a string
var lines = script.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
await usb.RunScript(script, new Progress<int>(lineIndex => Console.WriteLine($"Line {lineIndex}: {lines[lineIndex]}")));
