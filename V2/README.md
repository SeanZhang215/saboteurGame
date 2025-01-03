# saboteurGame

## Start scene file
The start scene is `IntroMenu` file under `Assets/Scene/`.

## How to play and what parts of the level to observe technology requirements
To start the game, go to the Start Menu and try to defeat the Non-Playable Character (NPC) while collecting the ore they throw on the bridge. Each ore you collect will be converted into a card, with an equal chance of getting either a Destroy card or a Build card. The Destroy card can be used to destroy the bridge, while the Build card can be used to construct a bridge. The card will either have bridge underneath appear or make bridge disappear. Keep track of your available cards and, once a bridge is built, try to beat the NPC and reach the treasure bag before them. Remember whoever reaches the treasure bag first wins the game.  Additionally, you can use the Destroy card to eliminate the bridge and defeat the NPC, thereby winning the game.

## Known problem areas
Occasionally, certain enemies may become trapped in the game.

## Unity models
The game used many unity models from unity store.
The game also built upon a unity tutorial. (game shooting).

## AI Implementations - Xinlu Zhao (xzhao456)
### Alpha
We have implemented two AI-controlled non-player characters (NPCs): a fox and a dwarf enemy. The fox has a single state of continuous movement, with random directional changes, and will periodically drop ores. The dwarf enemy, on the other hand, has three states: idle, walking, and digging. We have designed the locomotion of both NPCs to be smooth, utilizing predominantly root motion for humanoid characters.

The primary task of the dwarf enemy is to determine its ability to reach a destination. If it can reach a destination, it will navigate to it using pathfinding techniques. If not, it will prioritize obtaining the nearest available ore. Once a certain number of ores have been collected, the dwarf enemy can construct a new bridge.

To ensure the effectiveness and believability of the AI, we have designed the pathfinding algorithm to be reasonably effective and have prioritized believable NPC behavior. Additionally, we have implemented a script to regenerate the navmesh every 5 seconds to account for any changes in the environment that may affect pathfinding.

Xinlu Zhao implemented several assets, including `Fox` and `Dwarf Warrior-Enemy`. Animators were also implemented for these assets. Xinlu updated a prefab named `woods06_low` to support some AI related functionality. Additionally, Xinlu developed following C# scripts:
- `NpcAI`: 
    This Unity script controls the behavior of an NPC character, a fox, in a game. The script includes an array of waypoints and a star prefab, as well as variables to determine the chance of dropping a star at each waypoint and the time interval for dropping stars. The script initializes references to the NavMeshAgent and Animator components on the NPC game object, and sets the next waypoint for the NPC to move towards. The script includes a method to drop a star at the NPC's position if it collides with a specified tag and the maximum number of stars in the game has not been reached. The script also includes a method to check if the NPC has reached a waypoint, and if so, sets the next waypoint for the NPC to move towards. Additionally, the script includes a method to draw a wire sphere around the NPC's position for debugging purposes.
- `DwarfEnemyAI`:
    The DwarfEnemyAI Unity script controls the behavior of a dwarf enemy character in a game. It includes methods to find the nearest star and create a bridge after a certain number of stars have been destroyed by the dwarf. The script initializes references to the NavMeshAgent and Animator components on the DwarfEnemyAI game object. The script also includes a public variable to reference the bridge prefab and a public variable to specify the number of stars required to build a bridge. Additionally, the script includes an array of GameObjects to specify potential destinations for the dwarf to go to, and a method to check if the dwarf can reach any of the destinations in the destinations array. The update method in the script updates the animator and handles the destruction of stars and the dwarf's movement towards destinations. It checks if the dwarf can go to any of the destinations in the destinations array, finds the nearest star if there is no current star to go to, starts destroying the current star if the dwarf has reached it, and updates the animator controller based on whether the dwarf is walking or destroying a star.
- `PathVisualizer`:
    This Unity script visualizes the path of a NavMeshAgent on the game object it is attached to. The script initializes a reference to the NavMeshAgent component on the game object in the Start method. The OnDrawGizmos method draws a blue line between each corner of the path using the Gizmos.DrawLine method. The previousCorner variable is used to keep track of the previous corner to draw a line from, and it is initialized to the game object's position.
