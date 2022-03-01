using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mis321_pa2_Dnsavage.Interfaces;

namespace mis321_pa2_Dnsavage
{
    public class Recruited : IModify
    {
        public int Modify()
        {
            return 3;
        }
        public void Effect()
        {
            Console.WriteLine("You've been recruited as part of the Dutchman's crew!");
            Console.WriteLine("Any attempt at attacking will inflict pain upon yourself!\n");
        }
    }
}