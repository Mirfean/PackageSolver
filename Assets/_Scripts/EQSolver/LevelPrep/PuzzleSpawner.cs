using Assets._Scripts.Levels;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSpawner : MonoBehaviour
{
    [SerializeField]
    private float VerticalLimit;
    [SerializeField]
    private float HorizontalLimit;

    private LevelsDispacher xmlTest;
    private string pathOfPrefab;

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void SpawnPuzzles(List<string> puzzles)
    {
        foreach(string puzzle in puzzles)
        {
            Vector2 temp = new Vector2(transform.position.x + GenerateSpawnLocation(HorizontalLimit), transform.position.y + GenerateSpawnLocation(VerticalLimit));
            GameObject x = Instantiate(Resources.Load($"EQSolver/{puzzle}")) as GameObject;
            x.transform.position = temp;
        }
    }

    private float GenerateSpawnLocation(float value)
    {
        return Random.Range(-value, value);
    }


}