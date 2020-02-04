using Assets._Scripts.SpaceShips.Guns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float Dmg { get; set; }

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
        //For multiple hits at the same time?
        //foreach (ContactPoint contact in collision.contacts)
        //{
        //    Debug.DrawRay(contact.point, contact.normal, Color.white);
        //}
        if(this.gameObject.layer == 12 && col.gameObject.layer == 14)
        {
            Destroy(gameObject);
        }
        else if(this.gameObject.layer == 15 && col.gameObject.layer == 9)
        {
            Destroy(gameObject);
        }
    }

}
