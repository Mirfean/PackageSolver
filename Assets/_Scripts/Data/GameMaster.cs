using Assets._Scripts.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets._Scripts.General.BaseMethodsAndroid;

//Start from main menu and stay for all game
public class GameMaster : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        LevelsMaster.Start();
        SaveSystem.LoadPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        Menu();
    }

    void Menu()
    {
        if (Input.touchCount > 0 && (CheckTouchThisObjectByTagDeluxe("MenuButton") || CheckTouchThisObjectByTagDeluxe("LevelButton")))
        {
            Touch touch = Input.GetTouch(0);
            GameObject current_button = GetObjectFromTouch();
            IButton button = current_button.GetComponent<IButton>();
            //Debug.Log($"Touched {current_button}");

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    {
                    }
                    break;

                case TouchPhase.Stationary:
                    {
                        //Add some effects
                    }
                    break;

                case TouchPhase.Ended:
                    {
                        Debug.Log($"global last scene {CurrentGameData.lastScene} and global current scene {CurrentGameData.currentScene}");
                        if (current_button.tag == "LevelButton")
                        {
                            CurrentGameData.level = LevelsInfo.ListOfLevels[current_button.GetComponent<ButtonToLevel>().level_id];
                            Debug.Log(CurrentGameData.level.description);
                        }
                        button.TaskButton();
                    }
                    break;
            }
        }
    }

    void UnlockNextLevel()
    {
        CurrentGameData.UnlockNextLevel();
    }
}
