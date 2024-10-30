# RPGTextGame

RPGTextGame is a console-based RPG game featuring a text-based adventure where players can explore, interact with characters, engage in battles, and manage inventory within a rich and immersive story-driven world.

## Table of Contents

- [Features](#features)
- [Project Structure](#project-structure)
- [Installation](#installation)
- [How to Play](#how-to-play)
- [Contributing](#contributing)
- [License](#license)

---

## Features

- **Character Creation**: Customize your character at the start of the game.
- **Exploration**: Navigate through various in-game areas like **Town**, **Forest**, and **Village Outskirts**.
- **Battle System**: Engage in turn-based battles with enemies.
- **Inventory Management**: Collect, store, and use items.
- **In-Game Economy**: Use currency to buy items or rest at the inn.

## Project Structure

```plaintext
RPGTextGame/
│
├── RPGTextGame.sln               # Solution file
├── RPGTextGame.csproj            # Project configuration
│
├── Program.cs                    # Main entry point of the application
│
├── Models/                       # Data models for game components
│   ├── Character.cs              # Player and NPC characters
│   ├── Item.cs                   # Game items
│   ├── Enemy.cs                  # Enemy characters
│   └── Currency.cs               # Game currency
│
├── src/                          # User interface components
│   ├── MainMenu/                 # Main menu components
│   │   ├── MainMenu.cs           # Main menu page
│   │   ├── GameSetting.cs        # Game settings page
│   │   └── CharacterCreation.cs  # Character creation page
│   │
│   ├── GameMenu/                 # Gameplay menus and pages
│       ├── GameMenu.cs           # Game menu page
│       ├── Map/                  # Map exploration
│           ├── Outskirt/
│           │   ├── FightPage.cs         # Fight page
│           │   ├── FindMonster.cs       # Encounter monsters
│           │   ├── VillageOutskirts.cs  # Village outskirts
│           ├── Forest.cs                # Forest exploration
│           ├── MapExploration.cs        # Map exploration
│           └── Market.cs                # Market interaction
│       ├── Town/
│           ├── TownPage.cs              # Main town area
│           ├── TownSquare.cs            # Town square
│       ├── Inventory/
│           └── Inventory.cs             # Inventory management
│       └── Inn/
│           ├── Meal.cs                  # Meal options at inn
│           ├── RestAtInn.cs             # Rest at inn
│           └── RoomCheckIn.cs           # Check into inn
│
├── Utilities/                   # Utility functions and algorithms
│   ├── Attack/
│       ├── EnemyNormalAttack.cs         # Enemy Attack calculation
│       ├── PlayerNormalAttack.cs        # Player Basic Attack calculation
│       ├── PlayerPowerAttack.cs         # Player Attack With Mana calculation
│   ├── DamageAlgo.cs            # Damage calculation
│   ├── Death.cs                 # Death handling
│   ├── Defeat.cs                # Defeat handling
│   ├── LimitedList.cs           # Limited lists utility
│   ├── MonsterList.cs           # Monster lists
│   ├── NavigationPage.cs        # Page navigation
│   └── RandomNumber.cs          # Random number generator
│
├── Data/                        # Game data files
│   ├── Inn/
│       └── OrderMeal.json       # JSON data for inn meals
│   ├── Enemy/
│       └── villageOutskirt.json # JSON data for enemies
│
└── README.md                    # Project overview and instructions
```
