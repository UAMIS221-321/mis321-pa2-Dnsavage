using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mis321_pa2_Dnsavage.Interfaces;

namespace mis321_pa2_Dnsavage
{
    public class Claw : IDefend
    {
        public IDefend defendBehavior {get; set;}
        public string Defend()
        {
            return "Claw Shield";
        }
    }
}