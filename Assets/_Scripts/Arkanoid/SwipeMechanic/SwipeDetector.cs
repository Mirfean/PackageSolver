using System;
using UnityEngine;
using Assets._Scripts.Enums;
using Assets._Scripts.General;

public class SwipeDetector : MonoBehaviour
{
    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;

    [SerializeField]
    private readonly bool detectSwipeOnlyAfterRelease = false;

    [SerializeField]
    private readonly float minDistanceForSwipe = 20f;

    public static event Action<SwipeData> OnSwipe = delegate { };

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUpPosition = touch.position;
                fingerDownPosition = touch.position;
            }
            /* Not sure if this is nesesary
            if (!detectSwipeOnlyAfterRelease && touch.phase == TouchPhase.Moved)
            {
                fingerDownPosition = touch.position;
                DetectSwipe();
            }
            */
            if (touch.phase == TouchPhase.Ended)
            {
                fingerDownPosition = touch.position;
                //DetectSwipe();
                SendSwipe(BaseMethodsAndroid.DetectSwipeDirection(fingerDownPosition, fingerUpPosition));
                fingerUpPosition = fingerDownPosition;
            }
        }
    }

    private void SendSwipe(SwipeDirection direction)
    {
        SwipeData swipeData = new SwipeData()
        {
            Direction = direction,
            StartPosition = fingerDownPosition,
            EndPosition = fingerUpPosition
        };
        OnSwipe(swipeData);
    }
}

public struct SwipeData
{
    public Vector2 StartPosition;
    public Vector2 EndPosition;
    public SwipeDirection Direction;
}