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

        /// <summary>
        /// Equips a Warrior with a weapon if the weapon type is valid and the warrior has reached the required level of the weapon.
        /// </summary>
        /// <param name="weapon"></param>
        /// <exception cref="InsufficientLevelException">When the Required Level of the Weapon is greater than the Level of the Warrior</exception>
        /// <exception cref="InvalidWeaponException">When the type of the Weapon being equipped is not valid for the Warrior</exception>
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

        /// <summary>
        /// Equips a Warrior with a piece of armor if the armor type is valid and the Warrior has reached the required level of the armor.
        /// </summary>
        /// <param name="armor"></param>
        /// <param name="slot"></param>
        /// <exception cref="InsufficientLevelException">When the Required Level of the Armor is greater than the Level of the Warrior</exception>
        /// <exception cref="InvalidArmorException">When the type of the Armor being equipped is not valid for the Warrior</exception>
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

        /// <summary>
        /// Calls the base class' LevelUp() method to increase the Level of the hero and increases the LevelAttributes.
        /// </summary>
        public override void LevelUp()
        {
            base.LevelUp();
            LevelAttributes.IncreaseAttributes(3, 1, 2);
        }

        /// <summary>
        /// Calls the base class' CalculateDamage() method to get the WeaponDamage of the equipped weapon. 
        /// Gets the Total Intelligence from the TotalAttributes of the hero and calculates the Hero Damage.
        /// </summary>
        /// <returns>Hero damage</returns>
        public override double CalculateDamage()
        {
            double weaponDamage = base.CalculateDamage();

            HeroAttributes totalAttributes = CalculateTotalAttributes();
            int damagingAttribute = totalAttributes.Strength;

            return weaponDamage * (1 + damagingAttribute / 100);
        }
    }
}
