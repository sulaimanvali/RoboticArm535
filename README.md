# RoboticArm535
Windows software to control the OWI-535/Maplin Robotic Arm Edge via USB interface. Press and hold down a button to control it.

Note that USB does not provide power to the robotic arm, only communication. You still need batteries inside it. Also, ensure it is switched on.

Feel free to take the code, modify it, learn from it, make the robotic arm programmable, dance, flip a bird etc.
Please be warned though, that there are no feedback sensors in the robotic arm. 
If you write scripts to control it, you have to send the appropriate command to stop the motors in time before they reach their limits and start clicking or break!

If you are having USB driver issues, install the libusb-win32 driver explicitly via Device Manager.

![alt text](https://github.com/sulaimanvali/RoboticArm535/blob/master/RoboticArm535/images/Screenshot1.png)
