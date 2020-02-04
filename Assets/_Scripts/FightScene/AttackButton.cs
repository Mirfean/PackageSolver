using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets._Scripts.General.BaseMethodsAndroid;
using static Assets._Scripts.General.BaseMethods;

public class AttackButton : MonoBehaviour
{
    GameObject Player;
    //GameObject Enemy;
    public GameObject Kremowa;
    static FightManager FightManag;
    float timeBetweenKremowka;
    float timestamp;

    void Start()
    {
        Player = GameObject.Find("Player");
        FightManag = GameObject.Find("FightManager").GetComponent<FightManager>();
        //Enemy = GameObject.Find("Enemy");
        timeBetweenKremowka = 1f;
        timestamp = Time.time;
    }


    private void Update()
    {
        if (Input.touchCount > 0 && GetIsAttacking() == false)
        {
            
            if (CheckTouchThisObjectByTagDeluxe("attackButton"))
            {
                KremowkaShot();
                SetIsAttacking(true);
                
            }
            //if (Input.GetKeyUp("c"))    //Click 'c' to cancel attack
            //{
            //    SetIsAttacking(false);
            //    //Attacking = GetIsAttacking();
            //}
        }
    }

    private void KremowkaShot()
    {
        if (Time.time >= timestamp)
        {
            GameObject x = Instantiate(Kremowa, GameObject.Find("Kremowgun").transform.position + new Vector3(10f, 0, 0), new Quaternion());
            x.GetComponent<Rigidbody>().AddForce(new Vector3(50f, 0, 0));
            timestamp = Time.time + timeBetweenKremowka;
        }


        Debug.Log("Kremowka incoming!");
        //GameObject Kremowa = GameObject.Find("kremowkaSupremeTemplate");
        
        
    }


    //void OnMouseDown() { SetIsAttacking(true); }
    //Attacking = GetIsAttacking();
    //Enemy.GetComponent<EnemyInFight>().Hp -= Player.GetComponent<PlayerInFight>().Damage;


}
