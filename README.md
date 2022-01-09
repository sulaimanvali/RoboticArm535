# RoboticArm535
Windows software to control the OWI-535/Maplin Robotic Arm Edge via USB interface. Either use the buttons to control each of the motors manually, or write your own scripts to make the arm do crazy moves. The software will help you compose scripts, and even save/open scripts. The RoboticArm535Library is provided as a NuGet package to allow anyone to write console applications with a few lines of code. See examples.

Feel free to take the code, modify it, learn from it, make the robotic arm dance, clap, flip a bird etc.
Please be warned though, that there are no feedback sensors in the robotic arm. 
If you write scripts to control it, you have to send the appropriate command to stop the motors in time before they reach their limits and start clicking. Since version 1.4, there are duration limits in the software if you are sending timed commands via script. For example the Grip motor will not be allowed to run for longer than 2.7 seconds. Note also, that the robotic arm is far from precise or repeatable in terms of positional accuracy. There is considerable play and hysteresis in the plastic arm joints. 

### Downloads
https://github.com/sulaimanvali/RoboticArm535/releases

### USB Troubleshooting
If you are having USB driver issues, install the libusb-win32 driver explicitly via Device Manager.

### Screenshots
![alt text](https://github.com/sulaimanvali/RoboticArm535/blob/master/RoboticArm535/images/Screenshot1.png)

![alt text](https://github.com/sulaimanvali/RoboticArm535/blob/master/RoboticArm535/images/Screenshot2_AboutBox.png)
