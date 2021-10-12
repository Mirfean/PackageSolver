using System;
using UnityEngine;

namespace Assets._Scripts.General
{
    public static class BaseMethods
    {
        //Initialize
        //static FightManager FM = GameObject.Find("FightManager").GetComponent<FightManager>();

        public static String CheckObjectTag()
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                //if (hit.transform.tag == ObjectTag)
                if (hit.collider.name != null)
                {
                    Debug.Log("I AM ON SOMETHING!!!!");
                    return hit.collider.tag;
                }
                else { return null; }
            }
            return null;
        }

        //Empty
        public static void SetIsAttacking(bool desiredState)
        {
            //FM.IsAttacking = desiredState;
            //FM.UpdateStatementTextFromAttack(desiredState);
            //Debug.Log("IsAttacking changed to" + desiredState);
        }

        //CHANGE THAT LATER !!!
        public static bool GetIsAttacking()
        {
            //return FM.IsAttacking;
            return false;
        }

        public static GameObject GetChildByName(Transform Parent, string ChildName)
        {
            Debug.Log(Parent);
            foreach (Transform children in Parent)
            {
                if (children.gameObject.name == ChildName)
                {
                    return children.gameObject;
                }
            }
            return null;
        }

        public static float RoundToGrid(float gridSize, float pos)
        {
            if (Mathf.Abs(pos) < gridSize / 2)
            {
                return 0;
            }
            else if (pos < 0)
            {
                if (pos <= -gridSize * 1.5)
                {
                    return -2 * gridSize;
                }
                else return -gridSize;
            }
            else
            {
                if (pos > gridSize * 1.5)
                {
                    return 2 * gridSize;
                }
                else return gridSize;
            }
        }

        public static float RoundValue(float gridSize, float pos)
        {
            float modulus = pos % gridSize;
            if (modulus < gridSize / 2) return pos - modulus;
            return pos > 0 ? pos - modulus + gridSize : pos - modulus;
            
        }

        public static float RoundValue_NEW(float grid, float value)
        {
            bool negative = value < 0 ? true : false;
            value = Math.Abs(value);
            float r = value % grid;
            if (r >= grid / 2)
            {
                return negative ? -(value - r + grid) : value - r + grid;
            }
            else
            {
                return negative ? -(value - r) : value - r;
            }
        }
    }
}