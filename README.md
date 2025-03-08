# Platformer 2D prototype

A simple 2D platformer game prototype built in Unity using assets from the Unity Asset Store.

## Prerequisites
### Software Requirements:
- **Operating System:** Windows (required for running the build)
- **Unity Version:** Unity 6 (or a compatible version)

## Setup
1. Clone this repository:
   ```sh
   git clone https://github.com/PandaCao/2DPlatformer
2. Open the project in Unity 6 (or a compatible version).
3. Make sure the old Input System is enabled:
   - Go to Edit > Project Settings > Player
   - Under Other Settings, set Active Input Handling to Both (Old and New) or Input Manager.
4. Press Play in Unity to test the game.

## Running the Game from Build
If you don't want to open Unity, you can run the pre-built version included in the repository:

1. After cloning the repository, navigate to the Build/ folder.
2. Locate the .exe file inside the Build/ folder.
3. Run the game:
   - Double-click the .exe file to start playing.
   - If Windows blocks it, click More Info > Run Anyway in the SmartScreen prompt.
4. The game should now start and be playable.

## Controls
- **Arrow Keys / A & D** - Move left and right.
- **Space** - Jump.
- **ESC** - Pause Menu.

## Challenges and fixes
- **Tilemap Collisions** – Used **Composite Collider 2D** and adjusted **Tilemap Collider 2D** settings for smoother collision detection (**Composite Operation: Merge**).
- **Player Sticking to Walls** – Adjusted **Friction** in the **Material 2D** settings and fine-tuned **Rigidbody2D constraints**.
- **Player Movement Glitches** – Switched to **Interpolate** in **Rigidbody2D** for smoother motion.
- **UI Scaling** – Set **Anchor Presets** to **Stretch (Full Rect)** in **Rect Transform** for responsive UI scaling.

## Possible Improvements if Given More Time

- **Implement a GameManager using the Singleton Pattern**
  - A Singleton ensures that only one instance of the GameManager exists, efficiently managing global game states across scenes (e.g. appleCounter).

- **Integrate more Sound Effects and some Music**
  - Adding audio elements can significantly enhance player immersion and overall game feel.

### Why Use the Old Input System?
I chose the **old Input System** instead of the new **Input System Package** for the following reasons:

- **Simplicity & Familiarity** – Easier to implement basic movement and interactions without additional setup.
- **Faster Development** – Avoids the extra configuration required by the new system (Action Maps, Input Actions, etc.).
- **No Need for Advanced Features** – The new system is beneficial for complex input handling, but this project didn't require those capabilities.

The old Input System was the most practical choice for a simple 2D platformer, allowing for quicker implementation and iteration.

## Assets Used
- **Pixel Adventure 1** - [Publisher: Pixel Frog](https://assetstore.unity.com/publishers/44925)
- **Buttons Set** - [Publisher: KartInnka](https://assetstore.unity.com/publishers/53314)