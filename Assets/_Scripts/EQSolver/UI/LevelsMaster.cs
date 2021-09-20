using Assets._Scripts.Data;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Assets._Scripts.General.BaseMethodsAndroid;

/// <summary>
///
/// </summary>
public class LevelsMaster : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        CurrentGameData.currentScene = SceneManager.GetActiveScene().name;
        if (!LevelsDataFromXml.LevelsList.Any<Level>())
        {
            LevelsDataFromXml.LevelsList.Clear();
            Debug.Log("I will load levels...");
            LevelsDataFromXml.Load(Application.persistentDataPath + "/LevelList.xml");
            Debug.Log(LevelsInfo.ListOfLevels.Count() + " levels");
        }
    }

    /*
    void OnLevelWasLoaded()
    {
        Debug.Log("On level was loaded");
        Debug.Log(currentScene);
        if (currentScene != null)
        {
            lastScene = CurrentGameData.currentScene;
        }
        else
        {
            lastScene = SceneManager.GetActiveScene().name;
        }
        currentScene = SceneManager.GetActiveScene().name;

        //CurrentGameData.lastScene = lastScene;
        //CurrentGameData.currentScene = currentScene;
    }
    */

    private void Update()
    {
        if (Input.touchCount > 0 && (CheckTouchThisObjectByTagDeluxe("MenuButton") || CheckTouchThisObjectByTagDeluxe("LevelButton")))
        {
            Touch touch = Input.GetTouch(0);
            GameObject temp = GetObjectFromTouch();
            Button_ button = temp.GetComponent<Button_>();
            Debug.Log($"Touched {temp}");

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    {
                    }
                    break;

                case TouchPhase.Stationary:
                    {
                    }
                    break;

                case TouchPhase.Ended:
                    {
                        Debug.Log($"global last scene {CurrentGameData.lastScene} and global current scene {CurrentGameData.currentScene}");
                        button.TaskButton();
                    }
                    break;
            }
        }
    }

    public void ChangeLevel(string x)
    {
        SceneManager.LoadScene(x);
    }
}