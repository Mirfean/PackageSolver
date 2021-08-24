using Assets._Scripts.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMaster : MonoBehaviour
{
    string level;
    GameStatus gameStatus;
    public GridSystem Grid;
    public WinLevelCan WinLevelCan;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 100;

        gameStatus = GameStatus.BeforeStart;

        /*Preparation
         * 
         */

        gameStatus = GameStatus.InProgress;
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void WinCondition()
    {
        Debug.Log("Did I win?");
        if (Grid.CheckAllGrids())
        {
            WinLevel();

            //Make some magic here!!!
            SaveSystem.SavePlayer();
            

            Debug.Log("YEEEES");
        }
        else
        {
            Debug.Log("Not yet?");
        }
    }

    void WinLevel()
    {
        gameStatus = GameStatus.Win;
        WinLevelCan.WinAnnouncer();
        Debug.Log("You win this level!!!");
    }

}
