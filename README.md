# Digimon_Ghost Escape: Haunted Mansion_Game Alpha

## Starting the Game
- **Main Menu Scene**: Load the scene `MainMenu.unity` found in `Assets\Horror FPS KIT\HFPS Assets\Content\Scenes`. Click "Play New Game" to initialize the game.
- **Main Game Scene**: Alternatively, you can directly load the main game scene `TheHouse Demo.unity` located at `Assets\Horror FPS KIT\HFPS Assets\Content\Scenes\Main Scene`.

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
- **Functionality**: The AI agent initiates a chase sequence, following the HEROPLAYER. It checks proximity and deactivates upon catching the player, playing a sound effect.

### HEROPLAYER Movement Prediction (by Abdulrahman Althobaiti - AA)
- **Script Location**: `Assets\Scripts\VelocityReporter.cs` (attached to HEROPLAYER)
- **Functionality**: Predicts the future position of the HEROPLAYER based on its current position and velocity, allowing the AI agent to adjust its course dynamically.

### Pre-preparation for Escape Rooms and Door Opening Mechanism (by Zifeng Zhang - ZZ)
- **Contributions**: 
  - Created rooms for escape.
  - Designed a 3D door model.
  - Developed an Animator Controller and a door opening animation.

### Door Opening Mechanism (by Zifeng Zhang - ZZ)
- **Script Location**: `Assets\Scripts\DoorOpenController.cs`
- **Functionality**: Controls the opening of doors when certain conditions are met.

### Cube Sequence Checker and Puzzle Logic (by Jun Huang - JH)
- **Script Location**: `Assets\Scripts\CubeSequenceChecker.cs`
1. **Cube Interaction and Sequence Checking**: 
    - The game involves a series of cubes, each identifiable by a unique number.
    - The player is required to interact with these cubes following a specific sequence: `6, 4, 5, 7`.
    - When the player is within a certain distance (`detectionDistance`) from a cube, the script checks if the cube is part of the target sequence.
    - Correct interactions temporarily change the cube's color to red, providing visual feedback.
    - Upon successfully completing the sequence, all cubes in the target sequence change their color to green, serving as a success indicator.

2. **Dynamic Hints System**:
    - The player is welcomed with an initial hint displayed on the screen: "Welcome, 10 boxes in the room, figure out what boxes are important for solving the puzzle". This message stays visible for 3 seconds.
    - After 30 seconds, if the player has not progressed, a second hint appears: "Now you might have noticed that four boxes are related to the game, now please visit them again in a sequence. Think about the course code of video game design, it is CS-6 what?" This hint also remains visible for 5 seconds, guiding the player towards the puzzle solution.
    - Hints are displayed centrally on the screen with an adjusted font size and with horizontal stretching to ensure readability.

3. **Door Opening Mechanism Integration**:
    - The script is directly connected to a `DoorOpenController` (presumably implemented by Zifeng Zhang - ZZ).
    - Once the player completes the cube sequence correctly, the linked door is triggered to open, indicating the puzzle's successful completion.

4. **Code Quality and Structure**:
    - The script is well-structured with separate methods handling specific functionalities, such as `ChangeColorTemporarily`, `ShowHint`, and `CheckSequence`.
    - Extensive use of Coroutines allows for timed events and animations, contributing to the dynamic nature of the puzzle and improving player experience.
    - The code includes error handling and validations, ensuring robustness.

- **Usage**: Attach this script to an empty GameObject and assign the `HEROPLAYER`, cube array, `hintText`, and `doorOpenController` in the inspector.

## Contact and Credits
- Abdulrahman Althobaiti (AA) - Author of the AI Agent Chase and HEROPLAYER Movement Prediction 
- Zifeng Zhang (ZZ) - Author of the Escape Rooms and Door Opening Mechanism
- Jun Huang (JH) - Author of the Cube Sequence Checker and Puzzle Logic

Thank you for playing Ghost Escape: Haunted Mansion game alpha presented by team Digimon!
