using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mis321_pa2_Dnsavage.Interfaces;

namespace mis321_pa2_Dnsavage
{
    public class Stunned : IModify
    {
        public int Modify()
        {
            return 1;
        }
        public void Effect()
        {
            Console.WriteLine("You are stunned! Your attacks are as aimless as they are pointless!\n");
        }
    }
}