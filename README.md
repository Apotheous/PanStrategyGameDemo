https://github.com/Apotheous/PanStrategyGameDemo/assets/73647085/d633de95-5217-4892-bcc7-40b390bd924b

Unity Strategy Game Project
Overview
This Unity project is a strategy game demo developed using Unity 2021 LTS. The game involves selecting units, moving them, and attacking enemy buildings.
The project showcases various Unity features and design patterns, including object pooling, pathfinding, raycasting, event handling, and more.

Features

1. Unit Selection and Deselection
UnitSelections Class: Manages the selection and deselection of units. It includes methods for single-click selection, shift-click selection for multi-selection, and drag selection.
ClickSelect: Selects a single unit and deselects all others.
ShiftClickSelect: Adds or removes a unit from the selection without affecting others.
DragSelect: Adds units to the selection during a drag operation.
DeselectAll: Deselects all currently selected units.

3. Movement and Pathfinding
AStar Class: Implements the A* algorithm to find the shortest path from the unit’s position to the target position on the tilemap.
DemoPathFinding Class: Handles the movement of units. It uses the AStar class to find the path and the DOTween library to animate the units along the path.
MoveForGlory: Moves units to a clicked position on the map.
MoveForAttack: Moves units to attack an enemy building, stopping at a predefined range.

4. Object Pooling
NewObjectPool Class: Manages a pool of bullet objects to optimize performance by reusing objects instead of creating and destroying them frequently.
Shoot: Activates a bullet and shoots it towards the target.
GetThePool: Deactivates and returns the bullet to the pool after a set time.

5. Health and Damage System
Health Class: Manages the health of units and buildings, triggering events on hit or death.
GetHit: Reduces health when hit and triggers appropriate events.
OnDeath and OnHit Events: Custom Unity events that can be used to trigger animations, sounds, or other effects.

6. Raycasting for Interactions
DemoPathFinding Class: Uses raycasting to detect right-click interactions with enemy buildings.
Update Method: Detects right-clicks and performs a raycast to determine if an enemy building is clicked.

7. Event Handling
UnityEvent: Used extensively for handling various game events, such as unit hits and deaths. This allows for decoupled and flexible event management.

8. Animation and Tweening
DOTween Library: Used for animating unit movements smoothly along the calculated paths.

How to Use
Select Units: Click on a unit to select it. Use shift-click to select multiple units.
Move Units: Right-click on the ground to move selected units to the target location.
Attack Buildings: Right-click on an enemy building to move selected units to attack it.
Object Pooling: Bullets are managed through an object pool to optimize performance.
Code Snippets
Unit Selection
![image](https://github.com/Apotheous/PanStrategyGameDemo/assets/73647085/b6ede06e-a80e-4a14-b65b-ca54b0971d84)

Movement and Pathfinding
![image](https://github.com/Apotheous/PanStrategyGameDemo/assets/73647085/100a4176-0891-455f-9fbc-47d713c3c377)

Object Pooling
![image](https://github.com/Apotheous/PanStrategyGameDemo/assets/73647085/5de0ea02-4478-458c-8c98-c36518302669)

Health and Damage
![image](https://github.com/Apotheous/PanStrategyGameDemo/assets/73647085/afabc8d3-2a07-4fbe-9a5f-581d8b3c9827)

![image](https://github.com/Apotheous/PanStrategyGameDemo/assets/73647085/7e4ea101-d259-40d4-9f58-6514bcf4763e)

Conclusion
This project demonstrates various Unity features and best practices, including effective use of object pooling, pathfinding with AStar, event-driven architecture, and UI feedback systems.
It is a robust foundation for a strategy game and can be expanded with additional features and enhancements.
