using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets._Scripts.General.BaseMethodsAndroid;

public class PaddleControl : MonoBehaviour
{

    public GameObject Paddle;
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject bottomButton;
    

    // Start is called before the first frame update
    void Start()
    {
        /* To do:
         * Change to private but first catch them
         * 
         */



    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            float? fingerDirection = MovingByTouch();
            if (fingerDirection.HasValue)
            {
                Paddle.GetComponent<Paddle>().MovePaddle(fingerDirection.Value);
            }
            else { return; }
        }
        else { Paddle.GetComponent<Paddle>().StopPaddle(); }
    }



    public Vector2 SetCurrentMove(bool InRight)
    {
        Vector2 temp;
        if (InRight) { temp = Vector2.right; }
        else { temp = Vector2.left; }
        return  temp * Paddle.GetComponent<Paddle>().speed * Time.deltaTime;
    }

    private void MovingByLeftAndRight()
    {
        if (CheckTouchThisObjectByTagDeluxe(leftButton.tag))
        {
            Paddle.GetComponent<Rigidbody2D>().velocity = SetCurrentMove(false);
        }
        else if (CheckTouchThisObjectByTagDeluxe(rightButton.tag))
        {
            Paddle.GetComponent<Rigidbody2D>().velocity = SetCurrentMove(true);
        }
        else
        {
            //Paddle.GetComponent<Rigidbody2D>().velocity *= 0.8f;
            //slowingCounter++;
            //if (slowingCounter >= slower) { rb.velocity = new Vector3(0, 0, 0); slowingCounter = 0; }
            Paddle.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

    private float? MovingByTouch()
    {
        Touch? tempTouchCheck = GetTouchFromObject(bottomButton);
        //MovingByLeftAndRight();
        if (tempTouchCheck != null)
        {
            Touch tempTouchReal = (Touch)tempTouchCheck;
            return tempTouchReal.position.x;
        }
        return null;
    }

}
