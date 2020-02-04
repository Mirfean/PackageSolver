using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Ship : MonoBehaviour
{
    public float Hp { get; protected set; }
    //Add Shield
    float Armor = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    protected bool LoseHp(float dmgValue)
    {
        Hp -= (dmgValue-Armor);
        if (Hp <= 0) return true;
        return false;
    }

    public void GetHitted(float dmgValue)
    {
        bool IsDead = LoseHp(dmgValue);
        if (IsDead)
        {
            Destroy(gameObject);
        }
    }

}
