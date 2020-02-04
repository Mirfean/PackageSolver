using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Scripts.SpaceShips.Guns
{
    public class RocketGun : LimitedGun
    {
        public RocketGun() : base()
        {
            
            DamagePerBullet = 50;
            BulletPerShot = 1;
            FireRate = 0.5f;
            SpeedOfBullet = 30;
            Ammo = 15;
            bullet = GameObject.Find("RocketGunBullet");
        }
        
    }
}
