using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMod : MonoBehaviour
{
    bool doubleTap;
    float lastTap, tapTime;
 
    // Start is called before the first frame update
    void Start()
    {
        doubleTap = false;
        tapTime = 0.4f;
        lastTap = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (doubleTap)
        {
            if ((Time.time - lastTap) > tapTime)
            {
                Debug.Log("Too late, time out");
                doubleTap = false;
            }
        }
    }

    public void ChangeRotation()
    {
        Debug.Log("ChangeRotation");
        if (doubleTap)
            {
                RotateSprite();
                doubleTap = false;
            }
        
        else
            {
                doubleTap = true;
                lastTap = Time.time;
            }
    }

    void RotateSprite()
    {
        Debug.Log("RotateSprite");
        transform.Rotate(new Vector3(0, 0, -90));
        if(transform.rotation.z <= -360) { transform.Rotate(new Vector3(0, 0, 360)); }
    }

}
