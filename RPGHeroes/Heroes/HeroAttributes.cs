using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Heroes
{
    public class HeroAttributes
    {
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Dexterity { get; set; }
        public HeroAttributes(int strength, int intelligence, int dexterity)
        {
            Strength = strength;
            Intelligence = intelligence;
            Dexterity = dexterity;
        }

        public HeroAttributes()
        {
        }

        public void IncreaseAttributes(int strength, int intelligence, int dexterity)
        {
            Strength += strength;
            Intelligence += intelligence;
            Dexterity += dexterity;
        }

        public static HeroAttributes operator +(HeroAttributes a, HeroAttributes b)
        {
            return new HeroAttributes
            {
                Strength = a.Strength + b.Strength,
                Intelligence = a.Intelligence + b.Intelligence,
                Dexterity = a.Dexterity + b.Dexterity
            };
        }
    }
}
