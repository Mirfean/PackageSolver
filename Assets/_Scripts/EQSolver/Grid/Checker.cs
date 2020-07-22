using Assets._Scripts.EQSolver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets._Scripts.General.BaseMethodsAndroid;

public class Checker : MonoBehaviour
{
    public FillStatus Status { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CheckPuzzle()
    {
        if (CheckObjectAboveByTag(this.gameObject, PuzzleTag))
        {
            Debug.Log("On");
            Status = FillStatus.FULL;
        }
        else if(Status == FillStatus.FULL)
        {
            Debug.Log("Off");
            Status = FillStatus.EMPTY;
        }
    }

    public FillStatus CheckPuzzleResult()
    {
        if (CheckObjectAboveByTag(this.gameObject, PuzzleTag))
        {
            Debug.Log("On");
            Status = FillStatus.FULL;
        }
        else if (Status == FillStatus.FULL)
        {
            Debug.Log("Off");
            Status = FillStatus.EMPTY;
        }
        return Status;
    }

    private void Update()
    {
        //CheckPuzzle();
    }
}
