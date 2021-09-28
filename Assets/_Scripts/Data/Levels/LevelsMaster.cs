using Assets._Scripts.Data;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Assets._Scripts.General.BaseMethodsAndroid;

/// <summary>
///
/// </summary>
public static class LevelsMaster
{

    public static void Start()
    {
        if (!LevelsDataFromXml.LevelsList.Any<Level>())
        {
            LevelsDataFromXml.LevelsList.Clear();
            Debug.Log("I will load levels...");
            LevelsDataFromXml.Load(Application.persistentDataPath + "/LevelList.xml");
            Debug.Log(LevelsInfo.ListOfLevels.Count() + " levels");
        }
    }

    public static void OnButtonPush()
    {
        
    }

    public static void ChangeLevel(string x)
    {
        SceneManager.LoadScene(x);
    }
}