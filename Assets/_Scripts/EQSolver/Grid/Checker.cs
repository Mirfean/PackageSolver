using Assets._Scripts.EQSolver;
using UnityEngine;
using static Assets._Scripts.General.BaseMethodsAndroid;

public class Checker : MonoBehaviour
{
    public FillStatus Status { get; private set; }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void CheckPuzzle()
    {
        if (CheckObjectAboveByTag(this.gameObject, PuzzleTag))
        {
            Debug.Log("On");
            Status = FillStatus.FULL;
        }
        else if (Status == FillStatus.FULL)
        {
            Debug.Log("Off");
            Status = FillStatus.EMPTY;
        }
    }

    private void Update()
    {
        //CheckPuzzle();
    }
}
