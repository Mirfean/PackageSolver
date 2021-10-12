using UnityEngine;
using static Assets._Scripts.General.BaseMethods;
using static Assets._Scripts.General.BaseMethodsAndroid;

public class MovingPuzzleOnGrid : MonoBehaviour
{
    public GameObject target;
    public GameObject Structure;
    public Vector3 relative_coords;
    private Vector3 truePos;
    public float gridsize;
    public float gridModif;
    [SerializeField] private Vector2 gridModif2;

    public GameObject Ghost;

    public static string TargetName = "Target";
    public static string SpriteName = "Sprite";
    public static string PuzzleTag = "PuzzleElement";

    public GridSystem gridSystem;
    public GameConditioner puzzleMaster;

    private float touchTimer;
    private float timeToRotate;
    private bool moveOfPuzzle;

    // Start is called before the first frame update
    private void Start()
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
    private void LateUpdate()
    {
        //truePos.x = Mathf.Floor(target.transform.position.x / gridsize) * gridsize;
        //truePos.y = Mathf.Floor(target.transform.position.y / gridsize) * gridsize;
        //structure.transform.position = truePos;
    }

    private void PuzzleMove()
    {
        Touch touch = Input.GetTouch(0);

        // Handle finger movements based on TouchPhase
        switch (touch.phase)
        {
            //When a touch has first been detected, change the message and record the starting position
            //Structure is Sprite(child of puzzle)
            case TouchPhase.Began:
                if (GetObjectFromTouch() != null)
                {
                    if (GetObjectFromTouch().tag == PuzzleTag)
                    {
                        Structure = GetObjectFromTouch();
                        relative_coords = Structure.transform.localPosition;
                        Transform StructureParent = Structure.transform.parent;
                        target = StructureParent.gameObject;

                        //Rotating puzzle
                        //First touch set True on doubleTap and second rotate
                        //Structure.GetComponentInChildren(typeof(SpriteMod)).GetComponent<SpriteMod>().ChangeRotation();
                        StructureParent.gameObject.GetComponent<SpriteMod>().ChangeRotation();

                        touchTimer = Time.deltaTime;
                        moveOfPuzzle = false;
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
                    if (!moveOfPuzzle)
                    {
                        Structure.transform.position = Structure.transform.position + new Vector3(0, 0, -1);
                        Structure.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
                        moveOfPuzzle = true;
                    }
                }
                break;

            case TouchPhase.Ended:
                // Report that the touch has ended when it ends

                if (Structure != null && target != null && moveOfPuzzle)
                {
                    target.transform.position = TouchPosToCameraPos(touch);

                    //truePos = CorrectToGrid(truePos);
                    //truePos = CorrectToGrid_OLD(truePos);
                    truePos = CorrectToGrid_NEW(truePos);

                    //Debug.Log("After " + truePos);
                    // Structure.transform.position = Structure.transform.position + new Vector3(0, 0, 1);
                    target.transform.position = truePos;
                    Structure.transform.localPosition = relative_coords;
                    Structure.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                    //Structure.transform.position = truePos;
                    touchTimer = 0f;
                }

                Destroy(Ghost);
                target = null;
                Structure = null;
                gridSystem.CheckAllGridAfterPuzzleMove();
                puzzleMaster.WinCondition();
                moveOfPuzzle = false;
                puzzleMaster.WinCondition();
                break;
        }
    }

    private void PuzzleGhosting(GameObject gameObjectToGhost)
    {
        Ghost.transform.position = CorrectToGrid(Structure.transform.position + new Vector3(0f, 0f, 1f));
    }

    //Alternative way to Grid attach after touch ended
    private Vector3 CorrectToGrid(Vector3 pos)
    {
        Debug.Log($" pos.x before {pos.x}");
        //pos.x = RoundToGridSupreme(gridsize, pos.x) + gridModif;
        pos.x = RoundValue(gridsize, pos.x) + gridModif2.x;
        Debug.Log($" pos.x after {pos.x}");
        Debug.Log($" pos.y after {pos.y}");
        pos.y = RoundValue(gridsize, pos.y) + gridModif2.y;
        //pos.y = RoundToGridSupreme(gridsize, pos.y) + gridModif;
        Debug.Log($" pos.y after {pos.y}");
        Debug.Log($"pos.x {pos.x} and pos.y {pos.y}");

        return pos;
    }

    private Vector3 CorrectToGrid_OLD(Vector3 pos)
    {
        Vector3 temp = pos;
        temp.x -= (int)pos.x;
        temp.y -= (int)pos.y;

        Debug.Log($" pos.x before {pos.x}");
        Debug.Log($" pos.y before {pos.y}");
        temp.x = RoundToGrid(gridsize, temp.x);
        temp.y = RoundToGrid(gridsize, temp.y);

        pos.x = (int)pos.x + temp.x;
        pos.y = (int)pos.y + temp.y;
        Debug.Log($" pos.x after {pos.x}");
        Debug.Log($" pos.y after {pos.y}");
        return pos;
    }

    private Vector3 CorrectToGrid_NEW(Vector3 pos)
    {
        Vector3 temp = pos;
        temp.x -= (int)pos.x;
        temp.y -= (int)pos.y;

        Debug.Log($" pos.x before {pos.x}");
        Debug.Log($" pos.y before {pos.y}");
        pos.x = RoundValue_NEW(gridsize, pos.x);
        pos.y = RoundValue_NEW(gridsize, pos.y);
        return pos;
    }
}