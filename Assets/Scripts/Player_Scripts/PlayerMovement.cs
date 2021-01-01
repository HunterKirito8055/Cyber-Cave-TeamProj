using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ComboSystem
{
    None,
    Attack1,
    Attack2,
    Attack3
};
public class PlayerMovement : MonoBehaviour
{
    public PlayerAttack playerattack;
    public float movespeed = 5f;
    public float JumpPower = 5f;
    // public float dashtime = 100f;
    public GameObject hitobj;

    private bool IsGrounded;
    // bool _facingRight = true;

    private Rigidbody2D rbody;
    private Animator anim;


    //DashVariables

    public float dashSpeed = 15f;
    private bool isdashing;
    public float startDashtime = 0.25f;
    float currentDashtime;


    public bool Attacking;
    
    //Combo Variables
    private ComboSystem Current_ComboState;
    public float Default_Combo_Timer = 0.6f;
    private float Current_Combo_Timer;
    bool combo_reset;


    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerattack = GetComponentInChildren<PlayerAttack>();

    }
    private void Start()
    {
        Current_ComboState = ComboSystem.None;
        Current_Combo_Timer = Default_Combo_Timer;
        
    }

    void FixedUpdate()
    {
        if(IsGrounded)
        dash();
    }

    private void Update()
    {
        Jump();
        Walk();
        ComboAttack();
        ComboUI();
        ResetCombo();
        

    }
    void ComboAttack()
    {

        if (Input.GetMouseButtonDown(0))
        {
            
            if (Current_ComboState == ComboSystem.Attack3)
                return;
            Attacking = true;
            rbody.velocity = new Vector2(0f, rbody.velocity.y); //player should stop moving while attacking
            Current_ComboState++;
            combo_reset = true;
            if (Current_ComboState == ComboSystem.Attack1)
            {
                anim.SetTrigger("PlayerAttack1");
              //  hitobj.SetActive(true);
            }
            if (Current_ComboState == ComboSystem.Attack2)
            {
                anim.SetTrigger("PlayerAttack2");
              //  hitobj.SetActive(true);

            }
            if (Current_ComboState == ComboSystem.Attack3)
            {
                anim.SetTrigger("PlayerAttack3");
              //  hitobj.SetActive(true);
            }

        }
    }

    private void ResetCombo()
    {
        if (combo_reset)
        {
            Current_Combo_Timer -= Time.deltaTime;
            if (Current_Combo_Timer <= 0f)
            {
                Current_Combo_Timer = Default_Combo_Timer;
                Current_ComboState = ComboSystem.None;
                combo_reset = false;
                Attacking = false;
            }

        }






    }

    //PlayerWalk
    void Walk()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if (h != 0)
        {

            if (!Attacking)
            {
                if (h > 0)
                {
                    rbody.velocity = new Vector2(movespeed, rbody.velocity.y); //move front  
                    Flip(gameObject, h); //changedirection  
                }
                else if (h < 0)
                {

                    rbody.velocity = new Vector2(-movespeed, rbody.velocity.y); //move back
                    Flip(gameObject, h); //changedirection    
                }

            }

        }
        else
        {
            rbody.velocity = new Vector2(0f, rbody.velocity.y);
        }
        anim.SetInteger("Speed", Mathf.Abs((int)rbody.velocity.x));



    }

    //which direction the player is facing
    public void Flip(GameObject go, float dir)
    {
      
        Quaternion rot = go.transform.rotation;
        if (dir < 0)
        {
            rot.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (dir > 0)
        {
            rot.eulerAngles = new Vector3(0, 0, 0);
        }
        go.transform.rotation = rot;
    }
    bool isJump;
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

            if (h > 0 || h < 0)
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
  
    public void HitObjectOn()
    {
        hitobj.SetActive(true);
        print("hit");
    }
    public void HitObjectOff()
    {
        print("off");
        hitobj.SetActive(false);
    }
    //Combo UI 
    #region Combo Attack 

    public Text Combohit;
    public GameObject ComboObj;
    public float combo_attack_ResetTimer;
    public int combohits = 0;
    
    public float _Defaultcombo_attack_ResetTimer = 0.6f;

    public bool ComboHasToReset;
 

    void ComboUI()
    {

        if (combohits > 0) //combogameobject should be active if the combo is greater than 0
        {
            ComboObj.SetActive(true);
        }

        if (ComboHasToReset) //UICombo has to reset and disappear
        {

            combo_attack_ResetTimer -= Time.deltaTime;
            if (combo_attack_ResetTimer <= 0f)
            {
                ComboHasToReset = false;
                ComboObj.SetActive(false);
                combohits = 0;
                combo_attack_ResetTimer = _Defaultcombo_attack_ResetTimer;
            }
        }
        if (gameObject.CompareTag("Enemy"))
        {
            print("ashish");
        }
        Combohit.text = combohits.ToString();
    }

    #endregion
}
