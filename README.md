# unity-space-defender
A 2d space shooter practice project in unity



## Unity Version
2022.3.2f1 LTS

## Assets Used
Free assets of discontinued glitch game https://www.glitchthegame.com/ \
Fx Explosion Pack from unity assets store \
Font are from https://www.dafont.com/ 

## Concepts Used
- Loading Scenes based on build index and name
- Coroutines
- Using canvas as the game area
- Calculating safe zone of the game area for mobile
- Using world space canvas mode
- Aligning game area sprite units with the world unit of unity
- Spritesheet animation
- keyframe-based animation
- Bone-based animation
- Animation Events
- Animation States
- Animation transitions
- Putting animator and scripts on parent to be able to edit characters position after animation created
- Instantiating prefabs from the location of a game object
- Spawning an object as a child of another object
- Moving objects via code or with animation
- Spawn particle effects at position of a game object
- Converting world space and local space
- Converting screen point to world point
- Detecting mouse down using a collider
- Spawning prefabs in random intervals
- Detecting objects based on the script attached to them
- Kinematic RigidBody2D
- UI Slider
- Storing game settings data in computer using player prefs
- Playing a pesistent music through scenes
- Singleton Pattern
- Static variables to preserve data between scenes
- Using a trigger collider to destroy game objects no longer in use
- Working with material assets
- Applying materials to 3d objects

## Important Notes
**ADD SCENES TO BUILD SETTINGS IN THIS ORDER "SplashScreen" > "WinScreen" > "LoseScreen" > "OptionsScreen" > "StartScreen" > "Level1" > "Level2" > "Level3" > "Level4" > "Level5"**
