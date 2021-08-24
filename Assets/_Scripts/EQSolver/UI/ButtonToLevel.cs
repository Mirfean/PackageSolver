using Assets._Scripts.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonToLevel : MonoBehaviour, Button_
{
    public bool unlocked;
    public int level_id;
    public Level level;
    public Sprite spriteUnlocked;
    public Sprite spriteLocked;

    // Start is called before the first frame update
    void Start()
    {
        //Sprite change
        if (unlocked) { this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteUnlocked; }
        else { this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteLocked; }

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
