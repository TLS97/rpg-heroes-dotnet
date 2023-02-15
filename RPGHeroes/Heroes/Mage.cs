using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Heroes
{
    public class Mage : Hero
    {
        public Mage(string name) : base(name) 
        {
            LevelAttributes = new(1, 8, 1);
        }

        public override void LevelUp()
        {
            base.LevelUp();

            LevelAttributes.IncreaseAttributes(1, 5, 1);
        }
    }
}
