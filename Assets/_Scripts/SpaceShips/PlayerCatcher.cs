using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCatcher : MonoBehaviour
{
    public Camera MainCamera;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    // Use this for initialization
    void Start()
    {
        MainCamera = Camera.main;
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        Debug.Log("ScreenBounds " + screenBounds);
        Debug.Log("Screen width height " + Screen.width + " " + Screen.height); 
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        //Debug.Log($"Clamp x -> {viewPos.x} ,{MainCamera.transform.position.x} + -{screenBounds.x} + {objectWidth},{MainCamera.transform.position.x} + {screenBounds.x} - {objectWidth}");
        viewPos.x = Mathf.Clamp(viewPos.x, MainCamera.transform.position.x + -1 * screenBounds.x + objectWidth, MainCamera.transform.position.x + screenBounds.x - objectWidth);

        //Debug.Log($"Clamp y ->  {viewPos.y} ,{MainCamera.transform.position.y} + -{screenBounds.y} + {objectHeight},{MainCamera.transform.position.y} + {screenBounds.y} - {objectHeight}");
        viewPos.y = Mathf.Clamp(viewPos.y, MainCamera.transform.position.y + -1 * screenBounds.y + objectHeight, MainCamera.transform.position.y + screenBounds.y - objectHeight);

        transform.position = viewPos;
    }

}
