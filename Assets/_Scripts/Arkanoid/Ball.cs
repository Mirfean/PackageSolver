using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets._Scripts.General;
using Assets._Scripts.Enums;

public class Ball : MonoBehaviour
{
    //Configuration
    [SerializeField] Paddle playerPaddle;

    public SwipeDetector swipeDetector;

    // state
    Vector2 paddleToBallVector;

    private void Awake()
    {
        SwipeDetector.OnSwipe += Ball_OnSwipe;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        paddleToBallVector = transform.position - playerPaddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameMasterArkanoid.CurrentGameStatus == GameStatus.BeforeStart || GameMasterArkanoid.CurrentGameStatus == GameStatus.Rerun)
        {
            LockBallToPaddle();
        }
        else if(GameMasterArkanoid.CurrentGameStatus == GameStatus.GameOver)
        {
            Destroy(this);
        }
        //LaunchBall();
    }

    private void LaunchBall()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 15f);
    }

    void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(playerPaddle.transform.position.x, playerPaddle.transform.position.y);
        transform.position = paddleToBallVector + paddlePosition;
    }

    private void Ball_OnSwipe(SwipeData data)
    {
        if(data.Direction == Assets._Scripts.Enums.SwipeDirection.Up)
        {
            Debug.Log("Lauching ball!!!");
            GameMasterArkanoid.ChangeGameStatus(GameStatus.InProgress);
            LaunchBall();
        }
    }
}
