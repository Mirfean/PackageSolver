
/* Unmerged change from project 'Scripts.Player'
Before:
using UnityEngine;
After:
using System;
*/
using System.Collections.Generic;
/* Unmerged change from project 'Scripts.Player'
Before:
using UnityEngine.SceneManagement;
using System;
After:
using UnityEngine;
using UnityEngine.SceneManagement;
*/


//File between binary save and code
[System.Serializable]
public class PlayerData
{
    public bool SoundOn { get; set; }
    public HashSet<int> UnlockedLevels { get; set; }


    public PlayerData()
    {
        SoundOn = CurrentGameData.SoundOn;
        UnlockedLevels = CurrentGameData.UnlockedLevels;
        //UnlockedLevels.Add(2,false);
    }

}
