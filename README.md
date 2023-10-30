# Digimon game alpha


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