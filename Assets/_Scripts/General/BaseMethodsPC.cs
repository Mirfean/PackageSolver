using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets._Scripts.Enums;

namespace Assets._Scripts.General
{
    class BaseMethodsPC
    {
        public static bool CheckClickThisObjectByTag(string ObjectTag)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //Debug.Log(Input.mousePosition);
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                {
                    //if (hit.transform.tag == ObjectTag)
                    if (hit.collider.tag == ObjectTag)
                    {
                        Debug.Log("I HIT ENEMY!!!!");
                        return true;
                    }
                    else { Debug.Log("dupa :/"); }
                }
                else { Debug.Log("Nothing clicked"); }
            }
            return false;
        }

        public static String CheckClickObjectGetName()
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
                        return hit.collider.name;
                    }
                    else { Debug.Log("dupa :/"); }
                }
                else { Debug.Log("Nothing clicked"); }
            }
            return null;
        }

        public static String CheckClickUnitGetName()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                {
                    if (hit.collider != null)
                    {

                        if (Enum.IsDefined(typeof(UnitsType), hit.collider.tag))
                        {
                            return hit.collider.name;
                        }
                        Debug.Log(hit.collider + " is clicked by mouse and it's not a Unit");
                    }
                    else { Debug.Log("dupa :/"); }
                }
                else { Debug.Log("Nothing clicked"); }
            }
            return null;
        }
    }
}
