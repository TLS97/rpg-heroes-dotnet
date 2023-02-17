﻿using RPGHeroes.Items;
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

        public virtual void LevelUp()
        {
            Level += 1;
        }
    }
}
