using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Heroes
{
    public class Rogue : Hero
    {
        public Rogue(string name) : base(name)
        {
            LevelAttributes = new(2, 1, 6);
        }

        public override void LevelUp()
        {
            base.LevelUp();
            LevelAttributes.IncreaseAttributes(1, 1, 4);
        }
    }
}
