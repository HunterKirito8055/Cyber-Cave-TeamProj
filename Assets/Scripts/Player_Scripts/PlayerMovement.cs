using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed = 5f;
    public float JumpPower = 5f;
    public float dashtime;
   

    private bool IsGrounded ;
    
    private Rigidbody2D rbody;
    private Animator anim;


    //DashVariables

    public float dashSpeed;
    private bool isdashing;
    public float startDashtime;
    float currentDashtime;
    

   

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        Walk();
        dash();

    }

    private void Update()
    {
        
        Jump();
    }
   

    //PlayerWalk
    void Walk()
    {
       float h = Input.GetAxis("Horizontal");
        
        if (h > 0)
        {
            rbody.velocity = new Vector2(movespeed, rbody.velocity.y); //move front
            FaceDirection(1); //changedirection
            

        }
        else if(h < 0)
        {
            rbody.velocity = new Vector2(-movespeed, rbody.velocity.y); //move back
            FaceDirection(-1); //changedirection 
            
        }
        if(h == 0)
        {
            rbody.velocity = new Vector2(0f, rbody.velocity.y);
        }
        anim.SetInteger("Speed", Mathf.Abs((int)rbody.velocity.x));
    }

    //which direction the player is facing
    void FaceDirection(int face)
    {
        Vector2 dir = transform.localScale;
        dir.x = face;
        transform.localScale = dir;
    }

    // PlayerJump
    void Jump()
    {
        if (IsGrounded)
        {
            anim.SetBool("Jump", false); //player is on land

            if (Input.GetKeyDown(KeyCode.Space)) //player jump
            {
                IsGrounded = false; 
                rbody.velocity = new Vector2(rbody.velocity.x, JumpPower);
                anim.SetBool("Jump", true);
            }
        }
    }

    void dash()
    {
       float h = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.P))
        {

            
            currentDashtime = startDashtime;

            if(h>0 || h < 0)
            {
                isdashing = true;
                anim.SetBool("Dash", true);
            }
           

         }


        if (isdashing)
        {
            
            if (h > 0)
            {
               
                rbody.velocity = Vector2.right * dashSpeed;
                currentDashtime -= Time.deltaTime;
                if (currentDashtime <= 0)
                {
                    isdashing = false;
                    anim.SetBool("Dash", false);
                }
            }
            else if (h < 0)
            {
                
                rbody.velocity = Vector2.left * dashSpeed;
                

                currentDashtime -= Time.deltaTime;
                if (currentDashtime <= 0)
                {
                    isdashing = false;
                    anim.SetBool("Dash", false);
                }
            }
        }


               
    
    }

   

    
   


    //Player collision for Jump
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            IsGrounded = true;
        }
    }
}
