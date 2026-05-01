# GDIM 33 Game

### MileStone1

1. 
I use OnTriggerEnter2D and OnTriggerExit2D to detect whether player is close emough to pick up tool. If it's close enough, canPickTool set as True, allows player picks up tool.
![Graph](https://github.com/user-attachments/assets/acaddfeb-c1b4-4efa-b601-07b4ae15b0d9)


2.

In this milestone, I updated my game break-down by integrating a State Machine system to manage player behavior more clearly and modularly. Previously, movement and interaction logic were loosely connected, but now they are organized into defined states such as Idle, Moving, and Interaction. The movement state is activate by the Unity Input System using a Vector2 input from input events, allowing movement control. For interaction, I added trigger detection using OnTriggerEnter2D and OnTriggerExit2D, combined with boolean checks to determine whether the player is within range of an interactable object and able to pick up or use a tool. This update improves readability and scalability compared to handling everything in a single flow.

The State Machine works by transitioning between states based on player input, collision events, and internal conditions. For example, when the player provides movement input, the state switches from Idle to Moving, and when entering an interactable zone, the system enables the Interaction state if conditions are met. This State Machine is connected to Input System for movement control, the Physics system for trigger detection, and the interaction/puzzle system for enabling tool usage and puzzle activation.
![Break down 3](https://github.com/user-attachments/assets/c53b90cb-904e-4688-9645-9648497151cb)
