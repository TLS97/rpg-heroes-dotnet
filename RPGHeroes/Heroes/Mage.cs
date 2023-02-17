using RPGHeroes.Enums;
using RPGHeroes.Exceptions;
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
    public class Mage : Hero
    {
        public Mage(string name) : base(name) 
        {
            LevelAttributes = new(1, 8, 1);
            ValidWeaponTypes = new() { WeaponTypes.Staff, WeaponTypes.Wand };
            ValidArmorTypes = new() { ArmorTypes.Cloth };
        }

        public void Equip(Weapon weapon)
        {
            if (ValidWeaponTypes.Contains(weapon.WeaponType))
                if (Level >= weapon.RequiredLevel)
                    Equipment[Slots.Weapon] = weapon;
                else 
                    throw new InsufficientLevelException($"The Mage needs to get to Level {weapon.RequiredLevel} to equip a {weapon.WeaponType}.");
            else
                throw new InvalidWeaponException($"{weapon.WeaponType} cannot be equipped by a Mage!");
        }

        public void Equip(Armor armor, Slots slot)
        {
            if (ValidArmorTypes.Contains(armor.ArmorType))
                if (Level >= armor.RequiredLevel)
                    Equipment[slot] = armor;
                else
                    throw new InsufficientLevelException($"The Mage needs to get to Level {armor.RequiredLevel} to equip a {armor.ArmorType}.");
            else
                throw new InvalidArmorException($"{armor.ArmorType} cannot be equipped by a Mage!");
        }

        public override void LevelUp()
        {
            base.LevelUp();

            LevelAttributes.IncreaseAttributes(1, 5, 1);
        }
    }
}
