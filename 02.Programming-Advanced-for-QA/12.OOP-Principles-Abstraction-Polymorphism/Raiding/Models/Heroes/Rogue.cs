﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Models.Heroes
{
    internal class Rogue : Fighter
    {
        public Rogue(string name) : base(name)
        {
        }
        public override int Power => 80;
        public override string CastAbility()
        {
            return base.CastAbility();
        }
    }
}
