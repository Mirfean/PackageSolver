using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets._Scripts.SpaceShips.Guns
{
    public class _Gun
    {
        public float FireRate { get; protected set; }
        public float DamagePerBullet { get; protected set; }
        public int BulletPerShot { get; protected set; }
        public float SpeedOfBullet { get; protected set; }
        public GameObject bullet; //Make this generating, not take from current scene
        public bool AmmoRequired { get; protected set; }
        /// </summary>
        //type of damage
        //magazine?
        //
        public _Gun()
        {
            FireRate = 0.25f;
            BulletPerShot = 1;
            DamagePerBullet = 1;
            SpeedOfBullet = 10;
            bullet = GameObject.Find("BasicBullet");
        }

        public virtual float MakeBullets(GameObject gunner, float timer)
        {
            var x = BulletPerShot;
            while (x > 0)
            {
                MonoBehaviour.Destroy(MakeBullet(gunner), 3);
                --x;
            }
            timer = Time.time + FireRate;
            return timer;
        }

        public virtual GameObject MakeBullet(GameObject gunner)
        {
            GameObject x = GameObject.Instantiate(bullet, gunner.transform.position, gunner.transform.rotation);
            x.GetComponent<Bullet>().Dmg = DamagePerBullet;
            x.GetComponent<Rigidbody>().AddForce(SpeedOfBullet, 0, 0);
            return x;
        }
    }
}
