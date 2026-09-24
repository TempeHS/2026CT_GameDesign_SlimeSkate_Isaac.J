# Unity Game Development Summary 

| General Details |  |
|---|---|
| **Slime skate** | |
| **Isaac J** | |
| **10CT / Course** | |
| **2026CT_GameDesign_SlimeSkate_Isaac.J** | |
| **Unity 6** | |

---

## Table of Contents
1. [Game Overview](#1-game-overview)
2. [Video Walkthrough](#2-video-walkthrough)
3. [Game Mechanics](#3-game-mechanics)
4. [Visual Features](#4-visual-features)
5. [Audio Design](#5-audio-design)
6. [User Interface & HUD](#6-user-interface--hud)
7. [Scene & Level Design](#7-scene--level-design)
8. [Scripts & Programming](#8-scripts--programming)
9. [Development Techniques & Tutorials Acknowledged](#9-development-techniques--tutorials-acknowledged)
10. [Third-Party Content Acknowledgements](#10-third-party-content-acknowledgements)
11. [Challenges & Solutions](#11-challenges--solutions)

---

## 1. Game Overview

Slime Skate is a 2D skateboarding platformer game with influences from genres like animemo and Shibuya punk. It has influences from things like Japanese nightlife and general urban culture, with inspirations from games like Tony Hawk's Pro Skater and Bomb Rush Cyberfunk.

### 1.1 Genre

Platformer/ Skate Platformer.

### 1.2 Target Audience

Slime Skates' target audience is quite flexible, but is generally aimed at the 13 to 17 age bracket. While there isn't anything stopping it from being enjoyed by other groups of people, the general themes and aesthetics align with that age bracket, with development aiming for the tone of the game to fit the desired playstyle usually enjoyed by that set of ages.

### 1.3 Game Summary

In Slime Skate, the main objective is to perform skateboarding-based parkour and skate tricks while navigating the environment, aiming to achieve a higher score while doing so.

Please note that some of this couldn't be implemented in this current build.

### 1.4 Win / Loss Conditions
| Condition | Description |
|---|---|
| Win | N/A, Win screens and objectives could not be inplemented in time to meet the deadline.|
| Loss | Falling off the map.|

### 1.5 Platform & Build Settings
| Setting | Detail |
|---|---|
| Target Platform | Mac|
| Resolution | 1980px by 1080px|

---

## 2. Video Walkthrough

<video controls src="0925(1).mov" title="Title"></video>

Please note that quality and audio had to be slightly diminished to fit the upload limit of GitHub Desktop.

## 3. Game Mechanics

### 3.1 Core Mechanics
| ID | Mechanic | Description | Implemented In (Script/Object) |
|---|---|---|---|
| M-1 | Jump| A simple jump animation in the form of a kickflip.| SkateboardController.cs|
| M-2 | Tilt| While airborn, the arrow keys control to tilt of the skateboard, helping with issues of airborn spinning.| SkateboardController.cs|
| M-3 | Tilt Reset| While grounded, shift will perform a small hop and reset the board's horisontal angle.| SkateboardController.cs|
| M-4 | Wall Climb| While jumping on a wall while also being sideways, you will travel up said wall.| SkateboardController.cs|
| M-5 | Double Jump Lock| Prevents you from double jumping.| SkateboardController.cs|

### 3.2 Player Controls
| Action | Input (Keyboard / Controller) | Description |
|---|---|---|
|Movement |W, A, D, S |Simple movement. |
|Jump |Space |A simple jump animation in the form of a kickflip. |
|Tilt |Left arrow key, Right Arrow key |While midair, the board tilts left and right to give more control to the player. |
|Tilt Reset |Shift |If the board is upside down, pressing Shift will reset the board's angle while also giving a small height boost. |

### 3.3 Physics & Collision

There aren't any standard changes to the physics and collision in this game, as the physics and collision have been tailored purposely to suit the experience of riding a skateboard.

### 3.4 Game Loop

There isn't a traditional game loop in this current build of my game. Given the time I was given to create it, right now it mainly acts as a sandbox world to then be created into a proper skateboarding game.

### 3.5 Scoring & Progression

There was a planned scoring system which would hinge on a multiplication system that would multiply depending on the difficulty of the trick performed and the level of the ongoing score, but due to time restrictions, I wasn't able to implement that into the current build.

---

## 4. Visual Features

### 4.1 Particle Effects

N/A


### 4.2 Cut Scenes & Cinematics

N/A, In multimedia, a cutscene was not provided to me. Because of this, I could not implement one into my game. 

### 4.3 Animations

| Animation | Object / Character | Description |
|Skateboard Movement | Skateboard| A simple animation of light moving across the wheels of a skateboard, implying movement.|
|Skateboard Jump |Skateboard |A simple kickflip animation while airborne to signify a jump. |

---

### 4.4 Lighting & Post-Processing

N/A

### 4.5 Shaders & Materials

N/A

This could not be inplemented in time to meet the deadline.

### 4.6 Additional Visual Screenshots

## 5. Audio Design

N/A 

Sound effects and music could not be inplemented in time to meet the deadline.

## 6. User Interface & HUD

N/A 

User Interface & HUD could not be inplemented in time to meet the deadline.

## 7. Scene & Level Design

### 7.1 Scene List

 N/A

Scenes could not be inplemented in time to meet the deadline.

### 7.2 Level / Environment Screenshots
| Level / Area | Description | Screenshot |
|---|---|---|
|1 |Neo Shibuya (night) |Neo Shibuya is a shopping district linked to an urban street where the game is set, with skyscrapers littered with advertisements in the background, and vandalised ramps and pathways setting the scene in the foreground. |


### 7.3 Scene Management

 N/A

Scene Management could not be inplemented in time to meet the deadline.

## 8. Scripts & Programming

### 8.1 Script Summary
| Script Name | Attached To | Responsibility |
|---|---|---|
|SkateboardController.cs |Skateboard |SkateboardController.cs handles everything to do with the physics of the skateboard and its interactions within the game. It handles by itself: Aerial ground check, Script management, Everything to do with velocity and speed, General tweaking of the physics while airborne and on the ground, Controls, tilting, tilt reset, and management of animations |
|CameraController.cs |Maincamera |Smoothly controls the camera by following an attached object, with built-in offset and smoothness rework. |


## 9. Development Techniques & Tutorials Acknowledged

> List every tutorial, course, video, or article that informed or guided your implementation. Include what you used it for and what you changed or adapted.

| # | Title | Author / Creator | URL / Source | What You Used It For | What You Changed / Adapted |
|---|---|---|---|---|---|
| 1 |How To Add Parallax Effect Background In Unity 6 |Unity Unlocked |https://www.youtube.com/watch?v=uFDed21LSwg |I used this video to aid with deepening the background and giving more depth to the general environment of my game. |I adapted this to work in a 2D environment. |
| 2 |Walk, Idle, and Turn Around: Action RPG in Unity Tutorial #2 | Night Run Studio |https://www.youtube.com/watch?v=swCFvAxYKBE |This was used to finally fix my ongoing issues with my animations, aiding greatly in making my game look more polished.  |Nothing needed to be adapted, as the tutorial was made in a 2D environment in Unity 6. |

---

## 10. Third-Party Content Acknowledgements

> All third-party assets (art, audio, fonts, scripts, packages) must be listed here with their licence. Using an asset without acknowledgement may constitute academic misconduct.

All content was created and produced by myself.

---

## 11. Challenges & Solutions

| # | Challenge Encountered | How It Was Solved |
|---|---|---|
| 1 |Continuous difficulty with implementing the correct animations. |While this challenge wasn't completely solved, parts of it were in ways that I'm quite happy with. I used a float system combined with my ground check and input check systems in SkateboardController.cs to implement a smooth walking animation. While the jumping animation couldn't be implemented in time, this had served as a major roadblock, and even with it in this condition, I believe that I achieved partially what I set out to do. |
| 2 |Ground check and input check |With movement being vital in a game such as this, my ground check and input checks were an intuitive way to fix my problems with motion. These two check systems helped with: Registering if the board was airborne, Stopping the infinite jumping problem, where mashing the spacebar or shift would give you infinite leverage, Monitoring things like velocity and Enhancing the accuracy and level of comfort of the controls. |

---


> **Student Declaration:** All work submitted is my own except where explicitly acknowledged above.