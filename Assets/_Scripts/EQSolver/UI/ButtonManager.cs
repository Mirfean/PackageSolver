using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<ButtonToLevel> childs = new List<ButtonToLevel>();
        for (int x = 0; x< transform.childCount; x++)
        {
            childs.Add(transform.GetChild(x).GetComponent<ButtonToLevel>());
        }
        // Component[]
        foreach(ButtonToLevel button in childs)
        {
            if (SaveSystem.GetLevelsFromPlayerData().Contains(button.level_id))
            {
                button.Unlocked = true;
                //button.UnlockMe(true);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
