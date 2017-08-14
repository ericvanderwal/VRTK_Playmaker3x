# VRTK Playmaker Action Set

These c# files are created to be used in conjunction with the Unity3d asset Playmaker, along with the VRTK (virtual reality tool kit). They act as bridge to allow VRTK variables to be changed and various methods and events to be called from within Playmaker during Unity3d runtime.

The following project is released under the MIT license as stated below. 

## Important - Read First

The current master version to be used together with the current VRTK Github version (3.3.0 beta). **Always backup your projects before updating **   

Use the 3.2.0 branch for VRTK 3.2.0, or the 3.1.0 for VRTK 3.1.0. 

## Updating

If you are updating from 3.2.0 or 3.1.0, to 3.3.0, make sure to backup your project first. Then remove all the VRTK playmaker actions and replace the folder entirely. The 3.3.0 does include legacy actions from 3.2.0/3.1.0 that are no longer in use. I am currently in the process of marking them all obsolete (as I find them). They will not break your project, but they rely on script that are no longer in use for VRTK. They are included however to not break any updates.

Once finished updating, you may need open some actions in your FSM to correct them. Some actions have new variable fields added or removed. This was unavoidable as VRTK continues to update.

Specifically these actions:

getControllerVisible  
setControllerOpacity  
toggleControllerVisbility  
getControllerVelocity  
GetGrabPressed  
GetGripPressed  
GetMenuPressed (aka, button two).  
GetUiClickPressed  
GetPointerPressed  
GetUsePressed  
SetBodyPhysicsSnapToFloorSettings  
SetDashTeleportHeightAdjustOptions  
pointerDestinationInfoExit  
pointerDestinationInfo  
AltSetPointerDestinationMarkerSettings  


## License

**Copyright 2017 Eric Vander Wal**

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

## Current Author and Contributors

Currently this managed and authored by **Eric Vander Wal**

If you are interested in contributing to this project, please contact me privately at tcmeric@gmail.com, as well as join our playmaker slack channel: https://invite-playmaker-slack.herokuapp.com

## Project Source

This project can be downloaded in full for free from : https://github.com/dumbgamedev/VRTK_Playmaker3x

## Tutorials

Tutorials about this project can be found online at: https://www.youtube.com/channel/UCyRBYRGl9v_byeKxT4GLG_A

## Bugs

Currently no major bugs have been reported, however this is a work in progress.
