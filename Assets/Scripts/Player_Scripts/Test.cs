using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    enum DashDirection
    {
        Left,
        Right,
        Up,
        Down,
        NoDirection
    }

    Rigidbody2D body;
    public float speed;
    public float dashSpeed;
    private DashDirection dashDirection;
    public float dashDuration;
    public float dashTimer;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        dashDirection = DashDirection.NoDirection;
    }

    void Update()
    {
       // body.velocity = Vector2.zero;
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    dashDirection = DashDirection.Down;
        //}
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    dashDirection = DashDirection.Up;
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    dashDirection = DashDirection.Left;
        //}
        if (Input.GetKeyDown(KeyCode.P))
        {
            dashDirection = DashDirection.Right;
        }
        if (dashDirection != DashDirection.NoDirection)
        {
            if (dashTimer >= dashDuration)
            {
                dashDirection = DashDirection.NoDirection;
                dashTimer = 0;
                body.velocity = Vector2.zero;
            }
            else
            {
                dashTimer += Time.deltaTime;
                //if (dashDirection == DashDirection.Left)
                //{
                //    body.velocity = Vector2.left * dashSpeed;
                //}

                if (dashDirection == DashDirection.Right)
                {
                    body.velocity = Vector2.right * dashSpeed;
                }

                //if (dashDirection == DashDirection.Up)
                //{
                //    body.velocity = Vector2.up * dashSpeed;
                //}
                //if (dashDirection == DashDirection.Down)
                //{
                //    body.velocity = Vector2.down * dashSpeed;
                //}



            }

        }

    }
}
