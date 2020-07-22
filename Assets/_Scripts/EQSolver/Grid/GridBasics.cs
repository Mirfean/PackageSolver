using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Assets._Scripts.General.BaseMethodsAndroid;
using static Assets._Scripts.General.BaseMethods;
using System;

public class GridBasics : MonoBehaviour
{

    public GameObject target;
    public GameObject Structure;
    Vector3 truePos;
    public float gridsize;

    public static string TargetName = "Target";
    public static string SpriteName = "Sprite";
    public static string PuzzleTag = "PuzzleElement";

    public GridSystem gridSystem;
    public PuzzleMaster puzzleMaster;

    float touchTimer;
    float timeToRotate;
    bool moveOfPuzzle;

    // Start is called before the first frame update
    void Start()
    {
        moveOfPuzzle = false;
        timeToRotate = 0.2f;
    }

    private void Update()
    {
        //else if(Input.GetTouch(0).phase)
        if (Input.touchCount > 0)
        {
            PuzzleMove();
        }
    }


    // Update is called once per frame
    void LateUpdate()
    {
        //truePos.x = Mathf.Floor(target.transform.position.x / gridsize) * gridsize;
        //truePos.y = Mathf.Floor(target.transform.position.y / gridsize) * gridsize;
        //structure.transform.position = truePos;
    }

    
    void PuzzleMove()
    {
        Touch touch = Input.GetTouch(0);
        

        // Handle finger movements based on TouchPhase
        switch (touch.phase)
        {
            //When a touch has first been detected, change the message and record the starting position
            case TouchPhase.Began:
                if (GetObjectFromTouch() != null)
                {
                    if (GetObjectFromTouch().tag == PuzzleTag)
                    {
                        Structure = GetObjectFromTouch();
                        Transform StructureParent = Structure.transform.parent;
                        target = GetChildByName(StructureParent, TargetName);
                        //StructureParent.GetComponent<SpriteMod>().ChangeRotation();
                        Structure.GetComponent<SpriteMod>().ChangeRotation();
                        touchTimer = Time.deltaTime;
                        moveOfPuzzle = false;
                        //structure = GetChildByName(GetObjectFromTouch().transform, SpriteName);
                    }
                }

                //Do more here

                break;

            //Determine if the touch is a moving touch
            case TouchPhase.Moved:
                // Determine direction by comparing the current touch position with the initial one
                if (Structure != null && target != null && touchTimer + timeToRotate > Time.deltaTime)
                {
                    target.transform.position = TouchPosToCameraPos(touch);
                    truePos.x = target.transform.position.x;
                    truePos.y = target.transform.position.y;
                    Structure.transform.position = truePos;
                    moveOfPuzzle = true;
                }
                break;

            case TouchPhase.Ended:
                // Report that the touch has ended when it ends

                if (Structure != null && target != null && moveOfPuzzle)
                {
                    target.transform.position = TouchPosToCameraPos(touch);

                    Debug.Log("Current " + truePos);

                    //truePos.x = Mathf.Floor(target.transform.position.x / gridsize) * gridsize;
                    //truePos.y = Mathf.Floor(target.transform.position.y / gridsize) * gridsize;

                    truePos = CorrectToGrid(truePos);

                    Debug.Log("After " + truePos);

                    Structure.transform.position = truePos;
                    touchTimer = 0f;
                }

                target = null;
                Structure = null;
                gridSystem.CheckAllGridAfterPuzzleMove();
                puzzleMaster.WinCondition();
                moveOfPuzzle = false;
                break;
        }


    }

    //Alternative way to Grid attach after touch ended
    Vector3 CorrectToGrid(Vector3 pos)
    {
        Vector3 temp = pos;
        temp.x -= (int)pos.x;
        temp.y -= (int)pos.y;

        temp.x = RoundingPuzzleToGrid(temp.x);
        temp.y = RoundingPuzzleToGrid(temp.y);

        pos.x = (int)pos.x + temp.x;
        pos.y = (int)pos.y + temp.y;

        return pos;
    }

    float RoundingPuzzleToGrid(float f)
    {
        if(Mathf.Abs(f) < gridsize / 2)
        {
            return 0;
        }
        else if(f < 0)
        {
            if (f <= -gridsize * 1.5)
            {
                return -2 * gridsize;
            }
            else return -gridsize;
        }
        else
        {
            if (f >= gridsize * 1.5)
            {
                return 2 * gridsize;
            }
            else return gridsize;
        }
    }

    

}
