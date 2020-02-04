using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Assets._Scripts.General.BaseMethodsAndroid;

public class StatusBar : MonoBehaviour
{

    public HealthBar healthBar { get; set; }
    public Canvas unitCanvas { get; set; }
    public TextMeshPro statusText { get; set; }
    //public TextMeshPro TextMeshPro

    // Start is called before the first frame update
    void Start()
    {
        healthBar = transform.Find("HpBar").GetComponent<HealthBar>();
        //unitCanvas = transform.Find("UnitCanvas").GetComponent<Canvas>();
        //TODO statusText = unitCanvas.GetComponentInChildren<TextMeshPro>();
        if (healthBar != null)
        {
            Debug.Log("Pozdro z HealthBar");
        }
        if (unitCanvas != null)
        {
            Debug.Log("Pozdro z UnitCanvas");
        }
        if(statusText != null)
        {
            Debug.Log(statusText.text);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (CheckTouchThisObject(transform.parent.gameObject) && Input.touchCount == 1)
        {
            switch (Input.GetTouch(0).phase)
            {
                //When a touch has first been detected, change the message and record the starting position
                case TouchPhase.Began:
                    // Record initial touch position.
                    SetStatusText(healthBar.ReplyHpStatus());
                    break;

                //Determine if the touch is a moving touch
                //case TouchPhase.Moved:
                    // Determine direction by comparing the current touch position with the initial one
                    //DefaultStatusText();
                    //break;

                //case TouchPhase.Ended:
                    // Report that the touch has ended when it ends
                    //DefaultStatusText();
                    //break;

                //default:
                    //break;
            }
        }
        else {
            //DefaultStatusText();
        }
    }

    public void SetStatusText(string NewText)
    {
        statusText.text = NewText;
    }

    public void ClearStatusText()
    {
        statusText.text = "";
    }

    public void DefaultStatusText()
    {
        statusText.text = transform.parent.name;    //No sure if working properly
    }



}
