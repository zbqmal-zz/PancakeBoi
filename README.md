# PancakeBoi

## Overview
* A 3D platformer inspired by Overcooked and Mario Odyssey’s Luncheon Kingdom
* Play as Pancake Boi, a boy who has mastered the art of making pancakes and wants to become the master of all breakfast foods
* Goal: find and collect all ingredients needed to make a breakfast dish
* Food related enemies and food related obstacles will try to stop the player

## Game Mechanics
* Four main levels
* Terrain obstacles
* HUD and badges
* Player
* Enemy

## Play Video

## Basic Controls: 
1. "w", "a", "s", "d" : Moving
2. "Space bar" : Jumping
3. Camera moves with mouse

## Gameplay Overview: 
The goal of Pancake Boi is to have the main character learn and cook new breakfast dishes. There are four levels. The first scene when opening the game is the Menu Scene. The Menu scene has 4 doors corresponding to the four levels that will open when you approach. If you want to play a level, approach the door and go through it when it opens. Level 1 is the easiest level and the difficulty increases as you continue. You can play any level in any order; no level is locked.

## Gameplay Instructions:
In the menu scene, select which level you want to play by going through the appropriate door. In the level, collect all the ingredients listed in the HUD in the top right. When finished collecting ingredients, a cooking pan should appear in the sky. At this point, head to the base of the stairs that lead up to the pan. This triggers the end of the level and brings you back to the main menu. The trigger point to end the level is below the stairs, not the stairs or above it. If there are two sets of stairs, you can choose either to go to. If there are no stairs (level 4), just go to the area below the pan and it will trigger the end of the level. Beware of enemies or falling off the platform, as you will lose a life shown in the top left corner. Losing all lives brings you back to the main menu.

## Level Descriptions/Components:
HUD: The HUD displays the number of hearts you have and an ingredient list describing what you need to collect. The ingredient name darkens when you collect that ingredient. The HUD is in all levels
Ingredients: All ingredients have two animations, one that spins and bobs up and down slowly and the other being that when the player is near, it lowers and spins very fast. It has sound when collected. 
Pan: Appears only when all ingredients in the level have been collected. Has an animation that lowers it to a spot and a point near the pan is activated when all ingredients have been collected. When landed on, it triggers the end of the level, bringing you back to the main menu.
Enemies: All enemies roam between invisible waypoints until the player is near. When the player is near it will follow the player and try to attack.
Door: Available in all levels for the player to go through and return to the main menu.

Level 1: The goal of level 1 is to create scrambled eggs and has 5 ingredients. This level shows off the following components in addition to the ones above:
- Jello object: Makes you jump higher when landing on it
- Button and Wall: Pressing the button lowers a wall
 - Cracker Platform: Wobbles when landed on and falls after a certain amount of time
 
Level 2: The goal of level 2 is to create french toast and has 7 ingredients. This level shows off the following components in addition to the ones above:
- More complex platform design than level 1
- Cracker platforms
- Floating spiral staircase

Level 3: The goal of level 3 is to create blueberry muffins and has 9 ingredients. This level shows off the following components in addition to the ones above:
- More complex platform design than level 2
- Jello object
- Cracker platforms
- Walls obscuring vision

Level 4: The goal of level 4 is to create a breakfast burrito and has 11 ingredients. This level shows off the following components in addition to the ones above:
- Most complex platform design in the game
- Moving blocks: Move based on animations. You can ride them, but this alpha hasn’t completed how to transit the blocks and player together. In other words, it might be very difficult to go to the next platform through the moving blocks
- Maze: One ingredient is hidden in the maze. Due to camera functionality, hard to see through the maze at the moment
