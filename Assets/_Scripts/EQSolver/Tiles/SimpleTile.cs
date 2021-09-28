using Assets._Scripts.Enums;
using Assets._Scripts.EQSolver;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTile : _Tile
{
    public List<Checker> singleGridCheckers;
    // Start is called before the first frame update
    void Start()
    {
        Status = FillStatus.EMPTY;
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.gameObject.GetComponent<Checker>() != null) singleGridCheckers.Add(child.gameObject.GetComponent<Checker>());
        }
        //Debug.Log($"Checkers: {singleGridCheckers.Count}");
        
    }

    public override bool CheckFullness()
    {
        bool result = true;     //Result for GridSystem
        foreach (Checker checker in singleGridCheckers)
        {
            checker.CheckPuzzle();
            if (checker.Status != FillStatus.FULL && result == true)
            {
                result = false;
                break;
            }
        }
        if (result)
        {
            Debug.Log($"{transform.name} ->Full CheckFullness");
            Status = FillStatus.FULL;
        }
        else Status = FillStatus.EMPTY;
        //Debug.Log($"{transform.gameObject.name} is {Status}");
        return result;
    }

    public bool CheckFullnessOfSingleGrid()
    {
        foreach (Checker checker in singleGridCheckers)
        {
            if (checker.Status == FillStatus.EMPTY)
            {
                Status = FillStatus.EMPTY;
                return false;
            }
        }
        Status = FillStatus.FULL;
        return true;
    }

    public override void AdaptByFieldType()
    {
        int fieldNumberValue = (int)fieldType;
        if (fieldNumberValue == 0 || fieldNumberValue == 999)
        {
            transform.gameObject.SetActive(false);
        }
        else if(fieldNumberValue != 1234)
        {
            Debug.LogError("Yo man, somethings wrong!!!");
        }
    }

}
