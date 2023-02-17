using RPGHeroes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RPGHeroes.Enums.WeaponsEnum;

namespace RPGHeroes.Items
{
    public class Weapon : Item
    {
        public WeaponTypes WeaponType { get; set; }
        public int Damage { get; set; }
        public Weapon(string name, int requiredLevel, int damage, WeaponTypes weaponType) : base(name)
        {
            RequiredLevel = requiredLevel;
            Slot = SlotsEnum.Slots.Weapon;
            Damage = damage;
            WeaponType = weaponType;
        }
    }
}
