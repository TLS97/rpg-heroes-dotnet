using RPGHeroes.Enums;
using RPGHeroes.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RPGHeroes.Enums.ArmorsEnum;
using static RPGHeroes.Enums.SlotsEnum;

namespace RPGHeroes.Items
{
    public class Armor : Item
    {
        public ArmorTypes ArmorType { get; set; }
        public HeroAttributes ArmorAttributes { get; set; }
        public Armor(string name, int requiredLevel, Slots slot, ArmorTypes armorType) : base(name)
        {
            RequiredLevel = requiredLevel;
            Slot = slot;
            ArmorType = armorType;
            ArmorAttributes = new(0, 0, 0);
        }
    }
}
