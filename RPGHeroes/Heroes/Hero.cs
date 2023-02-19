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
    public abstract class Hero
    {
        public string Name { get; }
        public int Level { get; set; } = 1;
        public HeroAttributes LevelAttributes { get; set; }
        public List<WeaponTypes> ValidWeaponTypes { get; set; }
        public List<ArmorTypes> ValidArmorTypes { get; set; }
        public Dictionary<Slots, Item> Equipment { get; set; }

        protected Hero(string name)
        {
            Name = name;
            Equipment = new()
            {
                { Slots.Weapon, null },
                { Slots.Head, null },
                { Slots.Body, null },
                { Slots.Legs, null },

            };
        }

        /// <summary>
        /// Calculates the WeaponDamage of the hero.
        /// </summary>
        /// <returns>The WeaponDamage of the hero.</returns>
        public virtual double CalculateDamage()
        {
            double weaponDamage = 1;

            if(Equipment[Slots.Weapon] != null)
            {
                Weapon weapon = (Weapon)Equipment[Slots.Weapon];
                weaponDamage = weapon.Damage;
            }

            return weaponDamage;
        }

        /// <summary>
        /// Increases the Level of the hero.
        /// </summary>
        public virtual void LevelUp()
        {
            Level += 1;
        }

        /// <summary>
        /// Calculates the TotalAttributes of the hero with any equipped armors.
        /// </summary>
        /// <returns>TotalAttributes</returns>
        public HeroAttributes CalculateTotalAttributes()
        {
            HeroAttributes totalAttributes = LevelAttributes;

            foreach (var equipment in Equipment)
            {
                if (equipment.Value != null && equipment.Key != Slots.Weapon)
                {
                    Armor armor = (Armor)equipment.Value;
                    totalAttributes += armor.ArmorAttributes;
                }
            }
            return totalAttributes;
        }

        /// <summary>
        /// Displays the hero's state, including name, class, level, total strenght, intelligence and dexterity, and damage.
        /// </summary>
        /// <returns>A string with the current state of the hero.</returns>
        public string Display()
        {
            StringBuilder state = new StringBuilder();
            state.AppendLine($"{this.Name}'s Current State:");
            state.AppendLine("Class: " + this.GetType().ToString());
            state.AppendLine("Level: " + Level.ToString());
            state.AppendLine("Total Strength: " + CalculateTotalAttributes().Strength.ToString());
            state.AppendLine("Total Intelligence: " + CalculateTotalAttributes().Intelligence.ToString());
            state.AppendLine("Total Dexterity: " + CalculateTotalAttributes().Dexterity.ToString());
            state.AppendLine("Damage: " + CalculateDamage().ToString());

            Console.WriteLine(state.ToString());

            return state.ToString();
        }
    }
}
