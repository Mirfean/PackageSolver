using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.Log(Input.mousePosition);
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                //if (hit.transform.tag == ObjectTag)
                if (hit.collider != null)
                {
                    Debug.Log(hit.collider + " is clicked by mouse");
                }
                else { Debug.Log("dupa :/"); }
            }
            else { Debug.Log("Nothing clicked"); }
        }
    }
}
