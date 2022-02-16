using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mis321_pa2_Dnsavage.Interfaces;

namespace mis321_pa2_Dnsavage
{
    public class Rope : IDefend
    {
        public IDefend defendBehavior {get; set;}
        public string Defend()
        {
            return "Rope Swing";
        }
    }
}