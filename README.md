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

(I couldn't finish the rest of the devlog because I had an issue of login Canva since Thursday, and I also couldn't send / receive email from UCI email address now)

