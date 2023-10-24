# Milestone 2 - Physics Simulation 

This README outlines the implemented features for Milestone 2 of the Physics Simulation assignment.

## Personal Information

**Full Name:** Jun HUANG  
**Email:** jhuang709@gatech.edu  
**OIT/Canvas Account Name:** jhuang709 
**GT ID:** 903850764

## Main Scene

The main scene for this project is "demo", and it is located in "Assets/Scenes".

## Features to Observe and Code Locations

### 1. Basic Rigidbodies with Collision Events
**Location in Code:** `Assets/Scripts/AppEvents/BombBounceEvent.cs`
- Three blue rigidbody spheres aligned vertically.
- They topple and roll off one another when the game starts.
- Generates a `BombBounceEvent` upon collision.

### 2. Physics Layers Example
- Three red rigidbody spheres aligned vertically.
- These spheres collapse into and interpenetrate with one another when the game starts.

### 3. Compound Collider for Complex Geometry
- Used the "Free Japanese Mask" from the Asset Store.
- Mask falls over, tipping on its nose at the start.
- Compound collider physics objects mimic the visual dimensions of the mask.

### 4. Chain with Joint Constraints
- A yellow chain of five rigidbody GameObjects.
- Configured with `ConfigurableJoints`.
- Swings slightly at the start of the game.

### 5. Mecanim-Animated Kinematic Elevator
- An empty GameObject named `ElevatorRoot` houses a child blue cube named `Elevator`.
- The elevator rises midway through the animation and returns to its original position.
- A red rigidbody sphere is placed on top of the elevator.

### 6. Customized Center of Mass
**Location in Code:** `Assets/Scripts/Utility/RigidbodyCenterOfMass.cs`
- A green Weeble Wobble or Punching Bozo.
- Set with a custom center of mass to ensure it rocks but doesn't fall over.

### 7. Default Friction
- A purple rigidbody box on the `BetterRamp`.
- Doesn't slide down the ramp.

### 8. Custom Friction (Low)
- A green rigidbody box next to the previous box.
- Modified with a new PhysicsMaterial with low friction.
- Slides down the `Better Ramp` when the game starts.

### 9. Bouncy Rigidbody
- An orange rigidbody sphere with a high bounce value.
- Bounces upon game start.

### 10. Ragdoll
- The `Y_Bot` asset above a hurdle.
- Configured with the Ragdoll Wizard.

### 11. Scripting Forces
**Location in Code:** `Assets/Scripts/CharacterControl/JumpingBean.cs`
- A black click beetle/jumping bean made of a capsule.
- Jumps intermittently with random timings and force magnitudes.

### 12. Pause Script
**Location in Code:** `Assets/Scripts/Utility/PauseScript.cs`
- The game starts paused.
- Pausing toggled with the "p" keypress.

## Incomplete or Buggy Features

- All assignment requirements have been implemented without known bugs.

## Creative Implementations

- The black click beetle/jumping bean (Feature #11) was a creative choice. It jumps intermittently, demonstrating the ability to script physics behaviors in Unity.

## External Assets Used

- **Free Japanese Mask**: Used for the Compound Collider for Complex Geometry feature.

## Build Dependencies

- No special install instructions or dependencies are needed. Ensure the `/Packages/` folder is included.

## Notes

This assignment explores the rigidbody physics simulation capabilities of Unity in preparation for application in larger game projects.
