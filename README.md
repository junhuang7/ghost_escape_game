# Digimon_Ghost Escape: Haunted Mansion_Game Alpha

## Starting the Game
- **Main Menu Scene**: Load the scene `MainMenu.unity` found in `Assets\Horror FPS KIT\HFPS Assets\Content\Scenes`. Click "Play New Game" to initialize the game.
- **Main Game Scene**: Alternatively, you can directly load the main game scene `TheHouse Demo.unity` located at `Assets\Horror FPS KIT\HFPS Assets\Content\Scenes\Main Scene`[^1].

## How to Play
### Player Controls
- **Move Up**: W
- **Move Down**: S
- **Move Left**: A
- **Move Right**: D
- **Turn**: Mouse
- **Run**: Shift
- **Jump**: Space
- **Pause**: Esc

### Objectives
1. Solve puzzles and navigate through the environment.
2. Interact with objects to progress in the game.

## Game Mechanics and Scripting

### AI Agent Chase (by Abdulrahman Althobaiti - AA)
- **Script Location**: `Assets\Scripts\AIAgentChase.cs`
- **Functionality**: The AI agent initiates a chase sequence, following the HEROPLAYER. It checks proximity and deactivates upon catching the player, playing a sound effect. The AI agent is a ghost purchased from Unity Store [^2], but the code controlling the AI agent is original work from AA.

### HEROPLAYER Movement Prediction (by Abdulrahman Althobaiti - AA)
- **Script Location**: `Assets\Scripts\VelocityReporter.cs` (attached to HEROPLAYER)
- **Functionality**: Predicts the future position of the HEROPLAYER based on its current position and velocity, allowing the AI agent to adjust its course dynamically.

### Player Health Management (by Abdulrahman Althobaiti - AA)
- **Script Location**: `Assets\Scripts\PlayerHealth.cs`
- **Functionality**: This script manages the player's health in the game. It includes features such as updating health UI, playing damage sound effects, handling player death, and providing gameplay hints. The script uses Unity's UI Text for displaying health and messages, and incorporates audio and camera manipulation to enhance the death sequence. The player's health is reduced upon taking damage, and various UI elements are activated or deactivated based on the health status.

### Player Spell Casting (by Abdulrahman Althobaiti - AA)
- **Script Location**: `Assets\Scripts\PlayerSpellCasting.cs`
- **Functionality**: This script enables the player to cast spells in the game. It is primarily designed to interact with a ghost character, presumably an AI agent. The key features include playing a spell audio clip when a spell is cast and checking the spell's effect on the ghost character within a specified range. The spell is activated by pressing the 'E' key. If the ghost is within the spell's range, it triggers a specific response in the ghost (handled by AIAgentChase2.cs script).

#### AI Agent Chase Version 2 (by Abdulrahman Althobaiti - AA)
- **Script Location**: `Assets\Scripts\AIAgentChase2.cs`
- **Functionality**: This script is responsible for controlling an AI agent's behavior in the game. It uses Unity's NavMeshAgent to enable the AI agent to chase the HEROPLAYER character. Key features include initiating a chase sequence after a delay, handling player collision to execute an attack. The script also includes functionality for the AI agent to react to player spells, causing it to disappear after a specific spell is cast nd playing a disappear sound.

### Preparation for Escape Rooms and Door Opening Mechanism (by Zifeng Zhang - ZZ)
- **Contributions**: 
  - Created rooms for escape.
  - Designed a 3D door model.
  - Developed an Animator Controller and a door opening animation.

### Door Opening Mechanism (by Zifeng Zhang - ZZ)
- **Script Location**: `Assets\Scripts\DoorOpenController.cs`
- **Functionality**: This script controls door interactions, leveraging Unity's Animation component.

#### Overview:
- **Initialization**: On start, it checks for an Animation component and a "Door_Open" animation clip.
  - Missing Animation component logs: "Animation component is missing!"
  - Missing animation clip logs: "Animation clip 'Door_Open' is missing!"
- **Toggle Door**: The `ToggleDoor` method opens the door if it's closed and the required components are present.
- **Animation Integration**: Requires the door GameObject to have an Animation component with "Door_Open" animation.

#### Usage:
1. Attach this script to a door GameObject.
2. Ensure the GameObject has an Animation component with "Door_Open" animation clip.
3. To open the door, ensure it's closed and call `ToggleDoor`.

This implementation ensures a streamlined door interaction, enhancing the game's user experience.

