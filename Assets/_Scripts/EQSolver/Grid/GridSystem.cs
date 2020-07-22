using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets._Scripts.General;
using Assets._Scripts.EQSolver;
using Assets._Scripts.Data;
using Assets._Scripts.Enums;

public class GridSystem : MonoBehaviour
{
    public List<GridTemplate> ListGrid;
    public bool Win;

    public Level level;

    // Start is called before the first frame update
    void Start()
    {
        Win = false;
        level = LevelsGrid.FlamingWCzapceNaSankach;
        
        Transform[] allChildren = GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            //child.gameObject.SetActive(false);
            if(child.gameObject.GetComponent<GridTemplate>() != null) ListGrid.Add(child.gameObject.GetComponent<GridTemplate>());
        }
        CreateGridFromCode();
        Debug.Log($"Grid elements: {ListGrid.Count}");
        foreach (GridTemplate l in ListGrid)
        {
            //Debug.Log(l);
        }
        
    }

    private void OnLevelWasLoaded(int level)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckAllGrids()
    {
        foreach (GridTemplate singleGrid in ListGrid)
        {
            if(singleGrid.Status == FillStatus.EMPTY) return false;
        }
        return true;
    }

    //Odwołanie się do każdego z SingleGrid po czym w każdym z nich do każdego z SingleGridChecker
    //if all checker == FULL then SingleGrid == Full
    public void CheckAllGridAfterPuzzleMove()
    {
        
        foreach(GridTemplate singleGrid in ListGrid)
        {
            singleGrid.CheckFullness();
        }
        
        
    }

    public void CreateGridFromCode()
    {
        foreach(FieldType temp in level.levelCode)
        {
            foreach(GridTemplate GT in ListGrid)
            {
                if(GT.FieldType == 0)
                {
                    //Debug.Log($"{GT} field type {GT.FieldType} is changing to {temp}");
                    GT.FieldType = temp;
                    GT.AdaptByFieldType();
                    break;
                }
            }
        }
    }

}
