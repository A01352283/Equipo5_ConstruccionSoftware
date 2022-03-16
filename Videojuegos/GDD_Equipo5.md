# **Percussion Islands**

## _Game Design Document_

---

##### **Copyright notice / author information / boring legal stuff nobody likes**

Particpants
- Andrés Briseño Celada - A01352283
- Salvador Salgado Normandia - A01422874
- Iván Rodríguez Cuevas - A01781284
- Iwalani Amador Piaga - A01732251

##
## _Index_

---

1. [Index](#index)
2. [Game Design](#game-design)
    1. [Summary](#summary)
    2. [Gameplay](#gameplay)
    3. [Mindset](#mindset)
3. [Technical](#technical)
    1. [Screens](#screens)
    2. [Controls](#controls)
    3. [Mechanics](#mechanics)
4. [Level Design](#level-design)
    1. [Themes](#themes)
        1. Ambience
        2. Objects
            1. Ambient
            2. Interactive
        3. Challenges
    2. [Game Flow](#game-flow)
5. [Development](#development)
    1. [Abstract Classes](#abstract-classes--components)
    2. [Derived Classes](#derived-classes--component-compositions)
6. [Graphics](#graphics)
    1. [Style Attributes](#style-attributes)
    2. [Graphics Needed](#graphics-needed)
7. [Sounds/Music](#soundsmusic)
    1. [Style Attributes](#style-attributes-1)
    2. [Sounds Needed](#sounds-needed)
    3. [Music Needed](#music-needed)
8. [Schedule](#schedule)

## _Game Design_

---

### **Summary**

The primary concept of the game is to incentivize the players to learn about percussive instruments and their importance in music. Some of the ideas presented in the game are: identifying the different percussion instruments, notes, rhythms, and health practices. 

By traveling through the islands and completing mini-games, the player will unlock various percussive instruments that open new paths to explore.

The genre of the game is a pokemon-style RPG, divided into islands that represent sections to learn (health, note and sound recognition, instruments...) they will not be demanding in terms of the use of keys and agile movements with the mouse, addition to be friendly, interactive and intuitive for anyone who wants to learn about percussion.

### **Gameplay**
The gameplay is going to be divided into diferent kinds. The main one is going to be a Pokémon-like RPG exploration inside a tiled map, where the player explores diferent islands and interacts with NPC's and instruments. 

Then, each island is going to have different kinds of minigames, such a trivia relating to information regarding percussion. Another one would be a rhythm game where the player has to play the right notes at the right time, and is scored depending on the precision, like Taiko no Tatsujin. 

If time allows it, we would to a sound recognition game, where the player would first learn about the sounds of different instruments, and then is asked to recognize the instruments in different clips.

### **Minigames**

Trivia

Memory Games (Identify sounds and notes)

Rythm


### **Mindset**

What kind of mindset do you want to provoke in the player? Do you want them to feel powerful, or weak? Adventurous, or nervous? Hurried, or calm? How do you intend to provoke those emotions?

## _Technical_

---

### **Screens**

1. Title Screen
    1. Options
2. Game
    1. Inventory
    2. Trivia Game
    3. Rhythm game
    4. Memory Game 
    4. Main screen (map navigation)
3. End Credits


### **Controls**

Movement is determined by 'W','A','S','D'. You can interact with NPC's by pressing the 'I' key. Also you can enter buildings by running into the doors.

### **Mechanics**

When the player gets near a building it can enter the building.
Also when the player is near an NPC you can talk to it.
You can interact with obstacles so they can move out the way.
Are there any interesting mechanics? If so, how are you going to accomplish them? Physics, algorithms, etc.

## _Level Design_

---

_(Note : These sections can safely be skipped if they&#39;re not relevant, or you&#39;d rather go about it another way. For most games, at least one of them should be useful. But I&#39;ll understand if you don&#39;t want to use them. It&#39;ll only hurt my feelings a little bit.)_

### **Themes**

1. HUB Island
    1. Mood
        1. Tropical, calm
  2. Objects
        1. _Ambient_
            1. Trees
            2. Rocks
            3. Sand
            4. Buildings
            5. Water
            6. Grass
            7. Fish
            8. Lily pads
            9. Birds
            10. Bonfire
            11. Dock
            12. Waterfall
            13. Jars
        2. _Interactive_
            1. NPC's
            2. Buildings
            3. Obstacles (Birds)
2. First Island
    1. Mood
        1. Calm, urban
    2. Objects
        1. _Ambient_
            1. Roads
            2. Buildings
            3. Trees
            4. Grass
            5. Plants
            6. Jars
            7. Water
            8. Birds
            9. Books
            10. Rocks
            11. Crates
            12. Pond
        2. _Interactive_
            1. NPC's
            2. Buildings


### **Game Flow**

1. Player starts in the island hub at the dock
2. Must move foward to encounter the first NPC.
3. Player talks to the NPC and the NPC tells him to go to the house to the left and enter it.
4. Player walks foward, then to the left to encounter the house and enter it.
5. Player talks to the NPC at the house, the NPC explains the percussion instruments and gives the player some drums ("Drums" acquired). Then the NPC tells him to go to the first percussion island located at the right.
6. Player exits the house and walks to the right.
7. Player encounters the first obstacle (birds at the dock) so the player must play the drums in order to clear the dock and keep moving foward.
8. Player arrives to the first percussion island
9. Player talks to the NPC that will explain him the basics of the island.
10. Player moves to the right in order to get to the edge of the island.
11. Player moves foward in order to encounter the music store.
12. Player enters music store.
13. Player talks to the NPC at the music store, the NPC explains the different sounds of percussion instruments.
14. Player walks out of the music store, and explores the map in order to find a red house.
15. Player moves foward in order to encounter the red house and enter it.
16. Player talks to the NPC at the red house and plays the first mini game, where the player must recognize the different instruments sounds.
17. Player is awarded a...
18. Player walks out of the house 


## _Development_

---

### **Abstract Classes / Components**

1. BasePhysics
    1. BasePlayer
    2. BaseNPC
    3. BaseObject
2. BaseObstacle
3. BaseInteractable

### **Derived Classes / Component Compositions**

1. BasePlayer
    1. PlayerMain
    2. PlayerUnlockable
2. BaseNPC
    1. KeyNPC
    2. FillerNPC
3. BaseObject
    1. ObjectInstrument (pick-up-able, playable, key item)
    2. ObjectJournal (given by NPC, openable through inventory screen)
4. BaseObstacle
    1. ObstacleBirds (moved with first instrument)
    2. ObstacleWall (includes houses, trees and other structures)
    3. ObstacleWater (defines the bounds of the map)
5. BaseInteractable
    1. InteractableInstrument (non-pick-up-able, produces sound when interacted with)

## _Graphics_

---

### **Style Attributes**

For this game, we are using as primarly inspiration the classic Pokemon RPG games, which most of the time use vibrant and joyful colors. To truly make the esthetic of the game as consistent as possible, we are going to define specific colors on our sprites that must match in every section of the game.

![](gametiles.jpeg)

Graphic-wise, we decided to create a 2D RPG pixel game. Not only this style will allow us to improve on other aspects of the game (minigames, soundtrack) but also provoke a relaxing gaming experience. 

Most of the learning of percussion instruments will be in the various minigames. With that said, this section must be well developed to incentivize the players to keep learning and playing.

### **Graphics Needed**

1. Characters
    1. Human-like
        1. Goblin (idle, walking, throwing)
        2. Guard (idle, walking, stabbing)
        3. Prisoner (walking, running)
    2. Other
        1. Wolf (idle, walking, running)
        2. Giant Rat (idle, scurrying)
2. Blocks
    1. Dirt
    2. Dirt/Grass
    3. Stone Block
    4. Stone Bricks
    5. Tiled Floor
    6. Weathered Stone Block
    7. Weathered Stone Bricks
3. Ambient
    1. Tall Grass
    2. Rodent (idle, scurrying)
    3. Torch
    4. Armored Suit
    5. Chains (matching Weathered Stone Bricks)
    6. Blood stains (matching Weathered Stone Bricks)
4. Other
    1. Chest
    2. Door (matching Stone Bricks)
    3. Gate
    4. Button (matching Weathered Stone Bricks)


## _Sounds/Music_

--- 

### **Style Attributes**

The main objective of our game is to teach the players about the different types of percussion instruments and their importance in music. With this in mind, it is vital to include music that utilizes this type of instrument. The rhythm minigame will have various songs, in which percussion instruments are in the main spotlight. 

For the background music played while the player explores the map, we are going to use songs that resemble the relaxing atmosphere of the famous game Animal Crossing.

### **Sounds Needed**

1. Effects
    1. Soft Footsteps (dirt floor)
    2. Sharper Footsteps (stone floor)
    3. Soft Landing (low vertical velocity)
    4. Hard Landing (high vertical velocity)
    5. Glass Breaking
    6. Chest Opening
    7. Door Opening
    8. Hits 
2. Feedback
    1. Relieved &quot;Ahhhh!&quot; (health)
    2. Shocked &quot;Ooomph!&quot; (attacked)
    3. Happy chime (extra life)
    4. Sad chime (died)

Possible Musical notes:
1. playable instrumets:
    - Xilophone
    - Marimba
    - Bongo
    - Tarola 
2. Non-playable instruments:
    - Triangle
    - Gong
    - Maracas or Castanets
    - Tambourine
    - Box 

### **Music Needed**

1. Slow-paced, nerve-racking &quot;forest&quot; track
2. Exciting &quot;castle&quot; track
3. Creepy, slow &quot;dungeon&quot; track
4. Happy ending credits track
5. Rick Astley&#39;s hit #1 single &quot;Never Gonna Give You Up&quot;

Main inspiration: pokemon, animal crossing

- Title theme (adventurous)
- Hub island theme (pokemon first town inspired)
- First island theme (normal Pokémon/Animal Crossing inspired)
- House theme (calm house RPG music)
- Trivia game theme (upbeat)
- Rhythm game theme (will use our own MIDI samples)
- Memory game theme (calm, helps focus)


## _Schedule_

---

_(define the main activities and the expected dates when they should be finished. This is only a reference, and can change as the project is developed)_

1. develop base classes
    1. base entity
        1. base player
        2. base enemy
        3. base block
  2. base app state
        1. game world
        2. menu world
2. develop player and basic block classes
    1. physics / collisions
3. find some smooth controls/physics
4. develop other derived classes
    1. blocks
        1. moving
        2. falling
        3. breaking
        4. cloud
    2. enemies
        1. soldier
        2. rat
        3. etc.
5. design levels
    1. introduce motion/jumping
    2. introduce throwing
    3. mind the pacing, let the player play between lessons
6. design sounds
7. design music