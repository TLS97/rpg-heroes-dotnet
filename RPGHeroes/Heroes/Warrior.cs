using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Heroes
{
    public class Warrior : Hero
    {
        public Warrior(string name) : base(name)
        {
            LevelAttributes = new(5, 1, 2);
        }

        public override void LevelUp()
        {
            base.LevelUp();
            LevelAttributes.IncreaseAttributes(3, 1, 2);
        }
    }
}
