using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets._Scripts.Enums;

namespace Assets._Scripts.General
{
    class BaseMethodsAndroid
    {
        public static GameObject GetObjectFromTouch()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            //Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                if (hit.collider != null)
                {
                    Debug.Log("Touched " + hit.collider.gameObject.name);
                    return hit.collider.gameObject;

                }
                Debug.Log("Touchn't");
                return null;
            }
            Debug.Log("Touchn't Raycast");
            return null;
        }

        //Here can be a problem
        public static bool CheckTouchHoldObject(string ObjectTag)
        {
            if (CheckTouchThisObjectByTagDeluxe(ObjectTag))
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    Debug.Log($"Start touching {ObjectTag}");
                    return true;
                    // Halve the size of the cube.
                    //transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
                }
                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    Debug.Log($"Stop touching {ObjectTag}");
                    return false;
                }
                return true;
            }
            return false;
        }

        public static bool CheckTouchThisObject(GameObject targetObject)
        {
            if (Input.touchCount > 0)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;
                //Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log(hit.transform.name);
                    if (hit.collider != null && hit.collider.gameObject.Equals(targetObject))
                    {

                        GameObject touchedObject = hit.transform.gameObject;
                        Debug.Log("Touched " + touchedObject.transform.name);
                        return true;

                    }
                    Debug.Log("Touchn't");
                    return false;
                }
                Debug.Log("Touchn't Raycast");
                return false;
            }
            return false;
        }

        public static bool CheckTouchThisObjectByTagDeluxe(string ObjectTag)
        {
            if (Input.touchCount > 0)
            {
                foreach(Touch touch in Input.touches)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;
                    //Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);
                    if (Physics.Raycast(ray, out hit))
                    {
                        Debug.Log(hit.transform.name);
                        if (hit.collider != null && hit.collider.CompareTag(ObjectTag))
                        {

                            GameObject touchedObject = hit.transform.gameObject;
                            Debug.Log("Touched " + touchedObject.transform.name);
                            return true;

                        }
                        Debug.Log("Touchn't");
                        return false;
                    }
                }
                
            }
            Debug.Log("Touchn't");
            return false;
        }

        public static Touch? GetTouchFromObject(GameObject gameobject)
        {
            if (Input.touchCount > 0)
            {
                foreach (Touch touch in Input.touches)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;
                    //Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.CompareTag(gameobject.tag))
                        {
                            return touch;
                        }
                        Debug.Log("Wrong touching");
                        return null;
                    }
                }

            }
            Debug.Log("No touching");
            return null;
        }

        public static RaycastHit? GetRaycastHitFromObject(GameObject gameobject)
        {
            if (Input.touchCount > 0)
            {
                foreach (Touch touch in Input.touches)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;
                    //Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.CompareTag(gameobject.tag))
                        {
                            return hit;
                        }
                        Debug.Log("Wrong touching");
                        return null;
                    }
                }

            }
            Debug.Log("No touching");
            return null;
        }


        public static bool CheckTouchThisObjectByTag(string ObjectTag)
        {
            if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
            {
                Debug.Log("DING DING!!!");
                //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //Debug.Log(Input.mousePosition);
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.GetTouch(0).position), out RaycastHit hit))
                {
                    if (hit.collider.tag == ObjectTag)
                    {
                        Debug.Log("I HIT " + ObjectTag);
                        return true;
                    }
                    else { Debug.Log("dupa :/"); }
                }
                else { Debug.Log("Nothing clicked"); }
            }
            return false;
        }

        public static String CheckTouchObjectGetName()
        {
            if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
            {
                //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //Debug.Log(Input.mousePosition);
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.GetTouch(0).position), out RaycastHit hit))
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

        public static Vector3 TouchPosToCameraPos(Touch touch)
        {
            Vector3 screenPos = new Vector3(touch.position.x, touch.position.y,0);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            return worldPos;
        }
    }
}
