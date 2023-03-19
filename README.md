# saboteurGame


## AI Implementations
We have implemented two AI-controlled non-player characters (NPCs): a fox and a dwarf enemy. The fox has a single state of continuous movement, with random directional changes, and will periodically drop ores. The dwarf enemy, on the other hand, has three states: idle, walking, and digging. We have designed the locomotion of both NPCs to be smooth, utilizing predominantly root motion for humanoid characters.

The primary task of the dwarf enemy is to determine its ability to reach a destination. If it can reach a destination, it will navigate to it using pathfinding techniques. If not, it will prioritize obtaining the nearest available ore. Once a certain number of ores have been collected, the dwarf enemy can construct a new bridge.

To ensure the effectiveness and believability of the AI, we have designed the pathfinding algorithm to be reasonably effective and have prioritized believable NPC behavior. Additionally, we have implemented a script to regenerate the navmesh every 5 seconds to account for any changes in the environment that may affect pathfinding.