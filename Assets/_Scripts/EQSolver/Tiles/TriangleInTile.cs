using Assets._Scripts.Enums;
using Assets._Scripts.EQSolver;
using System.Collections.Generic;
using UnityEngine;

public class TriangleInTile : MonoBehaviour
{
    public FillStatus StatusCheckers { get; private set; }      //If all Checkers in that triangle are full then it is too
    public TriangleType Placement;  //What type of triangle it is in SingleGrid - Up,Left etc.

    private bool activationParam;
    public bool ActivationParam
    {
        get { return this.activationParam; }

        set
        {
            if (activationParam != value)
            {
                activationParam = value;
                ChangeActiveOfGO();
            }
        }
    }
    public string NameOfTriange { get; private set; }           //Name of Gameobject(not sure if still nesessary)
    public List<Checker> GridCheckers;

    // Start is called before the first frame update
    void Start()
    {
        StatusCheckers = FillStatus.EMPTY;
        NameOfTriange = transform.gameObject.tag;
        //ActivationParam = false;

        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.gameObject.GetComponent<Checker>() != null) GridCheckers.Add(child.gameObject.GetComponent<Checker>());
        }
        Debug.Log($"Checkers: {GridCheckers.Count}");
        foreach (Checker x in GridCheckers)
        {
            Debug.Log(x);
        }

    }

    public bool CheckFullnessOfCheckers()
    {
        bool result = true;     //Result for GridSystem
        foreach (Checker checker in GridCheckers)
        {
            checker.CheckPuzzle();
            if (checker.Status != FillStatus.FULL)
            {
                result = false;
                break;
            }
        }
        if (result)
        {
            Debug.Log($"{transform.name} ->Full CheckFullness");
            StatusCheckers = FillStatus.FULL;
        }
        else StatusCheckers = FillStatus.EMPTY;
        Debug.Log($"{transform.gameObject.name} is {StatusCheckers}");
        return result;
    }

    /// <summary>
    /// Set Activeness of triangle object according to its checkers 
    /// </summary>
    public void ChangeActiveOfGO()
    {
        //Debug.Log($"{this} is changing to {ActivationParam}");
        transform.gameObject.SetActive(ActivationParam);
    }

    public void ChangeStatusOfFullness(bool x)
    {
        if (x)
        {
            StatusCheckers = FillStatus.FULL;
        }
        else StatusCheckers = FillStatus.EMPTY;
    }

    public void ChangeStatusOfFullness()
    {
        if (StatusCheckers == FillStatus.EMPTY)
        {
            StatusCheckers = FillStatus.FULL;
        }
        else StatusCheckers = FillStatus.EMPTY;
    }
}
