using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : _Ship
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == 15)
        {
            GetHitted(col.gameObject.GetComponent<Bullet>().Dmg);
        }
    }




}
