using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets._Scripts.Enums;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour, Button_
{
    public ButtonFunction buttonFunction;
     
    //public List<string> sceneHistory = new List<string>();

    // Use this for initialization
    void Start()
    {
        //Change it later!
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TaskButton(string lastScene, string currentScene)
    {
        
        
    }

    /// <summary>
    /// 
    /// </summary>
    public void TaskButton()
    {
        switch (buttonFunction)
        {
            case ButtonFunction.Play:
                {
                    //Change it later!
                    //sceneHistory.Add(SceneManager.GetActiveScene().name);
                    SceneManager.LoadScene("Levels");
                }
                break;
            case ButtonFunction.Options:
                {

                }
                break;
            case ButtonFunction.Back:
                {
                    //SceneManager.LoadScene(sceneHistory.Last<string>());
                    SceneManager.LoadScene(CurrentGameData.lastScene);
                }
                break;
            default:
                {

                }
                break;
        }
    }
}
