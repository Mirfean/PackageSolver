using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(9, 12);    //Player <-> Player Bullets
        Physics.IgnoreLayerCollision(10, 12);   //Gun <-> Player Bullets
        Physics.IgnoreLayerCollision(12, 12);   //Player Bullets <-> Player Bullets
        Physics.IgnoreLayerCollision(15, 15);   //Enemy Bullets <-> Enemy Bullets
        Physics.IgnoreLayerCollision(12, 15);   //Player Bullets <-> Enemy Bullets
        //Physics.IgnoreLayerCollision(9, 14);   //Player <-> Enemy CHANGE IT LATER TO MAKE DMG 


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
