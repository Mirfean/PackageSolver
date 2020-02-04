using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets._Scripts;
using Assets._Scripts.Enums;

public class PlayerInFight : UnitInFight
{

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        Damage = new List<Damage>();
        Damage.Add(new Damage(DamageType.normal, 3));
        MaxHp = 20;
        CurrentHp = 20;
    }

    // Update is called once per frame
    void Update()
    {
        //CheckHpDiffrence();
    }

    
}
