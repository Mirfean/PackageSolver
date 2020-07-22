using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public GameObject Buttons;
    public Joystick joystick;
    Vector3 tempVect;
    float Touchy;

    float slower;
    int slowingCounter;

    // Start is called before the first frame update
    void Start()
    {
        speed = 200;
        Touchy = 0.01f;
        slowingCounter = 0;
        slower = 1f / Time.fixedDeltaTime;
    }


    public void Update()
    {
        MovingByJoystick01();
    }

    public void FixedUpdate()
    {
        //MovingByJoystick01();
    }


    //For WSAD
    private void MovingByWSAD()
    {
        if (IsPressingMoveWSAD())
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 tempVect = new Vector3(h, v, 0);
            tempVect = tempVect.normalized * speed * Time.deltaTime;
            rb.MovePosition(rb.transform.position + tempVect);
        }
        else
        {
            rb.MovePosition(rb.transform.position);
        }
    }
    //For WSAD
    private bool IsPressingMoveWSAD()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S)) return true;
        return false;
    }

    private void MovingByJumpingJoystick()
    {
        if (IsTouchingJoystick())
        {
            float h = joystick.Horizontal;
            float v = joystick.Vertical;
            if (h >= Touchy || h <= -Touchy || v >= Touchy || v <= -Touchy)
            {
                tempVect = new Vector3(h, v, 0);
                tempVect = SetCurrentMove();
                //rb.MovePosition(rb.transform.position + tempVect);
                rb.velocity = tempVect;
            }

        }
        else
        {
            //rb.MovePosition(rb.transform.position);
            rb.velocity = new Vector3(0, 0, 0);
        }
    }

    private void MovingByJoystick02()
    {
        if (IsTouchingJoystick())
        {
            float h = joystick.Horizontal;
            float v = joystick.Vertical;
            if (h >= 0.25 || h <= -0.25 || v >= 0.25 || v <= -0.25)
                tempVect = new Vector3(h, v, 0);
            tempVect = SetCurrentMove();
            rb.MovePosition(rb.transform.position + tempVect);
        }
        else
        {
            rb.MovePosition(rb.transform.position);
        }
    }

    //For Joystick
    private void MovingByJoystick01()
    {
        if (IsTouchingJoystick())
        {
            float h = joystick.Horizontal;
            float v = joystick.Vertical;
            if(h >= Touchy || h <= -Touchy || v >= Touchy || v <= -Touchy)
            {
                tempVect = new Vector3(h, v, 0);
                tempVect = SetCurrentMove();
                //rb.MovePosition(rb.transform.position + tempVect);
                rb.velocity = tempVect;
                //rb.AddForce(tempVect*speed);
            }
            
        }
        else
        {
            //rb.MovePosition(rb.transform.position);
            rb.velocity = rb.velocity * 0.8f;
            slowingCounter++;
            if(slowingCounter >= slower) { rb.velocity = new Vector3(0, 0, 0); slowingCounter = 0; }

        }
    }

    //For Joystick
    private bool IsTouchingJoystick()
    {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0) return true;
        return false;
    }

    public Vector3 SetCurrentMove()
    {
        return tempVect.normalized * speed * Time.deltaTime;
    }


}
