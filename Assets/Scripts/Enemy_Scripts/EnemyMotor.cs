using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMotor : MonoBehaviour
{
    PlayerMovement playmovementScript;
    public float MoveSpeed = 2f;


    [Range(0, 15)]
    public float OffsetToRight = 5f, OffsetToLeft = 5f, downMinPos = 1f, upMaxPos = 2f;
    float currentPosition, LeftMaxPos, RightMaxPos;

    // public GameObject AirPos1, AirPos2, AirPos3; //from where rockets are fired from enemy

    Animator anim;

    public bool isMoveRight = true;
    Rigidbody2D rigid;
    bool isOnGround;


    public Transform playerTarget;

    public float attack_Distance = 1.5f, chase_distance;
    //  float chase_Player_After_Attack = 1f, current_Attack_Time, default_Attack_Time = 2f;


    [SerializeField]
    bool _isfollowPlayer = false; //if player is in enemy range, then chase after him


    public Transform GroundDetect;
    public LayerMask GroundLayer;
    float yPos;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        playmovementScript = FindObjectOfType<PlayerMovement>();
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        //Below are The Clamping technique used
        currentPosition = transform.position.x;
        LeftMaxPos = transform.position.x - OffsetToLeft;
        RightMaxPos = transform.position.x + OffsetToRight;
        rigid.velocity = new Vector2(MoveSpeed, rigid.velocity.y);

        _isfollowPlayer = false;
        yPos = transform.position.y;
        
        //Debug.Log(LeftMaxPos);
        //Debug.Log(RightMaxPos);

    }
    void Update()
    {
        transform.position = new Vector2(transform.position.x, yPos);
        CheckGround();

        IsAlive();
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
       
    }

    void CheckGround()
    {
        isOnGround = Physics2D.Raycast(GroundDetect.position, Vector2.down, 1.4f, GroundLayer);

        if (isOnGround)
        {
            CheckisInRangeOrNot();
        }
        else
        {
           // isOnGround = false;
             Debug.Log("Not onground"); ;
            rigid.velocity = new Vector2(0, 0);
        }

    }
    void Patrol()
    {
        print("in patrol");
        MoveSpeed = 2f;
        if (isMoveRight) //ismove right true, moving enemy to right
        {
            rigid.velocity = new Vector2(MoveSpeed, rigid.velocity.y);
            if (rigid.position.x > RightMaxPos)
            {
                print("right over");
                isMoveRight = false; //to change direction the enemy's moving
                playmovementScript.Flip(gameObject, 1);
            }
            
        }
        else //moving left
        {
            rigid.velocity = new Vector2(-MoveSpeed, rigid.velocity.y);
            if (rigid.position.x < LeftMaxPos)
            {
                print("left over");
                isMoveRight = true;
                playmovementScript.Flip(gameObject, -1);
            }
            
        }
        anim.SetInteger("Speed", Mathf.Abs((int)rigid.velocity.x));
        if (distanceFromPlayer > stopBeforePlayerDist && distanceFromPlayer < inRangeDist)
        {
            _isfollowPlayer = true;
        }

        //if player is in Range from Left to right and
        // player is in Range of height from Up and Ddown
        //if (playerTarget.position.x > LeftMaxPos - 3f && playerTarget.position.x < RightMaxPos + 3f && playerTarget.position.y < Random.Range(transform.position.y - downMinPos, transform.position.y + upMaxPos))
        //{
        //    _isfollowPlayer = true;
        //}
        //else
        //{

        //    _isfollowPlayer = false;
        //    LeftMaxPos = transform.position.x - OffsetToLeft;
        //    RightMaxPos = transform.position.x + OffsetToRight;
        //}
        anim.SetInteger("Speed", Mathf.Abs((int)rigid.velocity.x));
    }//patrol

    float distanceFromPlayer;
    public float stopBeforePlayerDist = 2f, inRangeDist = 9f, retreatFromPlayer =1.5f ;
    Vector2 directionSided;
    void ChasePlayerInRange()
    {
        #region chase and attack coded mk.1 
        /*  // Previos Script. Mk.1
        MoveSpeed = 5f;
        chase_distance = Vector2.Distance(playerTarget.position, transform.position);
        //print("chase dis");
        //    Debug.Log(chase_distance);

        if (!_isfollowPlayer) //if not following the player, then what to do here?
        {
            Patrol();
        }

        if (_isfollowPlayer)
        {
            if (chase_distance < Random.Range(LeftMaxPos + 3f, RightMaxPos + 3f))
            {
                #region checking for height so that enemy should not follow player if he is at above some height
                float playerPos_Y = playerTarget.position.y, enemyPos_Y = transform.position.y;
                //if (Mathf.Abs(playerTarget.position.y - transform.position.y + 0.5f) < 2f)
                //{

                if (playerTarget.position.x > transform.position.x + attack_Distance)
                {
                    playmovementScript.Flip(gameObject, -1);
                    rigid.velocity = Vector2.right * MoveSpeed;
                }
                else if (playerTarget.position.x < transform.position.x - attack_Distance)
                {
                    playmovementScript.Flip(gameObject, 1);
                    rigid.velocity = -Vector2.right * MoveSpeed;
                }
                else if (chase_distance < attack_Distance)
                {
                    //stops right in front of player to attack
                    rigid.velocity = new Vector2(0, rigid.velocity.y);
                    //attack the player
                    _attackPlayer = true;
                    EnemyAttackMelee();
                    //////
                }
                //}//checking for Y-Height, as we dont want enemy to chase even if player is at some height
                #endregion 
            }
            if (chase_distance > (RightMaxPos - LeftMaxPos) + 3) 
            {
                _isfollowPlayer = false;
                LeftMaxPos = transform.position.x - OffsetToLeft;
                RightMaxPos = transform.position.x + OffsetToRight;

            }
        }*/
        #endregion

        #region Chase and attack Mk.2 on 24-12-2020

        distanceFromPlayer = Vector2.Distance(playerTarget.position, transform.position);
        Vector2 currentpos = transform.position;
        directionSided = playerTarget.position - transform.position;
        
        if (_isfollowPlayer)
     {
            if (distanceFromPlayer > stopBeforePlayerDist && distanceFromPlayer < inRangeDist)//move closer to player
            {
                //   rigid.velocity = new Vector2(rigid.velocity.x, 0);
                
                transform.position = Vector2.MoveTowards(currentpos, playerTarget.position, MoveSpeed * Time.deltaTime);
                anim.SetInteger("Speed", Mathf.Abs((int)rigid.velocity.x));
                anim.Play("Walk");
            }
        
            else if (distanceFromPlayer < stopBeforePlayerDist && distanceFromPlayer > retreatFromPlayer /*|| distanceFromPlayer > inRangeDist*/)
            {
                //stopping position
                rigid.velocity = new Vector2(0, 0);
                if (rigid.velocity.x == 0)
                    EnemyAttackMelee();
            }
            else if (distanceFromPlayer < retreatFromPlayer) // move away from player
            {
                transform.position = Vector2.MoveTowards(currentpos, playerTarget.position, -MoveSpeed * Time.deltaTime);
                anim.SetInteger("Speed", Mathf.Abs((int)rigid.velocity.x));
                anim.Play("EnemyWalk");
            }
           

        }

      playmovementScript.Flip(gameObject, -directionSided.x);
        
      //  print(directionSided);
        #endregion

    }//follow player
    void CheckisInRangeOrNot()
    {
        distanceFromPlayer = Vector2.Distance(playerTarget.position, transform.position);
        if (distanceFromPlayer > inRangeDist)
        {
            _isfollowPlayer = false;
            Patrol();
            //LeftMaxPos = transform.position.x - OffsetToLeft;
            //RightMaxPos = transform.position.x + OffsetToRight;
        }
        else if (distanceFromPlayer < inRangeDist + (transform.rotation.y ==0?RightMaxPos:LeftMaxPos))
        { 
            _isfollowPlayer = true;
            ChasePlayerInRange();
        }
    }
    void IsAlive()
    {

    }
    void EnemyAttackMelee()
    {
        print("attack");
        if (rigid.velocity.sqrMagnitude == 0)
        {
            anim.SetTrigger("EnemyMelee");
        }
       
    }//melee attack enemy'
    public GameObject sword;
    public void SwordOn()
    {
        sword.SetActive(true);
    } public void SwordOff()
    {
        sword.SetActive(false);
    }
}//class
