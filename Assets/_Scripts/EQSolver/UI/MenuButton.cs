using Assets._Scripts.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour, IButton
{
    public ButtonFunction buttonFunction;

    //public List<string> sceneHistory = new List<string>();

    // Use this for initialization
    private void Start()
    {
        //Change it later!
    }

    // Update is called once per frame
    private void Update()
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
                    PlayerPrefs.SetInt("LastScene", SceneManager.GetActiveScene().buildIndex);
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
                    SceneManager.LoadScene(PlayerPrefs.GetInt("LastScene"));
                }
                break;

            default:
                {
                }
                break;
        }
    }
}