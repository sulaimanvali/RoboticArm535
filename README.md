# RoboticArm535
Windows software to control the OWI-535/Maplin Robotic Arm Edge via USB interface. Press and hold down a button to move a motor.

Downloads: https://github.com/sulaimanvali/RoboticArm535/releases

Note that USB does not provide power to the robotic arm, only communication. You still need batteries inside it. Also, ensure it is switched on.

Feel free to take the code, modify it, learn from it, make it clap, dance, flip a bird etc.
Please be warned though, that there are no feedback sensors in the robotic arm. 
If you write scripts to control it, you have to send the appropriate command to stop the motors in time before they reach their limits and start clicking. Since version 1.4, there are duration limits in the software is you are sending timed commands via script. For example the Grip motor will not be allowed to run for longer than 2.7 seconds.

If you are having USB driver issues, install the libusb-win32 driver explicitly via Device Manager.

![alt text](https://github.com/sulaimanvali/RoboticArm535/blob/master/RoboticArm535/images/Screenshot1.png)

![alt text](https://github.com/sulaimanvali/RoboticArm535/blob/master/RoboticArm535/images/Screenshot2_AboutBox.png)


You can also use the RoboticArm535Library DLL to write your own console application or script to control the robotic arm as you please.
See https://github.com/sulaimanvali/RoboticArm535/blob/master/RoboticArm535ConsoleExample2/Program.cs or the other console examples.
