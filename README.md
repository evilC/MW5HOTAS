# MW5HOTAS
 A tool and guide to assist configuring HOTAS controllers in Mechwarrior 5



### Step 1 - Install the vJoy device driver

vJoy is a virtual joystick emulator that will create a software-controller fake joystick on your system
We will be setting up MW5 to ignore all your physical sticks and instead take input from only the virtual vJoy stick. Software will then be used to take input from your physical HOTAS devices and route it to the vJoy stick

1. Install vJoy from http://vjoystick.sourceforge.net/site/index.php/download-a-install/download

2. Reboot after installing vJoy

3. Start > Configure vJoy
   Configure it like this:

   ![](https://i.imgur.com/0DqL0q1.png)

   Reboot if required

4. Open the vJoy Monitor  
   Start > vJoy Monitor  
   ![](https://i.imgur.com/TAmtjsW.png)

5. Verify that vJoy is working  

   Open the vJoy feeder  
   Start > vJoy Feeder (Demo)  
   ![](https://i.imgur.com/kK7HUJW.png)

   Drag sliders around, you should see the vJoy monitor update accordingly

6. Verify that windows can see the vJoy stick and that it updates OK  

   Start > joy.cpl  
   Double click the "vJoy Device" entry in the Game Controllers window  
   ![](https://i.imgur.com/wgywg3Q.png)

   Drag sliders in the vJoy Feeder, then click on the `vJoy Device Properties` window, you should see the state change.
   ![](https://i.imgur.com/VwYshmY.gif)

7. vJoy is now installed and working OK, **CLOSE THE vJOY FEEDER WINDOW**



### Step 2 - Create a new MW5 `HOTASMappings.Remap` Settings file using the MW5HOTAS tool

The MW5HOTAS tool creates a custom `HOTASMappings.Remap` file that tells MW5 to ignore all the input coming from your physical sticks and instead only take input from the vJoy stick

1. Download a release of MW5HOTAS [from the releases page](https://github.com/evilC/MW5HOTAS/releases).  
   **DO NOT use the green "Clone or Download" button on this page!**
2. Unblock the zip  
   Right-click the zip, select properties, and check the `Unblock` box in the bottom right corner if it exists
   ![](https://i.imgur.com/ACVCr7N.png)
3. Unzip the zip to a folder of your choice
4. Plug in **all the sticks you wish to use with MW5**
5. Run `MW5HOTAS.exe`, you should see something like this:
   ![](https://i.imgur.com/p2nL0hO.png)
   You should see one line per device that you had plugged in (eg above, I have 3 devices - `WootingTwo`, `T.16000M` and `TWCS Throttle`)
6. Hit ENTER to exit, then open the folder where your MW5 settings file is located  
   `AppData\Local\MW5Mercs\Saved\SavedHOTAS`
7. Back up your old `HOTASMappings.Remap` file
8. Copy the `HOTASMappings.Remap` file that `MW5HOTAS.exe` created from the MW5HOTAS folder to the MW5 `SavedHOTAS` folder
9. **IF YOU WANT TO STOP USING MW5HOTAS / UCR, REVERT TO YOUR ORIGINAL HOTASMappings.Remap FILE OR EDIT IT ACCORDINGLY**



### Step 3 - Install UCR and create a profile for MW5

1. Download UCR from the [UCR release page](https://github.com/Snoothy/UCR/releases)
2. Unblock the UCR zip as you did with the MW5HOTAS zip (Right click the zip, properties, check the unblock box)
3. Extract the UCR zip to a folder, and run `UCR.exe`![](https://i.imgur.com/2AtcFGC.png)
4. Click the + button next to `Profiles`, name it `MW5`, then in the left `Input Devices` column, check all the sticks you wish to use with MW5 and in the right `Output Devices` column, check `vJoy Stick 1`
   ![](https://i.imgur.com/RhVaep0.gif)
5. Click `Create`, a new window should appear
   ![](https://i.imgur.com/VtXf242.png)



### Step 4 - Create a test mapping in UCR

1. Click the + next to Axis To Axis in the Plugins list, type X into the Mapping Name box
   ![](https://i.imgur.com/6cvYcJj.png)

2. Map the X axis of one of your sticks to the X axis of the vJoy stick
   ![](https://i.imgur.com/oz9aczu.gif)

3. Click the Save button (Floppy disk icon) in the top left of the window

4. Click the Play icon next to the Save button  
   The X axis of your stick should now operate the X axis of the vJoy stick.  
   You can use the vJoy monitor to verify that this is the case - it should look like this when you move the X axis of your stick:  
   ![](https://i.imgur.com/m2vZPyZ.gif)

   If it does not, ensure that you closed the vJoy Feeder window that you had open before



### Step 5 - Test in MW5

1. Fire up MW5 and go to the Joystick Options menu
2. Ensure that all the Sensitivity Sliders are at `1.00`
   ![](https://i.imgur.com/yn6mCo4.png)
3. Configure the `Horizontal Look Axis` to map to `Joystick Axis 1`
   ![](https://i.imgur.com/7GCnZN7.png)
4. In MW5, launch Instant Action
5. The X axis of your joystick should twist the torso left and right



### Step 6 - Configure Axes as required in UCR / MW5

1. Tab back into UCR and click the Stop icon at the top the profile  
   **You will not be able to edit the UCR profile while it is active!**
2. Use additional `Axis To Axis` plugins to map physical stick axes to vJoy axes (As in Step 4.1 above)  
   **Only use the first 4 vJoy axes (X, Y, Z and Rx)**. X maps to `Joystick Axis 1` in the MW5 menu, Y maps to `Joystick Axis 2`, etc...
   ![](https://i.imgur.com/IwKmPBf.png)
   You can use the `Input` drop-down (That is showing `T.16000M` in the screenshot above) to select which of your input devices the input comes from
3. You can tweak the mapping using the settings in the plugin  
   Invert inverts the axis  
   Sensitivity configures a sensitivity curve for the mapping - 50% sensitivity will mean that at low stick deflections, the amount of output will be reduced  
   Deadzone configures a deadzone for the axis  
4. You do not need to quit MW5 as you make each mapping, you can tab out of MW5, alter settings in UCR, then tab back into MW5
5. **BE SURE TO SAVE THE PROFILE IN UCR AS YOU MAKE CHANGES, IT CAN SOMETIMES LOCK UP AND YOU COULD LOSE YOUR CHANGES**
6. After making each change, be sure to click the Play icon to reactivate the profile before tabbing back into MW5



### Step 7 - Configure Buttons

1. This is basically the same as configuring axes, use a `Button To Button` plugin in UCR to map a button from one of your physical sticks to a button on the vJoy stick



### Additional information

1. UCR has many different kinds of plugin - for example, if you have racing style pedals where each pedal is it's own axis, then you can use an `Axis Merger` plugin in UCR to merge the two pedal axes into one vJoy axis
2. If you wish to send keyboard keys in response to joystick button presses, then you need to [install the Interception driver](https://github.com/Snoothy/UCR/wiki/Core_Interception)
3. For help using UCR, first consult the [UCR Wiki](https://github.com/Snoothy/UCR/wiki), then contact us in the [UCR Discord channel](https://discord.gg/MmnhQYQ)