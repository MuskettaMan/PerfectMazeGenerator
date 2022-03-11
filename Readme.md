# MazeGenerator
[Maze Generator Demo](https://ferri.dev/Maze-Generator/)
I've made a maze generator, that makes use of 5 different generation algorithms. All the 5 different algorithms work on the same code foundation. It's expandable for more grid-based algorithms.
## Features
- Can change height and width of the grid
- [Depth-first Search algorithm](https://en.wikipedia.org/wiki/Depth-first_search)
- [Prim's algorithm](https://en.wikipedia.org/wiki/Prim%27s_algorithm)
- [Binary Tree algorithm](https://en.wikipedia.org/wiki/Binary_tree)
- [Side winder algorithm](http://weblog.jamisbuck.org/2011/2/3/maze-generation-sidewinder-algorithm)
- [Kruskal's algorithm](https://en.wikipedia.org/wiki/Kruskal%27s_algorithm)
- A move-able player, to move along the maze
- [Lighting setting for polished look](https://docs.unity3d.com/Packages/com.unity.render-pipelines.lightweight@6.7/manual/2d-index.html)
## Software Analysis 
I've used Unity for this game. This could be made with almost every language that has graphical possibilities. The only visual requirements is to draw a grid and color in the walls. So most languages / engines / frameworks could have been used. I have used Unity because of the fact that it's a nice work environment and gives me the possibility to polish the game in a better way than other options would allow me. Unreal Engine would allow me to do the same, but I've more experience with Unity and because of the time limitations on this project I can't afford to learn a comply new working environment.
## Learning Goals
- Understanding maze algorithms
- Create a reusable code base
- Implementing maze algorithms
- Making use of Unity's 2D LWRP
## Reusable code
For the reusable code, I made use of the Strategy Pattern. This pattern makes use of composition to change algorithms at run-time instead of compile-time. The Strategy Pattern also promotes loosely-coupled design. I also used adhered to the open closed principle, that way my code stays maintainable, debug-able and clean.

My plan is to create a utility class that contains all the algorithms (`UtilityMaze.cs`). The signature of all the methods will stay the same so I can use a `delegate`. Then that delegate invokes on the main grid to transform it in to the maze. Every maze contains a cell with 4 cells, that will get in my way later. Because then between every cell are 2 walls, that's illogical and will get in my way later with the Kruskal algorithm. To solve this I will instantiate all the cells with their walls referencing null. Then I can one by one instantiate their walls and reference each other walls to create grid where between every cell only exists one wall.
## Planning 
| | monday | tuesday | wednesday | thursday | friday |
| --- | --- | --- | --- | --- | --- |
|week 1 | Setting up project and github | Researching maze algorithms | Making small project to test out implementing algorithms | Start design codebase | Start out with the depth-first search |
|week 2 | Move onto Prim's algorithm and binary tree and sidewinder | Implementing kruskal's algorithm | Polish game by adding character to walk around and implementing 2d LWRP | Upload to portfolio | Upload to portfolio | 
## Sources
- [Wikipedia Maze Generation Algorithms](https://en.wikipedia.org/wiki/Maze_generation_algorithm)
- [Unity Docs 2D LWRP](https://docs.unity3d.com/Packages/com.unity.render-pipelines.lightweight@6.7/manual/2d-index.htm)
- [Hurna](https://hurna.io/academy/algorithms/maze_generator/index.html)
<!--stackedit_data:
eyJoaXN0b3J5IjpbMTE0ODQzNTM4MSwxMjI3MzcyNDYyLC0xNT
I3MzQzNTY0LC05NDYzMDU0NzUsMTAwODk0NTUwM119
-->
