using Assets._Scripts.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// 
/// </summary>
public class ButtonToLevel : MonoBehaviour, Button_
{
    public bool unlocked;
    public int level_id;
    public Level level;
    public Sprite spriteUnlocked;
    public Sprite spriteLocked;

    // Start is called before the first frame update
    private void Start()
    {
        //Sprite change
        if (unlocked)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteUnlocked;
            this.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteLocked;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }

        //Get level from loaded list
        GetLevelFromId();
    }

    public void TaskButton()
    {
        CurrentGameData.level = level;
        Debug.Log("Level to load " + level.levelNumber.ToString());
        SceneManager.LoadScene(level.levelType.ToString());
    }

    public void TaskButton(string x, string y)
    {
    }

    public void GetLevelFromId()
    {
        level = LevelsDataFromXml.GetLevelById(level_id);
    }
}