using RPGHeroes.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RPGHeroes.Enums.SlotsEnum;

namespace RPGHeroes.Items
{
    public abstract class Item
    {
        public string Name { get; set; }
        public int RequiredLevel { get; set; }
        public Slots Slot { get; set; }

        protected Item(string name)
        {
            Name = name;
        }
    }
}
