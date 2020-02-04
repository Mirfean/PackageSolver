using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets._Scripts.General.BaseMethodsAndroid;
using UnityEngine.EventSystems;

public class JoystickCan : MonoBehaviour
{
    public GameObject gameObjectCanvas;
    public Canvas JoyCan;   //Joystick Canvas
    public GameObject _joystick;
    public Joystick joystick;
    public GameObject JoyStoper;


    void Start()
    {
        GameObject x = GameObject.Find("MainCamera");

        //Find the object you're looking for
        //GameObject tempObject = GameObject.Find("MainCanvas");
        gameObjectCanvas = GameObject.FindGameObjectWithTag("JoystickCan");
        if (gameObjectCanvas != null)
        {
            //If we found the object, get the Canvas component from it.
            //JoyCan = tempObject.GetComponentInChildren<Canvas>();
            JoyCan = gameObjectCanvas.GetComponent<Canvas>();
            if (JoyCan == null)
            {
                Debug.Log("Could not locate Canvas component on " + gameObjectCanvas.name);
            }
            else
            {
                JoyStoper = GameObject.Find("JoyStoper");
                //joystick = JoyCan.GetComponentInChildren<FixedJoystick>();        
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckTouchThisObjectByTagDeluxe("JoystickStoper") && 1 == 0)
        {
            Touch? temp = GetTouchFromObject(JoyStoper);
            RaycastHit? rh = GetRaycastHitFromObject(JoyStoper);
            if (temp != null || rh != null)
            {
                RaycastHit TempRh = rh.Value;
                _joystick.transform.SetPositionAndRotation(TempRh.transform.position, joystick.transform.rotation);
                Debug.Log(_joystick.transform.position.x + "<-x  y->" + _joystick.transform.position.y);
                
                
                //Touch temp2 = temp.Value;
                //Debug.Log(temp2.position + " normal");
                //Debug.Log(temp2.rawPosition + " raw");
                //_joystick.transform.SetPositionAndRotation(temp2.position, joystick.transform.rotation);
                //Debug.Log(_joystick.transform.position.x + "<-x  y->" + _joystick.transform.position.y);



                //joystick.transform.position.x = temp2.position.x;
            }
        }
        
        //foreach (Touch touch in Input.touches)
        //{
        //    int pointerID = touch.fingerId;
        //    if (EventSystem.current.IsPointerOverGameObject(pointerID))
        //    {

        //        // at least on touch is over a canvas UI
        //        return;
        //    }

        //    if (touch.phase == TouchPhase.Ended)
        //    {
        //        // here we don't know if the touch was over an canvas UI
        //        return;
        //    }
        //}
    }

}
