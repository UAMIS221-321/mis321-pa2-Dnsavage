using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mis321_pa2_Dnsavage.Interfaces;

namespace mis321_pa2_Dnsavage
{
    public class NoModifier : IModify
    {
        public int Modify()
        {
            return -1;
        }
        public void Effect()
        {

        }
    }
}