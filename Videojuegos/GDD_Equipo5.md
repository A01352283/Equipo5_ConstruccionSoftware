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

- Trivia
- Memory Games (Identify sounds and notes)
- Rhythm

### **Mindset**

(Mor info Salvador)

When the player is navigating the map, we want to provoke a calming feeling, because of the island theme. We also want to make the player curious so they explore all the game has to offer.

During the minigames, we want to pressure the player a little bit, because that's where they get tested on their knowledge.

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

The pause menu is opened with the escape key, it's navigated with 'W','A','S','D', things are selected with 'I' and you go back with 'O'. The trivia and memory games are played with those same controls.

*Especificar cada minigame (Salvador)

_(Controls for the rhythm game are TBD) The idea is to use the A and D keys to hit the notes_

### **Mechanics**

*DE TODO LOS MINIJUEGOS 
A donde te puedes mover
Interacciones (IWALANI)*

- General mechanics:
    - The player can to move in the four cardinal points. 
    - When the player gets near a building it can enter the building.
    - Also when the player is near an NPC you can talk to it.
    - If an obstacle blocks the way but the challenge has not been solved, you cannot proceed to the next island.
    - You can interact with obstacles so they can move out the way.
    - Can be interacted with randomly placed instruments within the island. 
    - Instruments found on the island can be stored in the inventory.
    - You can select instruments from the inventory to see their information or listen to their sound.
    - There are non-interactive objects that block the way (structures, end of the island, trees, rocks...).

Mechanics of mini-games: 
- In case of losing the game, in all mini-games the player has the option to retry or return to the island map.
1. Memory notes / sounds 
    - Click on the instruments/notes (as appropiate) to generate the sound corresponding to the element.
    - If the elements are selected in the correct order, generate a melody with the selected sounds.
    - The intensity and speed at which the sounds are displayed increase upon successful completion of a sequence.
2. Trivia 
    - If necessary, the player can scroll the screen to see all the questions.
    - The answers are multiple choice, the player must select one of the answer boxes corresponding to the question.
    - At the end you will find a box to send the answers. 
3. Rhythm 
    - According to the letters selected on the keyboard, the player must press the corresponding key at the moment. 
    - As the correct hits are made, the sounds generated by the note are heard.
    - if the player does not make a hit or presses the wrong key no sound is generated (sound muffled).



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

*MINIGAMES
(Iván)

### **Game Flow**

1. Player starts in the island hub at the dock
2. Must move upward to encounter the first NPC.
3. Player talks to the NPC and the NPC tells him to go to the house to the left and enter it.
4. Player moves upward, then to the left to encounter the house and enter it.
5. Player talks to the NPC at the house, the NPC explains the percussion instruments and gives the player some drums ("Drums" acquired). Then the NPC tells him to go to the first percussion island located at the right.
6. Player exits the house and walks to the right.
7. Player encounters the first obstacle (birds at the dock) so the player must play the drums in order to clear the dock and keep moving foward.
8. Player arrives to the first percussion island
9. Player talks to the NPC that will explain him the basics of the island.
10. Player moves to the right in order to get to the edge of the island.
11. Player moves upward in order to encounter the music store.
12. Player enters music store.
13. Player talks to the NPC at the music store, the NPC explains the different sounds of percussion instruments.
14. Player walks out of the music store, and explores the map in order to find a red house (Player must move downward and to the left).
15. Player moves upward in order to encounter the red house and enter it.
16. Player talks to the NPC at the red house and plays the first mini game, where the player must recognize the different instruments sounds.
17. Player is awarded a ...(still in development)... ("..." acquired).
18. Player walks out of the house and moves down to the vegetable patch.
19. Player talks to the NPC at the vegetable patch.
20. Player plays the ...(still in development)... to help the vegetables grow.
21. Player talks again to the NPC and tells him to go to the blue house.
22. Player moves upward and to the right, then downward, in order to encounter the blue house.
23. Player enters the blue house.
24. Player talks to the NPC and his final mini game at the island begins.
25. Player plays the rythm game.
26. Player talks to the NPC and gives him ...(still in development)... ("..." acquired).
27. Player exits the house.
28. Player moves upward and to the left.
29. Player exits the island and comes back to the hub island.
30. Player moves to the left and encounters the second obstacle (still in development).


## _Development_

---

### **Abstract Classes / Components**

1. BasePhysics
    1. BasePlayer
    2. BaseNPC
    3. BaseObject
2. BaseObstacle
3. BaseInteractable
4. BaseInvetory

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
        1. Main character (idle, walking, item get)
        2. NPC villagers (idle, walking)
    2. Other
        1. Birds (toucans) (idle, flying)
