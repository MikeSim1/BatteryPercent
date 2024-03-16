Disclaimer: I have never written C# before this repo. The code will probably look terrible.

This project was forked to update and expand functionality.
Forked with the intent to use with my ROG Ally as I got sick of waiting for ASUS to implement basic features.
There are currently some odd behaviors when running a game and this program at the same time when you try to access to command center on ROG Ally.
Using Windows Powertoys and pinning this app to always be on top may prevent some weirdness with ROG Ally and its overlays.
This can be used on any Windows device running on battery.


# BatteryPercent
Shows Time and battery percent

App that works great for emulators and some games but most other games will disable it while in game. I use it for my emulators to see how much ETA I have left. Written in C#. 

![battery overlay](https://github.com/victory111111/BatteryPercent/assets/139520397/46a1bab3-baa2-4415-95d4-576fd8882cab)

![battery overlay2](https://github.com/victory111111/BatteryPercent/assets/139520397/57c5cad8-f17d-4381-bda0-a67f3e2549fc)

To exit the application click on the system tray icon and right click on this icon and choose "Exit"

![battery overlay3](https://github.com/victory111111/BatteryPercent/assets/139520397/246a32a9-51d1-40c3-9eb0-159789094328)

# Building
To build, install CSC and simple run the build script `build_w_csc.sh`
If you get an error `permission denied` simply run `chmod +x build_w_csc.sh` (Mac/Linux)
No build script for Windows yet.
