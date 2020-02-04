using Assets._Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Scripts
{
    public class Armor
    {
        String name;
        Dictionary<DamageType, int> resists;
        Armor()
        {
            name = "Default Armor";
            foreach (DamageType damageType in Enum.GetValues(typeof(DamageType)))
            {
                resists.Add(damageType, 0);
            }
        }

        void ChangeSingleResist(DamageType damageType, int value)
        {
            resists[damageType] += value;
        }
    }
}
