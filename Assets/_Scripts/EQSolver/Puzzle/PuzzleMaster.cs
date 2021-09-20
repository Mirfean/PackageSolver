using Assets._Scripts.Enums;
using UnityEngine;

public class PuzzleMaster : MonoBehaviour
{
    private string level;
    private GameStatus gameStatus;
    public GridSystem Grid;
    public WinLevelCan WinLevelCan;

    // Start is called before the first frame update
    private void Start()
    {
        Application.targetFrameRate = 100;

        gameStatus = GameStatus.BeforeStart;

        /*Preparation
         *
         */

        gameStatus = GameStatus.InProgress;
    }

    // Update is called once per frame
    private void Update()
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

    private void WinLevel()
    {
        gameStatus = GameStatus.Win;
        WinLevelCan.WinAnnouncer();
        Debug.Log("You win this level!!!");
    }
}