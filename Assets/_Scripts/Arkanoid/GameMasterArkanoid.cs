using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets._Scripts.Enums;

public static class GameMasterArkanoid
{
    public static GameStatus CurrentGameStatus { get; private set; }

    public static int PlayerLives = 3;

    public static void GameStarting()
    {
        CurrentGameStatus = GameStatus.InProgress;
    }

    public static void LoseLive()
    {
        PlayerLives--;
    }



    public static void ChangeGameStatus(GameStatus gameStatus)
    {
        CurrentGameStatus = gameStatus;
    }

}
