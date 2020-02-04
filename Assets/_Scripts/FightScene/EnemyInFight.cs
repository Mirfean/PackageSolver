using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets._Scripts;
using Assets._Scripts.Enums;

public class EnemyInFight : UnitInFight
{
    private int X { get; set; }
    public AudioSource audioSource;
    //public GameObject HpBar;
    private float BarSize;
    // Start is called before the first frame update
    new void Start()    //take declarations to contructor in future
    {
        base.Start();
        Damage = new List<Damage>();
        Damage.Add(new Damage(DamageType.normal, 5));
        MaxHp = 60;
        CurrentHp = MaxHp;
        //HpBar = 
        //HpBar.GetComponent<HealthBar>().MaxHp = this.Hp;
        BarSize = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        //CheckHpDiffrence();
        if(CurrentHp <= 0) {

            audioSource.Play();
            
            Destroy(gameObject);
        }
    }

    void OnMouseDown()
    {
        //Show info of Unit
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Kremowka")
        {
            LoseHp(new Damage(21));
        }
    }

}
