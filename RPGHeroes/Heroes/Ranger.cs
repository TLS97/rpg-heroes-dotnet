﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Heroes
{
    public class Ranger : Hero
    {
        public Ranger(string name) : base(name)
        {
            LevelAttributes = new(1, 1, 7);
        }
    }
}
