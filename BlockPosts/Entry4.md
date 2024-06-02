# Entry 4: Milestone 3
## Game design changes

The game design documents have had their last milestones reconsidered, as planning complications hindered the vision of some of the planned features, and now the milestones are hopefully more achievable. Another sad note is that the villagers on a few other npcs despite being left on the design document is not planned to be finished for the initial "release" of the game.

A positive update for the document is the addition of more in depth description of some of `The Partys` members.

## Pathing

For making npc walk around the idea of creating a list of checkpoint and then have the npc object walk from each checkpoint to the next. The most obvious way of doing this would be to just have a vector for each checkpoint, this however would make it very hard to actually know where the npc is actually gonna walk. A great solution to solving this problem is to make use of Gizmos.

### Gizmos

Gizmos are a great tool to be able to get visual cues about some of the objects you are working on. For the purpose of this use case, using gizmos allows for creating paths with game objects and then draw where the game objects are, and a line to the next game object, to the scene view. In this example 15 checkpoints have been created as game objects and are then drawn to the scene view as circles. A line is drawn in sequence between each of the checkpoints.

![gizmos](./BlockpostAssets/Screenshot%202024-05-31%20210321.png)

By using gizmos for this purpose a path can quickly be created, and you can view where the npc will walk during run time.

### Following the path

When following the path the npc will teleport to the first checkpoint and then walk in a strait line towards the next checkpoint. During this the npc walks at a constant speed, no matter if they would walk into the player or an obstacle. The npc will then just stop once there are no more checkpoints on the path.

## Dialogue options

When having dialogue it would also be nice to allow the user to pick different dialogue options to respond to what the npc are saying to them. For giving dialogue options each dialogue button is given a list of dialogue options.

### Dialogue event system

In order to have dialogue interact with other systems a solution could be to have dialogue fire events when finishing a dialogue and/or when picking a dialogue option. Doing this all the dialogue system itself to not have to know about whether any other system cares about what has happened during dialogue. As an example for this implementation quest dialogue will fire an event that the quest tracking system then can read, and tell a quest that progress towards finishing the quest has happened.

### Idle and Special dialogue stack

With a questing system, you might want to be able to have a npc have certain dialogue that should only be shown once you acquire the quest or progress into the quest. While the player has no quest you then might want them to have a list of idle dialogues that happens when a player talks to them. 

The design picked for this idea is to give all npc one list idle dialogue, and a stack of scheduled dialogue. By using a stack for scheduled dialogue, it can be insured that the newest dialogue will always be the first one given to the player. As all quests are already started with a dialogue anyway, then the dialogue scheduler can just listen for when another activating dialogue finishes.