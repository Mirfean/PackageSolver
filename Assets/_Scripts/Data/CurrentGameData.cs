using Assets._Scripts.Data;
using System;
using System.Collections.Generic;
using UnityEngine;

//Contain all current data from and into SAVE(not only)
public static class CurrentGameData
{
    //For current session
    public static Level level;

    public static string _lastScene;
    public static string _currentScene;

    public static string lastScene
    {
        get
        {
            return _lastScene;
        }
        set
        {
            Debug.Log($"trying change lastScene to {value} ");
            if (!String.IsNullOrEmpty(value))
            {
                _lastScene = value;
            }
        }
    }

    public static string currentScene
    {
        get
        {
            return _currentScene;
        }
        set
        {
            Debug.Log($"trying change currentScene to {value} ");
            if (!String.IsNullOrEmpty(value))
            {
                _currentScene = value;
            }
        }
    }

    //Store in .elo
    public static bool SoundOn;

    public static HashSet<int> UnlockedLevels;


    static CurrentGameData()
    {
        SoundOn = false;
        UnlockedLevels = new HashSet<int>();
        // ???
        UnlockedLevels.Add(1);
    }

    public static void UnlockLevel(int levelNumber)
    {
        UnlockedLevels.Add(levelNumber);
        SaveSystem.SavePlayer();
    }

    public static void UnlockLevel()
    {
        UnlockedLevels.Add(level.levelNumber);
        SaveSystem.SavePlayer();
    }

    public static void UnlockNextLevel()
    {
        //UnlockedLevels.Add();
        SaveSystem.SavePlayer(level.levelNumber+1);
    }
}