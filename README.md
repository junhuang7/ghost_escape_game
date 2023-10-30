# Digimon game alpha


## Where to start the scene
- Start scene file called MainMenu.unity can be found in Assets\Horror FPS KIT\HFPS Assets\Content\Scenes. When load the main menu, we can click play new Game to initialize the scene. Or the main scene file called TheHouse Demo.unity can be found and checked directly at  Assets\Horror FPS KIT\HFPS Assets\Content\Scenes\Main Scene.
#How to play
1. Control the heroplayer (Shortcut keys can be modified in the control section of the settings):
- Move Up: W
- Move Down: S
- Move Left: A
- Move Right: D
- Run: Shift 
- Jump: Space
- Pause：Esc
2. Solve the puzzle

3. 
## Scripting and Logic Implementation by Abdulrahman Althobaiti (AA)

- Create a new script named AIAgentChase Script can be found in Assets > Scripts 

1. Initialization (Start method):

- Gets references for the required components.
- Adds required components if not already attached.
- Initiates the chase sequence after a 10-second delay.

2. Game Loop (Update method):

- If the chase has begun, it invokes the method to move towards the HEROPLAYER.
- Checks proximity to the HEROPLAYER. If close enough, it triggers the sound playback and subsequent agent deactivation.

3. Chase Mechanism (ChasePlayer method):

- Sets the AI agent's destination to the HEROPLAYER.
- Updates an animation parameter to potentially reflect walking/running animation based on movement speed.

4. End Chase (DisappearAndPlaySound and DeactivateAfterSound methods):

- Upon reaching the target, the chase sound is played.
- After the sound completes, the agent is deactivated.


## Moving HEROPLAYER Prediction by Abdulrahman Althobaiti (AA)
- attached a VelocityReporter script to the HEROPLAYER, allowing to derive its velocity. Using this information, the Ghost predicts the future position of the HEROPLAYER based on its current position, velocity, and the time it would take for the Ghost to reach that predicted location. This prediction updates every frame, ensuring the Ghosy adjusts its course dynamically. Script can be found Assets > Script.


## Pre-preparation by Zifeng Zhang (ZZ)
- Create rooms for escape； Creat a 3D door model; Make an Animator Controller; Design a door open animation inside the Animator.

## Scripting and Logic Implementation by Zifeng Zhang (ZZ)
- Create a new script named DoorOpenController can be found in Assets > Scripts 
1. Declare Variables:

-Create two private variables: isDoorOpen (to track if the door is open) and doorAnimation (to hold the Animation component).
Start Method:

2. In the Start() method:
-Get the Animation component attached to the GameObject.
-Check if the doorAnimation or the "Door_Open" animation clip is missing and log errors if so.
3. ToggleDoor Method:
-A public method called ToggleDoor() is defined:
-It checks if the door is closed (isDoorOpen is false).
-If the door is closed, it plays the "Door_Open" animation if doorAnimation is not null.
-Sets isDoorOpen to true to indicate that the door is open.# Digimon game alpha


## Where to start the scene
- Start scene file called MainMenu.unity can be found in Assets\Horror FPS KIT\HFPS Assets\Content\Scenes. When load the main menu, we can click play new Game to initialize the scene. Or the main scene file called TheHouse Demo.unity can be found and checked directly at  Assets\Horror FPS KIT\HFPS Assets\Content\Scenes\Main Scene.
#How to play
1. Control the heroplayer (Shortcut keys can be modified in the control section of the settings):
- Move Up: W
- Move Down: S
- Move Left: A
- Move Right: D
- Run: Shift 
- Jump: Space
- Pause：Esc
2. Solve the puzzle

3. 
## Scripting and Logic Implementation by Abdulrahman Althobaiti (AA)

- Create a new script named AIAgentChase Script can be found in Assets > Scripts 

1. Initialization (Start method):

- Gets references for the required components.
- Adds required components if not already attached.
- Initiates the chase sequence after a 10-second delay.

2. Game Loop (Update method):

- If the chase has begun, it invokes the method to move towards the HEROPLAYER.
- Checks proximity to the HEROPLAYER. If close enough, it triggers the sound playback and subsequent agent deactivation.

3. Chase Mechanism (ChasePlayer method):

- Sets the AI agent's destination to the HEROPLAYER.
- Updates an animation parameter to potentially reflect walking/running animation based on movement speed.

4. End Chase (DisappearAndPlaySound and DeactivateAfterSound methods):

- Upon reaching the target, the chase sound is played.
- After the sound completes, the agent is deactivated.


## Moving HEROPLAYER Prediction by Abdulrahman Althobaiti (AA)
- attached a VelocityReporter script to the HEROPLAYER, allowing to derive its velocity. Using this information, the Ghost predicts the future position of the HEROPLAYER based on its current position, velocity, and the time it would take for the Ghost to reach that predicted location. This prediction updates every frame, ensuring the Ghosy adjusts its course dynamically. Script can be found Assets > Script.


## Pre-preparation by Zifeng Zhang (ZZ)
- Create rooms for escape； Creat a 3D door model; Make an Animator Controller; Design a door open animation inside the Animator.

## Scripting and Logic Implementation by Zifeng Zhang (ZZ)
- Create a new script named DoorOpenController can be found in Assets > Scripts 
1. Declare Variables:

-Create two private variables: isDoorOpen (to track if the door is open) and doorAnimation (to hold the Animation component).
Start Method:

2. In the Start() method:
-Get the Animation component attached to the GameObject.
-Check if the doorAnimation or the "Door_Open" animation clip is missing and log errors if so.
3. ToggleDoor Method:
-A public method called ToggleDoor() is defined:
-It checks if the door is closed (isDoorOpen is false).
-If the door is closed, it plays the "Door_Open" animation if doorAnimation is not null.
-Sets isDoorOpen to true to indicate that the door is open.
