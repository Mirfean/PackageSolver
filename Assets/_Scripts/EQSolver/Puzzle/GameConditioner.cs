using Assets._Scripts.Enums;
using UnityEngine;

public class GameConditioner : MonoBehaviour
{
    private string level;
    private GameStatus gameStatus;
    public GridSystem Grid;
    public WinLevelCan WinLevelCan;

    [SerializeField]
    private GameObject gameMasterObject;
    [SerializeField]
    private GameMaster gameMaster;

    // Start is called before the first frame update
    private void Start()
    {
        Application.targetFrameRate = 100;

        gameMaster = (GameMaster)FindObjectOfType(typeof(GameMaster));

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

            CurrentGameData.UnlockNextLevel();

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
        Debug.Log("You won this level!!!");
    }


}