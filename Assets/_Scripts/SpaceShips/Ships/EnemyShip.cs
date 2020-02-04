using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : _Ship
{
    // Start is called before the first frame update
    void Start()
    {
        Hp = 15;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter(Collision col)
    {
        //For multiple hits at the same time?
        //foreach (ContactPoint contact in collision.contacts)
        //{
        //    Debug.DrawRay(contact.point, contact.normal, Color.white);
        //}

        if (col.gameObject.layer == 12)
        {
            GetHitted(col.gameObject.GetComponent<Bullet>().Dmg);
        }

    }

    


}
