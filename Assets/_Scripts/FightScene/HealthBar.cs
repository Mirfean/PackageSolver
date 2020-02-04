using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    Vector3 maxSize;

    //public float currentHp;
    //public float MaxHp;
    UnitInFight Unit;
    //public bool damageIsTaken;
    // Start is called before the first frame update
    void Start()
    {
        Unit = transform.parent.parent.GetComponent<UnitInFight>();
        //MaxHp = Unit.MaxHp;
        maxSize = transform.localScale;
    }

    Vector3 ConvertDmgToVector3(float PercentOfMaxHp)
    {
        return new Vector3(maxSize.x*PercentOfMaxHp, 0); 
    }

    public void ModifyHpBar(float CurrentHp, float MaxHp)
    {
        Debug.Log("I will change to ->" + maxSize.x * (CurrentHp / MaxHp));
        transform.localScale = new Vector3 (maxSize.x*(CurrentHp/MaxHp),transform.localScale.y);
    }

    public string ReplyHpStatus()
    {
        return $"{Unit.CurrentHp}/{Unit.MaxHp}";
    }

}
