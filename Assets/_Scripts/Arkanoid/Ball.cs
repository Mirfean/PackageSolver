using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Configuration
    [SerializeField] Paddle playerPaddle;

    // state
    Vector2 paddleToBallVector;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - playerPaddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        LockBallToPaddle();
        //LaunchBall();
    }

    private void LaunchBall()
    {
        throw new NotImplementedException();
    }

    void LockBallToPaddle()
    {
        Vector2 paddlePosition = new Vector2(playerPaddle.transform.position.x, playerPaddle.transform.position.y);
        transform.position = paddleToBallVector + paddlePosition;
    }


}
