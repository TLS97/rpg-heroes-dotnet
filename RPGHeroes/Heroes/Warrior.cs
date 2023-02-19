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
    public class Warrior : Hero
    {
        public Warrior(string name) : base(name)
        {
            LevelAttributes = new(5, 1, 2);
            ValidWeaponTypes = new() { WeaponTypes.Axe, WeaponTypes.Hammer, WeaponTypes.Sword };
            ValidArmorTypes = new() { ArmorTypes.Mail, ArmorTypes.Plate };
        }

        public override double CalculateDamage()
        {
            double weaponDamage = base.CalculateDamage();

            HeroAttributes totalAttributes = CalculateTotalAttributes();
            int damagingAttribute = totalAttributes.Strength;

            return weaponDamage * (1 + damagingAttribute / 100);
        }

        public void Equip(Weapon weapon)
        {
            if (ValidWeaponTypes.Contains(weapon.WeaponType))
                if (Level >= weapon.RequiredLevel)
                    Equipment[Slots.Weapon] = weapon;
                else
                    throw new InsufficientLevelException($"The Warrior needs to get to Level {weapon.RequiredLevel} to equip a {weapon.WeaponType}.");
            else
                throw new InvalidWeaponException($"{weapon.WeaponType} cannot be equipped by a Warrior!");
        }

        public void Equip(Armor armor, Slots slot)
        {
            if (ValidArmorTypes.Contains(armor.ArmorType))
                if (Level >= armor.RequiredLevel)
                    Equipment[slot] = armor;
                else
                    throw new InsufficientLevelException($"The Warrior need to get to Level {armor.RequiredLevel} to equip a {armor.ArmorType}");
            else
                throw new InvalidArmorException($"{armor.ArmorType} cannot be equipped by a Warrior!");
        }

        public override void LevelUp()
        {
            base.LevelUp();
            LevelAttributes.IncreaseAttributes(3, 1, 2);
        }
    }
}
