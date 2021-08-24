using Assets._Scripts.Levels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSpawner : MonoBehaviour
{
    XmlTest xmlTest;
    string pathOfPrefab;

    // Start is called before the first frame update
    void Start()
    {
        string prefabName = "PuzzleDuck";
        xmlTest = new XmlTest();
        //pathOfPrefab = Application.dataPath + "/EQSolver/";

        //GameObject _go = Resources.Load("EQSolver/PuzzleDuck") as GameObject;

        Debug.Log(pathOfPrefab + prefabName);

        _ = Instantiate(Resources.Load("EQSolver/PuzzleLine2")) as GameObject;




        /*foreach (prefabName in playerOwnPrefabNames)
        {
            var prefabName = playerOwnPrefabNames;
            var prefabInstance = Instantiate(Resources.Load(pathOfPrefab + prefabName)) as GameObject;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
