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

    }
}
