using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mis321_pa2_Dnsavage.Interfaces;

namespace mis321_pa2_Dnsavage
{
    public class Jar : ISpecial
    {
        public ISpecial specialBehavior {get; set;}
        public string Special()
        {
            return "Jar of Dirt";
        }
    }
}