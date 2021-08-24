using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets._Scripts.Enums;

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
            foreach(Transform children in Parent)
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

        public static float RoundToGridSupreme(float gridSize, float pos)
        {
            // float result = 0;
            //if (Mathf.Abs(pos) < gridSize / 2)
            //{
            //    return pos;
            //}

            float temp = pos % gridSize;
            float temp2 = pos / gridSize;

            if (pos > 0)
            {
                return temp <= gridSize / 2 ? pos - temp : pos - temp + gridSize;
            }
            else
            {
                //result = temp < -gridSize / 2 ? pos - temp : ((int)temp2+1) * gridSize;
                return Math.Abs(temp) <= gridSize / 2 ? pos - temp : pos - gridSize - temp;
            }


        }

    }
}
