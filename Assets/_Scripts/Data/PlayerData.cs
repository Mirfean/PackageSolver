using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

//File between binary save and code
[System.Serializable]
public class PlayerData
{
    public bool SoundOn { get; set; }
    public Dictionary<int, bool> UnlockedLevels { get; set; }


    public PlayerData()
    {
        SoundOn = CurrentGameData.SoundOn;
        UnlockedLevels = CurrentGameData.UnlockedLevels;
        //UnlockedLevels.Add(2,false);
    }


    public void WyswietlDupe()
    {
        
    }

}
