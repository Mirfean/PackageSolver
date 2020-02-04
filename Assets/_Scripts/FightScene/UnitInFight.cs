using UnityEngine;
using Assets._Scripts.Enums;
using Assets._Scripts;
using System.Collections.Generic;

public class UnitInFight : MonoBehaviour
{
    //public int Damage { get; set; }
    public string Name { get; set; }

    public float MaxHp { get; set; }
    public float CurrentHp { get; set; }
    public float LastHp { get; set; }     //Delete this and make better thing to react for lost hp

    //transform.Find("StatusBar").Find("HpBar").GetComponent<HealthBar>();
    public HealthBar healthBar { get; set; }

    public StatusBar UnitStatusBar { get; set; }

    public List<Damage> Damage { get; set; }

    public Armor Armor_ { get; set; }

    internal void Start()
    {
        UnitStatusBar = transform.Find("StatusBar").GetComponent<StatusBar>();
    }

    protected void CheckHpDiffrence()
    {
        if (LastHp != CurrentHp)
        {
            Debug.Log("Hp is now " + CurrentHp);
            LastHp = CurrentHp;
        }
    }

    public float GetCurrentPercentOfHp()
    {
        return (float) CurrentHp/MaxHp;
    }

    public void GainHp(int amount)
    {
        CurrentHp += amount;
        if(CurrentHp > MaxHp) { CurrentHp = MaxHp; }
    }

    public void LoseHp(List<Damage> damages)
    {
        foreach(Damage dmg in damages)
        {
            LoseHp(dmg);
        }
    }

    public void LoseHp(DamageType damageType, int amount)
    {
        LoseHp(new Damage(damageType, amount));
    }

    public void LoseHp(Damage damage)   //Add resistances and modify of text(or make it appear and create only on
    {
        //Add resistance
        CurrentHp -= damage.amount;
        
        UnitStatusBar.healthBar.ModifyHpBar(CurrentHp, MaxHp);

    }




}
