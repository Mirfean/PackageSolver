using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

//To save necessary stuff to binary file
public static class SaveSystem
{
    static string path = Application.persistentDataPath + "/save.elo";
    static PlayerData playerData;

    public static void SavePlayer()
    {
        Debug.Log("Saving progress");
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        Debug.Log("Number of unlocked levels" + playerData.UnlockedLevels.Count);
        formatter.Serialize(stream, playerData);
        stream.Close();
    }

    public static void SavePlayer(int unlockedlvl)
    {
        Debug.Log("Saving progress");
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        playerData.UnlockedLevels.Add(unlockedlvl);
        Debug.Log("Number of unlocked levels" + playerData.UnlockedLevels.Count);
        foreach(int x in playerData.UnlockedLevels)
        {
            Debug.Log($"UL: {x}");
        }
        formatter.Serialize(stream, playerData);
        stream.Close();
    }


    public static void CreateNewSave()
    {
        Debug.Log("Creating new save file");
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData();
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void LoadPlayer()
    {
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            foreach (var x in data.UnlockedLevels)
            {
                Debug.Log("Unlocked levels" + x);
            }
            stream.Close();
            playerData = data;
        }
        else
        {
            Debug.LogWarning("Save not found :(");
            CreateNewSave();
            LoadPlayer();
        }
    }

    public static HashSet<int> GetLevelsFromPlayerData()
    {
        return playerData.UnlockedLevels;
    }

}
