using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLevelCan : MonoBehaviour
{
    public GameObject YouWinSign;
    public GameObject WinButtonObject;
    public GameObject EndBackground;
    public GameObject Text;

    // Start is called before the first frame update
    void Start()
    {
        YouWinSign.SetActive(false);
        //EndBackground.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Run after completing level
    public void WinAnnouncer()
    {
        YouWinSign.SetActive(true);
        //EndBackground.SetActive(true);
        
    }

}
