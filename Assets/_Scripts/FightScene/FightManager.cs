using Assets._Scripts;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Assets._Scripts.General.BaseMethodsAndroid;

public class FightManager : MonoBehaviour
{
    public bool IsAttacking;
    public PlayerInFight playerUnit;    
    public GameObject currentUnit { get; set; }      //Unit who has current turn - helpful to take damage value etc.
    public GameObject MainCanvas;
    public Text StatementText { get; set; }

    public GameObject temp; //For some purposes

    // Start is called before the first frame update
    void Start()
    {
        IsAttacking = false;
        playerUnit = GameObject.FindGameObjectWithTag("player").GetComponent<PlayerInFight>();
        MainCanvas = GameObject.FindGameObjectWithTag("mainCanvas");
        var textTransform = MainCanvas.transform.Find("StatementText");
        StatementText = textTransform.GetComponent<Text>();
        //Add things xD
    }



    // Update is called once per frame
    void Update()
    {


        //if(CheckTouchThisObjectByTag("attackButton")) { IsAttacking = true; }
        if (IsAttacking)
        {

            GameObject temp = GetObjectFromTouch();
            if(temp != null)
            {
                //+ dmg from currentUnit
                Debug.Log($"Player name is {playerUnit.Damage[0].damageType} damage for {playerUnit.Damage[0].amount}");
                
                DealDamageToSingleUnit(temp, playerUnit.Damage);
                IsAttacking = false;
                //StatementText.text = "";
            }
        }
        //if (IsAttacking && CheckClickThisObject("enemy"))
    }

    void DealDamageToSingleUnit(GameObject target,List<Damage> damages)
    {
        //GameObject Unit = GameObject.Find(target);
        switch (target.tag)
        {
            case "player":
                Debug.Log("player hitted");
                target.GetComponent<PlayerInFight>().LoseHp(damages);
                break;
            case "enemy":
                Debug.Log("enemy hitted");
                target.GetComponent<EnemyInFight>().LoseHp(damages);
                break;
            case "structure":
                Debug.Log("structure hitted");
                //TO DO
                break;
            default:
                Debug.Log("Add new UnitsType Enum, dumbass...");
                break;
        }

    }   //Deal many types of damage in one hit(e.g. Ice Lance -> 10 Normal + 5 Ice damage)

    void DealSingleDamageToSingleUnit(string target, Damage damage)
    {
        GameObject Unit = GameObject.Find(target);
        switch (Unit.tag)
        {
            case "player":
                Debug.Log("player hitted");
                Unit.GetComponent<PlayerInFight>().LoseHp(damage);
                break;
            case "enemy":
                Debug.Log("enemy hitted");
                Unit.GetComponent<EnemyInFight>().LoseHp(damage);
                break;
            case "structure":
                Debug.Log("structure hitted");
                //TO DO
                break;
            default:
                Debug.Log("Add new UnitsType Enum, dumbass...");
                break;
        }

    }   //Deal single type damage from hit

    public void UpdateStatementTextFromAttack(bool desiredState)     //Change text of StatementText
    {
        if (desiredState)
        {
            StatementText.text = "Touch enemy to hit";
        }
        else
        {
            StatementText.text = "";
        }
    }
}
