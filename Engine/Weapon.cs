using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Weapon:Item
    {
        public int MinDmg { set; get; }
        public int MaxDmg { set; get; }

        public Weapon(int id, string name, string namePlural, int minDmg, int maxDmg, int price) 
            : base(id, name, namePlural, price)
        {
            MinDmg = minDmg;
            MaxDmg = maxDmg;
        }
    }
}
