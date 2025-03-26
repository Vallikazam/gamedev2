# Puzzle 

## Project Details
- **Student**: Alinur Zhumadil
- **Group**: SE-2321
- **Subject**: Introduction to Game Development
- **Assignment**: Assignment 2
  
## Overview
This is a 2D drag-and-drop puzzle game developed in Unity. The objective is to match animals (deer, panda, tiger, turkey) to their corresponding silhouettes. When all animals are correctly placed, a win screen appears with a darkened overlay, a victory message, and a restart button to play again.

## Features
- Drag-and-drop mechanics for animals using mouse or touch input.
- Win condition: all animals must be placed on their matching silhouettes.
- Visual feedback: a darkened overlay and a "You Win" message appear upon victory.
- Restart functionality: a button to restart the game after winning.

## Scripts
- **GameControl.cs**: Manages game logic, including win condition detection, UI (win text, dark overlay, restart button), and scene restart. Uses coroutines for smooth transitions.
- **Tiger1.cs**, **Panda.cs**, **Tiger2.cs**, **Turkey.cs**: Handle drag-and-drop mechanics for each animal. Detect touch/mouse input, move the animal, and snap it to a target position (`*_place`) if within 0.5 units, setting `locked` to true.

## Setup
1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/animal-puzzle-game.git
   ```
2. Open the project in Unity.
3. Ensure the scene is added to Build Settings (`File > Build Settings > Add Open Scenes`).
4. Play the scene in the Unity Editor or build the project for your platform.
