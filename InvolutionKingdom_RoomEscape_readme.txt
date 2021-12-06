# Room Escape
by Involution Kingdom

### Start scene file
Our start scene is morgueStartMenu, morgue is our main scene

### Play the game

Spoiler Alert! When the game starts, the main character called Eve stands up from the ground and finds herself trapped inside a horrific room. The dialog box would show up and display some background information. The goal is to get Eve out of the scary place. You would use "WASD" or arrow keys to move Eve to explore the house. On the table nearby, there is a note whose corner is torn apart. You have to find the torn part to obtain the next clue. Move Eve to the door and press O to open it. The next lead is inside the trash bin beside the door. This lead is a decoded message. There are twelve characters, composed of eleven X and one O, respectively representing twelve drawers on the wall. Move Eve close to the drawer , where its position corresponds to the position of O, and open it to release a cat that has a key hanging on it. You have to figure out how to obtain the key. Move Eve close to the chest, and open it to get cat food. Put cat food into the bowl at the corner of the room to attract the cat. When the cat is eating the food, you can catch and obtain the key.  Using the key, Eve can finally unlock the other door and escape!

### Technologies:
#### A 3D Game Feel game
We designed a 3D room escape game based on the third-person perspective.

#### Precursors to Fun Gameplay
The purpose of the game is to successfully escape from the room, and rich interactions with the environment are included in the game process so that players can understand how to play the game. The game will start from the simplest mode and provide guidance throughout the whole process. After the player understands the game operation, there will be a more difficult game mode. Players use logical reasoning to get clues, so players need to constantly make choices in the game to find a way to escape the room.

#### 3D Character/Vehicle with Real-Time Control
The characters will move and operate according to the keyboard input of the player in real time. At the same time, the task also includes the dynamic changes of getting up at the beginning, the dynamic changes of limbs when walking, and the dynamic changes when performing actions such as falling. The camera will follow the game characters while moving, but when the characters are too close to the wall, the camera will pass through the wall.

#### 3D World with Physics and Spatial Simulation
We designed and implemented a room which contained various objects as the most basic game environment. Corresponding rigid body and collision body attributes have been added to various items in the room. There will be corresponding sound effects when the character collides with objects, and there will be game sounds at the beginning and end of the game. The environment of the entire house is the boundary of the game. Players can only play in the house and trigger interactions with some items under certain conditions.

#### Real-time NPC Steering Behaviors / Artificial Intelligence
A freely walking cat was implemented to meet the requirements of real-time NPC steering behaviors and artificial intelligence. The initial state of the cat is hiding in the cabinet. When the cabinet is opened, the cat will jump out and walk around at will. In addition to standing still and walking randomly, the cat also has an eating state when they are attracted to food. The player needs to control the character to interact with the cat and get clues.

#### Polish UI system
When entering the game and successfully escaping the room, there will be a UI interface to prompt. UI interactive interfaces such as game guidelines are also designed during the game. At the same time, we also added particle effects to some objects, such as a wooden barrel. The lighting is also designed to match the dim state of the scene.

### TODOs
1. When Eve is too close to a wall, the camera could look through the wall and see objects behind it.
2. Ceilings are not able to block directional light.


### Who did what
*Ren Wang*:
- Level and story design
- Set up the camera system
- Set up the background audio system.
- Set up the reusable dialog UI system(aka DialogManager, DiaglogTrigger etc.)
- Wiring up trigger logic(aka TableTrigger, bucketInteractor, drawerInteractor etc.)

*Hang Yang*:
- Assist the design of character control 
- Assist the design of camera control
- Create terrain and fence objects
- Write the play instruction in the readme document

*Minsheng Han*:
- Design and implement room environment topography
- Particle effects for wooden barrel object
- Animation and trigger event of door, box and cabinet
- Document work on technology requirements part
- Assets implemented:
- Assets/Animation/Box/*
- Assets/Animation/Door/*
- Assets/Animation/Drawer/*
- Scripts:
- Assets/Scripts/Interactables/DoorOpener.cs (partial)
- Assets/Scripts/Interactables/drawerOpen.cs (partial)
- Assets/Scripts/Interactables/BoxOpen.cs

*Fang Zhong*:
- Design and implement start menu, pause menu and ending page, coordinate smooth flow of all canvas layers (including dialog canvas) without conflict
- Button animation and ending trigger event 
- Set up audio system including audio event manager and audio events
- Create event manager
	- Assets implemented:
	- Assets/Scenes/morgueStartMenu
	- Assets/Animation/UI/*
	- Assets/Animator/ButtonAnimatorController
	- Assets/Prefabs/AudioEventManager
	- Assets/Prefabs/3DEventSound
	- Assets/Sounds/*
	- Assets/Textures/UI/*

- Scripts:
	- Assets/Scripts/UI/*
	- Assets/Scripts/AppEvents/*
	- Assets/Scripts/EventSystem/EventManager.cs

*Tengbo Zou*:
- Character control/animation
- AI behaviours/animation
- Interactions between AI, player, object, and dialog (partial)
- Assets implemented:
	- Assets/Animation/Cat/*
	- Assets/Animation/Character/*
	- Assets/Animator/catRootMotionController
	- Assets/Animator/CharactorAnimator
	- Assets/Prefabs/AI/*
	- Assets/Prefabs/Character/*
	- Assets/Prefabs/chest (partial)
	- Assets/Prefabs/door (partial)
- Scripts
	- Assets/Scripts/inputscript.cs
	- Assets/Scripts/Interactables/BowFiller.cs
	- Assets/Scripts/Interactables/CatAI.cs
	- Assets/Scripts/Interactables/DoorOpener.cs (partial)
	- Assets/Scripts/Interactables/drawerOpen.cs (partial)
	- Assets/Scripts/Interactables/InteractableObject.cs
	- Assets/Scripts/Interactables/SimpleOpener.cs

### Citations and Reference:
1. https://www.youtube.com/watch?v=_nRzoTzeyxU
2. https://www.youtube.com/watch?v=jh3zD-wGBnw
3. https://www.youtube.com/watch?v=zc8ac_qUXQY
4. https://www.youtube.com/watch?v=pveer0jDCmk
5. https://www.youtube.com/watch?v=3NBYqPAA5Es
6. https://learn.unity.com/project/john-lemon-s-haunted-jaunt-3d-beginner?uv=2020.3
 
