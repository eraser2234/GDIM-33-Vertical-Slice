# GDIM 33 Game

## MileStone1

1. 
I use OnTriggerEnter2D and OnTriggerExit2D to detect whether player is close emough to pick up tool. If it's close enough, canPickTool set as True, allows player picks up tool.
![Graph](https://github.com/user-attachments/assets/acaddfeb-c1b4-4efa-b601-07b4ae15b0d9)


2.

In this milestone, I updated my game break-down by integrating a State Machine system to manage player behavior more clearly and modularly. Previously, movement and interaction logic were loosely connected, but now they are organized into defined states such as Idle, Moving, and Interaction. The movement state is activate by the Unity Input System using a Vector2 input from input events, allowing movement control. For interaction, I added trigger detection using OnTriggerEnter2D and OnTriggerExit2D, combined with boolean checks to determine whether the player is within range of an interactable object and able to pick up or use a tool. This update improves readability and scalability compared to handling everything in a single flow.

The State Machine works by transitioning between states based on player input, collision events, and internal conditions. For example, when the player provides movement input, the state switches from Idle to Moving, and when entering an interactable zone, the system enables the Interaction state if conditions are met. This State Machine is connected to Input System for movement control, the Physics system for trigger detection, and the interaction/puzzle system for enabling tool usage and puzzle activation.
![Break down 3](https://github.com/user-attachments/assets/c53b90cb-904e-4688-9645-9648497151cb)


## MileStone2

1.
### Break down - inventory
The player can open the inventory to choose which object to use for solving a puzzle.
The selected item will remain locked as the current active tool.

- The player presses a button to open the inventory.
- Use WASD or arrow keys to hover over options.
- Press Space to select a tool and lock the selected state.
- The inventory closes automatically.
- The player can then use the selected tool.
#### basic steps: 
1. Open and close the inventory.
2. Navigate through the inventory (grid or list system).
3. Select a tool.
#### break down:
1. Create variables to identify which tool the player selects.
2. Detect the X key input to show or hide the inventory UI on the top layer.
3. Move the cursor when WASD is pressed. Use vectors such as (1,0) or (3,2) to identify which item is currently being hovered over. (Hover animation can be added later.)
4. Set variables when Space is pressed to select the tool.
5. Disable the inventory window once the selected variable changes.
6. Use variables as conditions to determine which tool is selected and which puzzle it can interact with.

### Break down - Animator
The character will reflect the player’s movement with animations such as idle, walking.
#### basic steps:
1. Download and add the animations into Unity.
2. Code the state machine and test each state transition with Debug logs first.
3. Use the state machine to change the animations.

#### break down:
1. Download the character asset.
2. Slice the sprite sheet into different frames.
3. Set the images as sprites.
4. Use the Animation window to create animation clips.
5. Use the Animator to control animation transitions.
6. Use nodes to detect player input.
7. Connect the player input to Animator variables.
### 
2. Yes, at some point, it helped me focus on the necessary features.
3. I am still working on the script. I would like to use it to manage items when they are added to the inventory, and it should call scripts from the Graph since it would be easier to manage.
4. The system I used is Animator. I use it to reflect character movement. It shows a mirrored animation when the character moves backward, and it has two animation states: idle and moving.
5. The most complicated gameplay system I made is the inventory system. It can identify which slot is currently being hovered over, and the player can only use a tool when that item is selected. However, even if no item is selected, the player can still press X again to close the inventory. Reopening the inventory resets the hovered state back to the first slot, which is useful if the hover animation disappears.

## Milestone3


### ShaderGraph
![shadergraph](https://github.com/user-attachments/assets/483caf8c-af36-415f-8d40-f1ab859feb57)

I use shader graph on the pickable item.

I created a shine effect using Shader Graph for collectible items in my game. The shader uses a Time node multiplied by ShineSpeed property to generate a continuously increasing value. Fraction node is then used to keep the value between 0 and 1, which creating a looping animation.

The UV coordinates are combined with this animated value using an Add node, which shifts the UVs over time to sample a Shine Texture, causing the highlight pattern on item.

The shader also uses a Mask Texture to control which parts of the sprite receive the shine effect and a Normal Map connected to the Sprite Lit Master Stack to preserve compatibility with the URP 2D lighting system.

### What I improved
Based on feedback from playtesting, I made several improvements to the gameplay experience. First, I added a shining shader effect to interactive items so players can more easily identify objects that can be picked up. Second, I fixed an inventory index issue that sometimes caused the hover indicator to display on the wrong slot, making inventory navigation more reliable. Finally, I added instructions to the inventory panel to help players understand the controls and reduce accidental item selections.

### New Content
Since the last milestone, I created a new scene to expand the game world for players to explore. I also implemented a scene transition system that is triggered when the player moves onto a sign. Once the puzzle in the current area is solved, the player can use the sign to travel to the next level.In addition, I used Unity's particle system to create a snowfall effect, which helps enhance the atmosphere of the scene.

## Final



### Core gameplay loop and the content

My core gameplay loop is a puzzle game where the player needs to understand the requirement of each obstacle, choose the correct item, and use that item to pass the obstacle. The player controls the game fully with the keyboard. They use A and D to move left and right, Space to pick up items or select items, Z to use the selected item, and X to open the inventory. Before using an item, the player needs to open the inventory and choose the item they want to use.

Currently, the game has two levels. In the first level, the player needs to use an axe to break a fence and move forward. In the second level, the player collects flowers and offers them to a statue. These levels demonstrate the main structure of the full game I originally planned. The player explores an area, collects useful items, solves an obstacle-based puzzle, and unlocks progress to the next area. This shows the player what the full game would be like because the Vertical Slice includes the basic gameplay loop, puzzle interaction, item usage, and level progression.

I also added audio feedback for item use to make the gameplay feel more polished. For example, when the axe is used, it plays a sound effect.

### Rendering effect

For the rendering effect, I used Shader Graph to create a glowing effect on the axe. The shader uses a Texture2D, Time, and Fraction node so the glow appears repeatedly at a regular frequency. I also used UV and texture information to make the glowing pattern less flat and give it a more specific shape. This makes the axe visually stand out as an important item that the player can interact with.

I also added a post-processing effect after the player offers the flowers to the statue. This effect makes the scene appear to glow with a more holy or sacred feeling. I created a different URP renderer setup for this post effect and connected it to a second camera. When the flower offering event happens, the gameplay logic switches from the main camera to the post-effect camera. After the effect duration ends, the logic switches back to the main camera. This allows the rendering effect to be activated directly from gameplay progress.

![The Shader Graph](add later)

### Devlog

1. Describe your process for how you break down a large project into specific systems. If you don't have a process that works well for you right now, you must come up with and describe a viable plan.

For project planning, the task step break-down process works better for me than a broad plan alone. When I write the task steps clearly, it helps me organize my thoughts and also gives me more specific instructions to follow during development. My process is to first identify the core gameplay loop, then separate the project into systems such as player movement, item pickup, inventory, item usage, puzzle logic, level transition, visual effects, and audio feedback. After that, I break each system into smaller tasks that I can test one by one.

2. Do you plan on using either the bubble diagram break-downs and/or the task step break-downs we practiced this quarter in your planning process? Why or why not?

I plan to keep using task step break-downs in my planning process. For me, task step break-downs are more useful because they turn a large feature into clear actions. This helps me know what to build first and what to test after each step. I may still use bubble diagrams when I need to understand the relationship between systems, but task step break-downs are more helpful when I actually start implementing the feature.

3. How does the process of breaking down a large project into small steps affect your understanding of the scope of the project?

Breaking down a large project into smaller steps helped me understand the real scope of the project. Some features looked simple at first, but after breaking them down, I realized they required multiple smaller systems to work together. For example, the inventory was not only a UI panel. It also needed player input control, item selection logic, item usage logic, and animation feedback. Because of this, breaking down the project helped me estimate the work more realistically and avoid treating complex systems as simple tasks.

4. How does the plan you're describing relate to your process of creating the Vertical Slice project? You can write about either how things went poorly and how you'd improve your process as a result, or about how things went well that you want to repeat.

This planning process relates directly to my Vertical Slice project because the inventory system was one of the most complex systems I created. I designed the logic and animation behavior from the beginning by myself, so breaking it into smaller tasks helped me finish the feature. For example, I separated the work into opening the inventory, stopping player movement, navigating items, selecting an item, and using the item in the puzzle. I was happy that I completed this system because it became an important part of the core gameplay loop.

For the inventory system, I used a list of objects to control the hover animation for each inventory slot. When the player moves the selection, the system turns the hover animation on for the current slot and turns it off for the previous slot. I also used a dictionary to record the order of the inventory objects, so the system can track which item belongs to each inventory position. The hover index is controlled by variables to make sure the selection stays within the valid range of the inventory.

Each inventory object has a sprite variable, which allows the inventory icon to change based on the item stored in that slot. The system also records the quantity of each tool. Because of this, tools of the same type are stacked together instead of being added as separate inventory entries. This makes the inventory easier to manage and keeps the item display cleaner for the player.

At the same time, I think my original plan for the Vertical Slice was a little too broad at the beginning. Because of that, I spent more time later trying to focus the project and decide what features were most important. If I had more time, I would improve the level design and add more puzzle content. In future projects, I would start with a clearer task step break-down earlier so I can focus on the core gameplay loop sooner and avoid spending too much time refining the direction later.

