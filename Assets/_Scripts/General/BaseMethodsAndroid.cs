using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets._Scripts.Enums;

namespace Assets._Scripts.General
{
    public class BaseMethodsAndroid
    {

        public static string TargetName = "Target";
        public static string SpriteName = "Sprite";
        public static string PuzzleTag = "PuzzleElement";

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

        //return Vector of touch(real for us)
        public static Vector3 TouchPosToCameraPos(Touch touch)
        {
            Vector3 screenPos = new Vector3(touch.position.x, touch.position.y,0);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            return worldPos;
        }

        public static bool CheckObjectAboveByTag(GameObject start, String targetTag)
        {
            if (Physics.Raycast(start.transform.position,Vector3.back, out RaycastHit hit))
            {
                //if (hit.transform.tag == ObjectTag)
                if (hit.collider != null && hit.collider.gameObject.tag == targetTag)
                {
                    Debug.Log(hit.collider + " is Above!!!");
                    return true;
                }
                Debug.Log("Nope");
                return false;
            }
            //Debug.Log("Nope^2");
            return false;
        }



        /*

            Swipe functions
            
        */

        public static float VerticalMovementDistance(Vector2 fingerDownPosition, Vector2 fingerUpPosition)
        {
            return Mathf.Abs(fingerDownPosition.y - fingerUpPosition.y);
        }

        public static float HorizontalMovementDistance(Vector2 fingerDownPosition, Vector2 fingerUpPosition)
        {
            return Mathf.Abs(fingerDownPosition.x - fingerUpPosition.x);
        }

        public static bool IsVerticalSwipe(Vector2 fingerDownPosition, Vector2 fingerUpPosition)
        {
            return VerticalMovementDistance(fingerDownPosition, fingerUpPosition) > HorizontalMovementDistance(fingerDownPosition, fingerUpPosition);
        }

        public static bool SwipeDistanceCheckMet(Vector2 fingerDownPosition, Vector2 fingerUpPosition, float minDistanceForSwipe)
        {
            return VerticalMovementDistance(fingerDownPosition, fingerUpPosition) > minDistanceForSwipe || HorizontalMovementDistance(fingerDownPosition, fingerUpPosition) > minDistanceForSwipe;
        }

        public static bool CheckMinDistance(Vector2 fingerDownPosition, Vector2 fingerUpPosition, float minDistanceForSwipe)
        {
            if (SwipeDistanceCheckMet(fingerDownPosition, fingerUpPosition, minDistanceForSwipe))
            {
                return true;
            }
            return false;
        }

        public static SwipeDirection DetectSwipeDirection(Vector2 fingerDownPosition, Vector2 fingerUpPosition)
        {
            if (IsVerticalSwipe(fingerDownPosition, fingerUpPosition))
            {
                var direction = fingerDownPosition.y - fingerUpPosition.y > 0 ? SwipeDirection.Up : SwipeDirection.Down;
                return direction;
            }
            else
            {
                var direction = fingerDownPosition.x - fingerUpPosition.x > 0 ? SwipeDirection.Right : SwipeDirection.Left;
                return direction;
            }
        }
    }
}
