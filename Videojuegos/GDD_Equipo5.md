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

What kind of mindset do you want to provoke in the player? Do you want them to feel powerful, or weak? Adventurous, or nervous? Hurried, or calm? How do you intend to provoke those emotions?

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

_(Controls for the rhythm game are TBD)_

### **Mechanics**

- When the player gets near a building it can enter the building.
- Also when the player is near an NPC you can talk to it.
- You can interact with obstacles so they can move out the way.
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

What kinds of colors will you be using? Do you have a limited palette to work with? A post-processed HSV map/image? Consistency is key for immersion.

What kind of graphic style are you going for? Cartoony? Pixel-y? Cute? How, specifically? Solid, thick outlines with flat hues? Non-black outlines with limited tints/shades? Emphasize smooth curvatures over sharp angles? Describe a set of general rules depicting your style here.

Well-designed feedback, both good (e.g. leveling up) and bad (e.g. being hit), are great for teaching the player how to play through trial and error, instead of scripting a lengthy tutorial. What kind of visual feedback are you going to use to let the player know they&#39;re interacting with something? That they \*can\* interact with something?

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


## _Sounds/Music_

--- 

### **Style Attributes**

Again, consistency is key. Define that consistency here. What kind of instruments do you want to use in your music? Any particular tempo, key? Influences, genre? Mood?

Stylistically, what kind of sound effects are you looking for? Do you want to exaggerate actions with lengthy, cartoony sounds (e.g. mario&#39;s jump), or use just enough to let the player know something happened (e.g. mega man&#39;s landing)? Going for realism? You can use the music style as a bit of a reference too.

 Remember, auditory feedback should stand out from the music and other sound effects so the player hears it well. Volume, panning, and frequency/pitch are all important aspects to consider in both music _and_ sounds - so plan accordingly!

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

1. Slow-paced, nerve-racking &quot;forest&quot; track
2. Exciting &quot;castle&quot; track
3. Creepy, slow &quot;dungeon&quot; track
4. Happy ending credits track
5. Rick Astley&#39;s hit #1 single &quot;Never Gonna Give You Up&quot;

Main inspiration: pokemon, animal crossing, stardew valley

- Title theme (adventurous)
- Hub island theme (pokemon first town inspired)
- First island theme (normal Pokémon/Animal Crossing inspired)
- House theme (calm house RPG music)
- Trivia game theme (upbeat)
- Rhythm game theme (we'll use our own MIDI samples)
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