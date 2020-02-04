using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets._Scripts.General.BaseMethodsAndroid;
using Assets._Scripts.SpaceShips.Guns;

public class ShipGun : MonoBehaviour
{
    public GameObject bullet;
    public Transform Tf;

    public _Gun primaryGun;
    float PrimaryFireRateTimer;

    public _Gun secondGun;
    float SecondFireRateTimer;

    // Start is called before the first frame update
    void Start()
    {
        primaryGun = new BasicGun();
        secondGun = new RocketGun();
        
    }

    // Update is called once per frame
    void Update()
    {
        Tf = this.transform;
        if(CheckTouchThisObjectByTagDeluxe("PrimaryAttackButton") && Time.time > PrimaryFireRateTimer)
        {
            PrimaryFireRateTimer = primaryGun.MakeBullets(this.gameObject, PrimaryFireRateTimer);
        }
        else if(CheckTouchThisObjectByTagDeluxe("SecondAttackButton") && Time.time > SecondFireRateTimer)
        {
            SecondFireRateTimer = secondGun.MakeBullets(this.gameObject, SecondFireRateTimer);
        }
        
    }
    
    //Same thing in Gun class
    //private GameObject MakeBullet()
    //{
    //    GameObject x = GameObject.Instantiate(bullet, transform.position, transform.rotation);
    //    x.GetComponent<Rigidbody>().AddForce(15, 0, 0);
    //    return x; 
    //}

}
