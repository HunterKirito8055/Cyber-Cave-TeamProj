using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed = 5f;
    public float JumpPower = 5f;
    // public float dashtime = 100f;


    private bool IsGrounded ;
    bool _facingRight = true;

    private Rigidbody2D rbody;
    private Animator anim;


    //DashVariables

    public float dashSpeed = 15f;
    private bool isdashing;
    public float startDashtime = 0.25f;
    float currentDashtime;
    

   
    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    void FixedUpdate()
    {
        Walk();
        dash();
    }

    private void Update()
    {
<<<<<<< Updated upstream
        Jump(); 
=======
        
        Jump();
       
>>>>>>> Stashed changes
    }
   

    //PlayerWalk
    void Walk()
    {
       float h = Input.GetAxisRaw("Horizontal");       
        if (h > 0 )
        {
            rbody.velocity = new Vector2(movespeed , rbody.velocity.y); //move front  
            Flip(h); //changedirection  
        }
        else if(h < 0 )
        {
            rbody.velocity = new Vector2(-movespeed , rbody.velocity.y); //move back
            Flip(h); //changedirection    
        }
       else 
        {
            rbody.velocity = new Vector2(0f, rbody.velocity.y);
        }
        anim.SetInteger("Speed", Mathf.Abs((int)rbody.velocity.x));
    }

    //which direction the player is facing
    public void Flip( float dir)
    {
        Quaternion rot = transform.rotation;
        if (dir <0)
        {
            rot.eulerAngles = new Vector3(0, 180, 0);
        }
        else if(dir>0)
        {
            rot.eulerAngles = new Vector3(0, 0, 0);
        }
        transform.rotation = rot;
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

<<<<<<< Updated upstream
=======
     

    
   


>>>>>>> Stashed changes
    //Player collision for Jump
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            IsGrounded = true;
        }
    }
}