2. Ground layer 
    1. Dirt
    2. Dirt/Grass
    3. Stone Block
    4. Stone Bricks
    5. Wooden Floor
    6. Dirt Path
    7. Rocky shores
    8. Bridges
    9. Brick floor
    10. Water (with current, fishes, lily pads, rocks)
    11. Flowers
3. Ambient
    1. Tall Grass
    2. Tree stumps
    3. Vines
    4. Berries
    5. Trees
    6. Berry bushes
    7. Campfires
    8. Logs
    9. Benches
    10. Wooden signs
    11. Barrels
    12. Pots
    13. Crops (carrots, watermelons)
4. Structures
    1. Houses
    2. Market stands
    3. Sign posts
    4. Well
5. Inside houses
    1. Tables
    2. Chairs
    3. Counters
    4. Drawers
    5. Carpets
    6. Kitchen sink
    7. Paintings
    8. Potted plants
    9. Books
6. Other
    1. Chest
    2. Door (open and closed)
    3. Windows
    4. Chimneys (can have animated smoke)
    5. Roofs
    6. Market goods (food in crates, on the stands)
    7. Instruments (Interactibles and pick-up-ables)

*Minigames (Andres) 

## _Sounds/Music_

--- 

### **Style Attributes**

The main objective of our game is to teach the players about the different types of percussion instruments and their importance in music. With this in mind, it is vital to include music that utilizes this type of instrument. The rhythm minigame will have various songs, in which percussion instruments are in the main spotlight. 

For the background music played while the player explores the map, we are going to use songs that resemble the relaxing atmosphere of the famous game Animal Crossing.

### **Sounds Needed**

1. Effects
    1. Chest Opening
    2. Door Opening
    3. Menu navigation (move and confirm)
    4. Dialogue interaction (confirmation sounds) 
    5. Instrument samples (snare, xylophone, marimba, etc.)
    6. Birds getting scared
    7. Ambient water and air
2. Feedback
    1. Happy chime (item get)
    2. Progression success (ex. scaring birds)

Possible Musical notes:
1. playable instrumets:
    - Xilophone
    - Marimba
    - Bongo
    - Snare 
2. Non-playable instruments:
    - Triangle
    - Gong
    - Maracas or Castanets
    - Tambourine
    - Box 

### **Music Needed**

Main inspiration: pokemon, animal crossing, stardew valley

- Title theme (adventurous)
- Hub island theme (pokemon first town inspired)
- First island theme (normal Pokémon/Animal Crossing inspired)
- House theme (calm house RPG music)
- Trivia game theme (upbeat)
- Rhythm game theme (we'll use our own MIDI samples)
- Memory game theme (calm, helps focus)


## _Schedule_

Estimated times 

1. develop base classes   -  2 Days 

    1. Base Physics 
    2. Base Player 
    3. Base NPC 
    4. Base Obstacle 
    5. Base Interactable 
       
2. base app state  -- 2 Days 
     1. Intoduction to the game (Explation) 
     2. Hub (principal island) 
     3. Secondary islands (activities) 
           - Zone to learn, museum
           - Memory and rhythm minigames
      4.  Game state
            - Start game 
            - Game over 
            - Game winner 
3. develop player and basic block classes -- 5 Days 
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
4. find some smooth controls/physics  -- 5 Days 
    1. Movement ("WASD")
    2. Interaction with NPC´s 
    3. Entering and leaving houese/rooms 
    4. Return to the previus screen 
   
5. develop other derived classes  -- 5 Days 
    1. Mini-games 
        1.  memory 
           - Select element 
           - Generate sounds 
           - Show notes 
        2. Trivia
          - Generate question 
          - Select answer  
          - Show qualification 
        3. Rhythm
          - Generate tone 
          - Show notes 
          - Determination of keys 
          - Hits 
     
6. design levels -- 10 days 
    1. Introduce movement in character 
    2. Principal isaland (Hub) 
    3. Introduction to game (Firts interaction with NPC´s) 
    4. Interacting with structures (leaving and entering houses)
    5. Interior designs of the first houses  
    6. Interaction to the islands (effects and designs)
    7. Crossing to other islands 
    8. First obstacle 
    9. Minigames in secondary island 
    10. Others interactions with NPC´s 
    11. Enemies blocking the way 
    12. Instruments around the islands 
    13. Generate inventary 
    
7. design sounds -- 3 Days 
    1. Background sounds 
        1. fire sounds
        2. waves / water in motion 
        3. bird sounds
        4. air /tree movement 
    2. Effects  
       1. Collision (blocked structures) 
       2. Winner game 
       3. Game over 
       4. Selection (in menu bar / instruments inventory)
       5. Recolection of new item (sound of the new instrument) 

8. design music  -- 3 Days 
     1. Initial music
     2. Island music (while the player is navigating the map)
     3. Rooms music (inside the rooms) 
     4. Mini-games musics
        1. Memory (series of notes)
        2. Rhythm (Percussion tones)
