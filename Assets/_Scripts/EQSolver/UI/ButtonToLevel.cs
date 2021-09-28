using Assets._Scripts.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 
/// 
/// </summary>
public class ButtonToLevel : MonoBehaviour, IButton
{
    public bool unlocked;
    public bool Unlocked
    {
        get
        {
            return unlocked;
        }
        set
        {
            unlocked = value;
            if (unlocked)
            {
                Debug.Log("unlocking " + level_id);
                this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteUnlocked;
                this.gameObject.GetComponent<BoxCollider>().enabled = true;
            }
            else
            {
                Debug.Log("Setting off nr " + level_id);
                this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteLocked;
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
    public int level_id;
    public Level level;
    public Sprite spriteUnlocked;
    public Sprite spriteLocked;

    // Start is called before the first frame update
    private void Start()
    {
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

    public void UnlockMe(bool value)
    {
        unlocked = value;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteUnlocked;
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}