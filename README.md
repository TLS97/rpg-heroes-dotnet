# Noroff Assignment 4: RPG Heroes

This project is a RPG Heroes Console Application developed in C# using Test-Driven Development.

## Description
The application consists of various Heroes with different attributes and equipments. The different types of heroes has different levels of strength, dexterity, and intelligence. They are also able to use different weapon and armor types, depending on the hero type and its current level. Weapon and Armor types requires the hero to reach a certain level before it can be used. The different heroes also does different degrees of damage, depending on the hero type and which armor and weapon types they use.

## Usage
Example code:
```
// Create a hero
string heroName = "Hero";
Mage mage = new(heroName);

// Level up the hero
mage.LevelUp();

// Create a weapon
string weaponName = "Staff";
int requiredLevel = 1;
int damage = 1;
WeaponTypes weaponType = WeaponTypes.Staff;
Weapon staff = new(weaponName, requiredLevel, damage, weaponType);

// Equip the hero with a weapon
mage.Equip(staff);
```
## Contributors
[Tine Storvoll](https://gitlab.com/TLS97)