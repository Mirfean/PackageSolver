using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Scripts.SpaceShips.Guns
{
    public class LimitedGun : _Gun
    {
        public int Ammo { get; protected set; }

        protected LimitedGun()
        {
            //base.
            AmmoRequired = true;
        }
    }
}
