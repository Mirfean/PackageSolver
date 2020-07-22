using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinLevelCan : MonoBehaviour
{
    public GameObject WinButtonObject;
    public GameObject EndBackground;
    public GameObject Text;

    // Start is called before the first frame update
    void Start()
    {
        WinButtonObject.SetActive(false);
        EndBackground.SetActive(false);
        //Change that to foreach later
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WinAnnouncer()
    {
        EndBackground.SetActive(true);
        WinButtonObject.SetActive(true);
    }

}
