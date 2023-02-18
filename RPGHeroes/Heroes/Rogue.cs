﻿using RPGHeroes.Exceptions;
using RPGHeroes.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RPGHeroes.Enums.ArmorsEnum;
using static RPGHeroes.Enums.SlotsEnum;
using static RPGHeroes.Enums.WeaponsEnum;

namespace RPGHeroes.Heroes
{
    public class Rogue : Hero
    {
        public Rogue(string name) : base(name)
        {
            LevelAttributes = new(2, 1, 6);
            ValidWeaponTypes = new() { WeaponTypes.Dagger, WeaponTypes.Sword };
            ValidArmorTypes = new() { ArmorTypes.Leather, ArmorTypes.Mail };
        }

        public override int CalculateDamage()
        {
            throw new NotImplementedException();
        }

        public void Equip(Weapon weapon)
        {
            if (ValidWeaponTypes.Contains(weapon.WeaponType))
                if (Level >= weapon.RequiredLevel)
                    Equipment[Slots.Weapon] = weapon;
                else
                    throw new InsufficientLevelException($"The Rogue needs to get to Level {weapon.RequiredLevel} to equip a {weapon.WeaponType}.");
            else
                throw new InvalidWeaponException($"{weapon.WeaponType} cannot be equipped by a Rogue!");
            
        }

        public void Equip(Armor armor, Slots slot)
        {
            if (ValidArmorTypes.Contains(armor.ArmorType))
                if (Level >= armor.RequiredLevel)
                    Equipment[slot] = armor;
                else
                    throw new InsufficientLevelException($"The Rogue needs to get to Level {armor.RequiredLevel} to equip a {armor.ArmorType}.");
            else
                throw new InvalidArmorException($"{armor.ArmorType} cannot be equipped by a Rogue!");
        }

        public override void LevelUp()
        {
            base.LevelUp();
            LevelAttributes.IncreaseAttributes(1, 1, 4);
        }
    }
}
