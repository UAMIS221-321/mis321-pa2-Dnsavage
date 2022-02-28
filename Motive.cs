using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mis321_pa2_Dnsavage.Interfaces;

namespace mis321_pa2_Dnsavage
{
    public class Motive : ISpecial
    {
        public ISpecial specialBehavior {get; set;}
        public string Special()
        {
            return "Ulterior Motive";
        }
    }
}