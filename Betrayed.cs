using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mis321_pa2_Dnsavage.Interfaces;

namespace mis321_pa2_Dnsavage
{
    public class Betrayed : IModify
    {
        public int Modify()
        {
            return 2;
        }
        public void Effect()
        {
            Console.WriteLine("A betrayer walks among you!");
            Console.WriteLine("Defensive actions are pointless, as the enemy now knows your every weakness!");
        }
    }
}