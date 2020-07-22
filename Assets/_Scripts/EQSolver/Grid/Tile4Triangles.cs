using Assets._Scripts.Enums;
using Assets._Scripts.EQSolver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile4Triangles : GridTemplate
{
    //_SingleGridStatus Status;
    public List<TriangleInTile> CurrentTriangles;

    private FieldType _fieldType;
    public FieldType _FieldType
    {
        get { return _fieldType; }
        set
        {
            this._fieldType = value;
            //MakeActiveTriangleList();
        }
    }

    private void Awake()
    {
        GetTriangleList();
    }

    // Start is called before the first frame update
    void Start()
    {
        //GetTriangleList();
        //AdaptByFieldType();
        //GetTriangleList();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void AdaptByFieldType()
    {
        ModifyTrianglesByFieldType();
    }

    private void GetTriangleList()
    {
        CurrentTriangles.Clear();
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.gameObject.GetComponent<TriangleInTile>() != null) CurrentTriangles.Add(child.gameObject.GetComponent<TriangleInTile>());
        }
    }

    public bool CheckFullnessOfTriangles()
    {
        bool result = true;
        foreach (TriangleInTile triangle in CurrentTriangles)
        {
            //checker.CheckPuzzle();
            if (triangle.StatusCheckers != FillStatus.FULL && result == true)
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
        Debug.Log($"{transform.gameObject.name} is {Status}");
        return result;
    }



    public bool CheckFullnessOfSingleGrid()
    {
        foreach (TriangleInTile triangle in CurrentTriangles)
        {
            triangle.CheckFullnessOfCheckers();
            Debug.Log(triangle.StatusCheckers);
            if (triangle.StatusCheckers == FillStatus.EMPTY)
            {
                Status = FillStatus.EMPTY;
                return false;
            }
        }
        Status = FillStatus.FULL;
        Debug.Log("All triangles full");
        return true;
    }

    void ModifyTrianglesByFieldType()
    {
        int fieldNumberValue = (int)FieldType;
        string valueInText = fieldNumberValue.ToString();
        if (valueInText[0] == 0 || valueInText == "999")
        {
            transform.gameObject.SetActive(false);
            return;
        }
        foreach (char c in valueInText)
        {
            //int x = 1;
            //Debug.Log($"Changing {x}triangles of {this}");
            ActivationOfTriangle(c);
        }
        foreach(TriangleInTile triangle in CurrentTriangles)
        {
            triangle.ChangeActiveOfGO();
        }
    }

    void ActivationOfTriangle(char c)
    {

        switch (c)
        {
            //Active N
            case '1':
                {
                    CurrentTriangles.Find(i => i.Placement == TriangleType.UP).ActivationParam = true;
                    break;
                }
            //Active W
            case '2':
                {
                    CurrentTriangles.Find(i => i.Placement == TriangleType.LEFT).ActivationParam = true;
                    break;
                }
            //Active E
            case '3':
                {

                    CurrentTriangles.Find(i => i.Placement == TriangleType.RIGHT).ActivationParam = true;
                    break;
                }
            //Active S
            case '4':
                {
                    CurrentTriangles.Find(i => i.Placement == TriangleType.DOWN).ActivationParam = true;
                    break;
                }
            
            default:
                break;
        }
    }

    public override bool CheckFullness()
    {
        return CheckFullnessOfSingleGrid();
    }
}
