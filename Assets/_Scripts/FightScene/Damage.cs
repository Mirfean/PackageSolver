using Assets._Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Scripts
{
    public class Damage
    {
        public DamageType damageType { get; set; }
        public int amount { get; set; }

        public Damage()
        {
            damageType = DamageType.normal;
            amount = 1;
        }

        public Damage(int _amount)
        {
            this.damageType = DamageType.normal;
            this.amount = _amount;
        }

        public Damage(DamageType dmgt, int _amount)
        {
            this.damageType = dmgt;
            this.amount = _amount;
        }

    }
}
