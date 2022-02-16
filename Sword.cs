using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mis321_pa2_Dnsavage.Interfaces;

namespace mis321_pa2_Dnsavage
{
    public class Sword : IAttack
    {
        public IAttack attackBehavior {get; set;}
        public string Attack()
        {
            return "Sword Slash";
        }
    }
}