- `NavMeshBaker`:
    This Unity script is used to build a NavMeshSurface every 5 seconds. The script initializes a reference to a NavMeshSurface component in the scene in the public NavMeshSurface variable. The script includes a coroutine that is started in the Start method and runs indefinitely. The coroutine first builds the NavMeshSurface using the BuildNavMesh method. It then waits for 5 seconds using the WaitForSeconds method before building the NavMeshSurface again.
### Improvements
Xinlu has added colliders to both the NPC and the diamond to make the game more realistic and engaging. The colliders help to ensure that the player interacts with the game elements in a more natural way. This means that players will no longer be able to pass through the NPC or diamond, which will improve the overall gaming experience. Xinlu has also made significant changes to the AI logic. The NPC will now be able to detect the player's position and adjust its behavior accordingly. This means that the NPC will follow the player around, making the game more challenging and engaging. 

## Overall GUI - Yaqi Tu (ytu64)
Five GUI have been implemented: a start menu GUI, a difficulty level GUI, a rule GUI, a win GUI and a lose game GUI.

Start menu GUI: including the button and directiosn to the rule GUI, difficulty GUI and control explanations

Difficutly level GUI: including three levels difficulty, once press the button, the accordingly game will start

Rule GUI: expalnin the rule instructions of the game and button back to the menu

Win GUI: including the option to start this level game again and also the button to back to menu

lose GUI: including the option to start this level game again and also the button to back to menu

For those buttons, when the mouse is on the button, it will change the color and when the mouse press the button, it will finally change to another color.

Besides, the in-game pause menu is installed by pressing the Esc. The in-game pause includes: pause, back to menu, quit the game.

## 3D Character with Real-Time control & Physics - Shaopeng Zhang (szhang737)
- Added Character Controller script, the player can be better controlled for speed, turning motion, jumping motion, and destroying motion.
- Added new motions for the player so it can walk, jump, destroy and turn around. Updated player Animator Controller and Animation. Player speed and rotation speed were also adjusted to maintain consistent spatial simulation throughout. For the action of destroying, when the player gets closer to the Herballist Bag, the player can act on destroying action to collect the resources.
- Worked with Xingyu Chen on Herballist Bag to add Destructible Object script so the Herballist Bag can be destructible.
- Added a sphere to show 3D simulation with six degrees of freedom movement of rigid bodies. This object has Sphere Collider and Planet Controller script so it can move.

### Improvements
Shaopeng edited the collider fo the bridge so when the player gets closer to the edge of the bridge he will fall right away, this update helps the game become more interesting and harder to win.

## 3D Character with Real-Time control & Physics - Xingyu Chen (xchen863)
- Updated main camera from first-person perspective to non first -person perspective. Added script ThirdPersonCamera to enable a smooth camera motion and reasonable camera moving speed.
- Added new motions for the player so it can walk, jump, destroy and turn around. Updated player Animator Controller and Animation. Player speed and rotation speed were also adjusted to maintain consistent spatial simulation throughout. For the action of jump, when pressing the "space" button, the player will be able to jump, and jump higher at the meantime when pressing the "space" button longer.
- Worked with Shaopeng Zhang on Herballist Bag to add Destructible Object script so the Herballist Bag can be destructible.

## Main Character - Qing Li  (qli423)
Fixed bug that user unable to dig dimond. Also updated the logic of how card affect the bridge. 
Fixed menu bug, now user fall under bridge the game failed menu will appear. 
--
Vincent has incorporated several new features into the game. The Main Character now possesses motion capabilities and is capable of gathering dimond. The dimond that is obtained will be converted into game cards, with two different types being randomly distributed. One of the cards can be utilized to construct a bridge, while the other can be employed to destroy a bridge. Additionally, we have implemented a Win menu that is displayed when the player comes into contact with the final treasure bag. Finally, a bagpack has been added to the game to house all of the cards that the player has accumulated. To view the available cards, players may press the 'B' button to open the bag. 
