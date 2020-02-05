using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets._Scripts.General.BaseMethodsAndroid;

public class Paddle : MonoBehaviour
{

    public float speed { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        Debug.Log("Screen ->" + Screen.width);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FollowFinger(Touch touch)
    {
        Debug.Log($"normal {touch.position.x}");
        Debug.Log($"raw {touch.rawPosition.x}");
        Vector3 temp = TouchPosToCameraPos(touch);
        transform.SetPositionAndRotation(new Vector3(temp.x,transform.position.y,transform.position.z),transform.rotation);
    }

    public void MovePaddle(float fingerDirection)
    {
        Debug.Log("Finger ->" + fingerDirection);
        
        float tempSpeed = 0;
        if (Screen.width / 2 < fingerDirection) { tempSpeed = speed; }
        else if(Screen.width / 2 > fingerDirection) { tempSpeed = -speed; }
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(fingerDirection, transform.position.y), tempSpeed/2 * Time.deltaTime);
    }

    public void StopPaddle()
    {
        Debug.Log("STOP!!!");
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        
    }
}
