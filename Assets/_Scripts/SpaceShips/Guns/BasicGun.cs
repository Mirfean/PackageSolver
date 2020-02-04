using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Scripts.SpaceShips.Guns
{
    public class BasicGun : UnlimitedGun
    {

        public BasicGun() : base()
        {
            FireRate = 0.2f;
            BulletPerShot = 2;
            DamagePerBullet = 3;
            SpeedOfBullet = 15;
        }
    }
}