### Puzzle 1: Find the magic sequence (by Jun Huang - JH)
- **Script Location**: `Assets\Scripts\CubeSequenceChecker.cs`
1. **Cube Interaction and Sequence Checking**: 
    - The game involves a series of cubes, each identifiable by a unique number.
    - The player is required to interact with these cubes following a specific sequence: `6, 4, 5, 7`.
    - When the player is within a certain distance (`detectionDistance`) from a cube, the script checks if the cube is part of the target sequence.
    - Correct interactions temporarily change the cube's color to red, providing visual feedback.
    - Upon successfully completing the sequence, all cubes in the target sequence change their color to green, serving as a success indicator.
    - The player is welcomed with an initial hint displayed on the screen: "Welcome, 10 boxes in the room, figure out what boxes are important for solving the puzzle". This message stays visible for 3 seconds.
    - After 30 seconds, if the player has not progressed, a second hint appears: "Now you might have noticed that four boxes are related to the game, now please visit them again in a sequence. Think about the course code of video game design, it is CS-6 what?" This hint also remains visible for 5 seconds, guiding the player towards the puzzle solution.
    - The script is directly connected to a `DoorOpenController`.

### Puzzle 2: Push the GT ball (by Jun Huang - JH)
- **Script Location**: `Assets\Scripts\DoorOpenController2.cs`
- **Functionality**: This script manages the door opening mechanism based on the proximity of Ball1 (Same golden color as the GT logo!) to the door. It checks if Ball1 is within a specified distance (`openDistance`) and then toggles the door open or closed. It includes error logging for missing components and animation clips, providing a robust and user-friendly experience for game developers.

### Puzzle 3: Work with AI (by Jun Huang - JH)
- **Script Location**: `Assets\Scripts\AIPuzzleController.cs`
- **Functionality**: The AI Agent in the game, controlled by the `AIPuzzleController.cs` script, exhibits dynamic behavior that plays a crucial role in the game's puzzle mechanics. The agent alternates between two points - pointA near a red sphere and pointB near a blue sphere - with its movement governed by a state machine featuring states such as `RedSphereChasing` and `BlueSphereChasing`. The agent's proximity to these spheres is constantly evaluated, triggering their activation once within a certain distance (`activationProximity`). This activation changes the sphere's color to green as a visual cue. The core of the puzzle requires both the red and blue spheres to be activated, which, upon completion, triggers the opening of a door. This door opening is accompanied by an animation and a congratulatory message, signaling the player's progress. Additionally, the AI's interaction with the hero player is a vital component, as both the AI's and the player's proximity to the spheres are necessary for their activation, adding an extra layer of complexity and engagement to the puzzle-solving experience.

### Celebration Controller (by Jun Huang - JH)
- **Script Location**: `Assets\Scripts\CelebrationController.cs`
- **Functionality**: This script controls the celebration mechanics in the game. When the player opens all three doors, the script triggers a confetti effect using a ParticleSystem and displays a congratulatory message with TextMeshPro. The message is initially invisible, becoming visible only during the celebration. The script also customizes the appearance of the text, including its size, color, and visibility.

## Contact and Credits
- Abdulrahman Althobaiti (AA) - Author of the AI Agent Chase and HEROPLAYER Movement Prediction 
- Zifeng Zhang (ZZ) - Author of the Escape Rooms and Door Opening Mechanism
- Jun Huang (JH) - Author of the 3 puzzles: `Level 1: Find the magic sequence`, `Level 2: Push the GT ball` and `Level 3: Work with AI`
- The game including codes are hosted in Gatech Github [^3].

Thank you for playing Ghost Escape: Haunted Mansion game alpha presented by team Digimon!

## Known problems
- The wall will sometimes disappear, will try to address later, one solution is to build new walls for the game.
- Some problems with the puzzle logic, if some random visits to the key cubes is ahead of the 6-4-5-7 sequence visit, sometimes the door open mechanims will not be functional. However, a straight visit of 6-4-5-7 sequence from game onset will trigger the door open mechanism for sure, will try to address this issue later.

## References

1. https://assetstore.unity.com/packages/templates/systems/horror-fps-kit-82643
2. https://assetstore.unity.com/packages/3d/characters/creatures/ghost-low-poly-199498
3. https://github.gatech.edu/jhuang709/vgd-2023fall-digimon

It is important to note that our project's scope does not involve incorporating the storyline provided in the horror kit. Instead, our intention is to solely leverage the assets such as rooms, lighting, carpets, and other elements. We are committed to developing our own set of game rules by extensively coding them ourselves. Furthermore, we created custom animations and introduced numerous new elements to the project.
