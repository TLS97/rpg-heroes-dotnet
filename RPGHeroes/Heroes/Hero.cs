using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Heroes
{
    public abstract class Hero
    {
        public string Name { get; }
        public int Level { get; } = 1;
        public HeroAttributes LevelAttributes { get; set; }
        protected Hero(string name)
        {
            Name = name;
        }
    }
}
