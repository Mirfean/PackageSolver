using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets._Scripts.General;
using Assets._Scripts.EQSolver;
using Assets._Scripts.Data;
using Assets._Scripts.Enums;

public class GridSystem : MonoBehaviour
{
    public List<_Tile> ListGrid;
    public bool Win;

    public Level level;


    // Start is called before the first frame update
    void Start()
    {
        Win = false;

        //Level

        
        //Grid
        List<Transform> ActiveTiles = new List<Transform>(GetComponentsInChildren<Transform>());
        CreateListOfActiveGrids(ActiveTiles);
        CreateGridFromCode();
        ListGrid.Clear();
        CreateListOfActiveGrids(ActiveTiles);

        //Puzzles
        
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
        Debug.Log($"How much I have to check? {ListGrid.Count}");
        foreach (_Tile singleGrid in ListGrid)
        {
            if(singleGrid.Status == FillStatus.EMPTY) return false;
        }
        return true;
    }

    //Odwołanie się do każdego z SingleGrid po czym w każdym z nich do każdego z SingleGridChecker
    //if all checker == FULL then SingleGrid == Full
    public void CheckAllGridAfterPuzzleMove()
    {
        
        foreach(_Tile singleGrid in ListGrid)
        {
            singleGrid.CheckFullness();
        }
        
        
    }

    //
    public void CreateListOfActiveGrids(List<Transform> allChildren)
    {
        foreach (Transform child in allChildren)
        {
            //child.gameObject.SetActive(false);
            if (child.gameObject.GetComponent<_Tile>() != null && child.gameObject.activeSelf) ListGrid.Add(child.gameObject.GetComponent<_Tile>());
        }
    }

    //
    public void CreateGridFromCode()
    {
        foreach(FieldType temp in level.levelCode)
        {
            foreach(_Tile GT in ListGrid)
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
