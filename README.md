# The Evercraft Smells Kata   

In this kata you will be finding and fixing code smells in a game called Evercraft. 

## Setup

This kata is in C#. You will need to install the .NET Core SDK

- [.NET Core SDK](https://dotnet.microsoft.com/download/dotnet-core/2.2)

## Running Tests

You can use the command line or an IDE to run tests.

### Command line

```bash
dotnet test
```

## Requirements


#### Character display

> As a player, I want to view my character's data so that I see how I stack up against my opponent

- can display each character's name, hit points, armor, etc.

#### Character Can Attack

> As a combatant, I want to be able to attack other combatants and damage my enemies so that they will die and I will live

- roll a 20 sided die. Call the d20 service which returns a random number from 1 to 20.
- has an Armor rating that defaults to 10
- roll must meet or beat opponents armor class to hit
- if attack is successful, other character takes 1 point of damage when hit
- if a roll is a natural 20 then a critical hit is dealt and the damage is doubled
- has 5 Hit Points by default
- when hit points are 0 or fewer, the character is dead

### Armor Types
> As a combatant, I want to wear different types of armor to influence my rating.

| Material | Base Rating | Modifier | Net Effect |
| --- | --- | --- | --- |
| Bronze | 10 | -1 | 9 |
| Iron | 10 | 0 | 10 |
| Steel | 10 | +1 | 11 |

- Armor also has a weight. Heavy armor (greater than 50 pounds) grants an additional +2 modifier to the armor rating. 

#### Character Has Abilities Scores

> As a character, I want to have several abilities so that I am not identical to other characters except in name

- Abilities are Strength, Dexterity, Constitution
- Abilities range from 1 to 20 and default to 10
- Abilities have modifiers according to the following table

|   Score   | Modifier |   Score   | Modifier |   Score   | Modifier |   Score   | Modifier |
|:---------:|:--------:|:---------:|:--------:|:---------:|:--------:|:---------:|:--------:|
|   __1__   |    -5    |   __6__   |    -2    |  __11__   |     0    |  __16__   |    +3    |
|   __2__   |    -4    |   __7__   |    -2    |  __12__   |    +1    |  __17__   |    +3    |
|   __3__   |    -4    |   __8__   |    -1    |  __13__   |    +1    |  __18__   |    +4    |
|   __4__   |    -3    |   __9__   |    -1    |  __14__   |    +2    |  __19__   |    +4    |
|   __5__   |    -3    |  __10__   |     0    |  __15__   |    +2    |  __20__   |    +5    |

#### Character Ability Modifiers Modify Attributes

> As a character, I want to apply my ability modifiers improve my capabilities in combat so that I can vanquish my enemy with extreme prejudice

- add Strength modifier to:
    - attack roll and damage dealt
    -  minimum damage is always 1 (even on a critical hit)
- add Dexterity modifier to armor rating
- add Constitution modifier to hit points (hit points cannot start below 1)

#### Character data loading

> As a player, I want to specify the character data of my two combatants

Character data will be stored in a CSV file with the format:

`Character,Armor,Strength,Dexterity,Constitution`

The first line of the file should use the text above as a header record. An example data record is:

`Steve,10,10,10,10`

#### Opponent attacks

> As a player, I want my opponent to attack me to make for an interesting game

