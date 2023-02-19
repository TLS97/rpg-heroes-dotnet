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

        /// <summary>
        /// Equips a Rogue with a weapon if the weapon type is valid and the rogue has reached the required level of the weapon.
        /// </summary>
        /// <param name="weapon"></param>
        /// <exception cref="InsufficientLevelException">When the Required Level of the Weapon is greater than the Level of the Rogue</exception>
        /// <exception cref="InvalidWeaponException">When the type of the Weapon being equipped is not valid for the Rogue</exception>
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

        /// <summary>
        /// Equips the rogue with a piece of armor if the armor type is valid and the rogue has reached the required level of the armor.
        /// </summary>
        /// <param name="armor"></param>
        /// <param name="slot"></param>
        /// <exception cref="InsufficientLevelException">When the Required Level of the Armor is greater than the Level of the Rogue</exception>
        /// <exception cref="InvalidArmorException">When the type of the Armor being equipped is not valid for the Rogue</exception>
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

        /// <summary>
        /// Calls the base class' LevelUp() method to increase the Level of the hero and increases the LevelAttributes.
        /// </summary>
        public override void LevelUp()
        {
            base.LevelUp();
            LevelAttributes.IncreaseAttributes(1, 1, 4);
        }

        /// <summary>
        /// Calls the base class' CalculateDamage() method to get the WeaponDamage of the equipped weapon.
        /// Gets the Total Intelligence from the TotalAttributes of the hero and calculates the Hero Damage.
        /// </summary>
        /// <returns>Hero Damage</returns>
        public override double CalculateDamage()
        {
            double weaponDamage = base.CalculateDamage();

            HeroAttributes totalAttributes = CalculateTotalAttributes();
            int damagingAttribute = totalAttributes.Dexterity;

            return weaponDamage * (1 + damagingAttribute / 100);
        }
    }
}
