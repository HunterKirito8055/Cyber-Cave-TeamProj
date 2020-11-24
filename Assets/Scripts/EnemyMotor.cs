using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMotor : MonoBehaviour
{
    PlayerMovement playmovementScript;
    public float MoveSpeed = 2f;

    [Range(0, 15)]
    public float OffsetToRight = 5f, OffsetToLeft = 5f;
    float currentPosition, LeftMaxPos, RightMaxPos;

    // public GameObject AirPos1, AirPos2, AirPos3; //from where rockets are fired from enemy
    public GameObject Hands;
    Animator anim;

    public bool isMoveRight = true;
    Rigidbody2D rigid;
    bool isOnGround;


    public Transform playerTarget;

    public float attack_Distance = 1.5f, chase_distance;
    float chase_Player_After_Attack = 1f, current_Attack_Time, default_Attack_Time = 2f;
    [SerializeField]
    bool _isfollowPlayer, _attackPlayer; //if player is in enemy range, then chase after him


    public Transform GroundDetect;
    public LayerMask GroundLayer;


    public enum Enemy_Attack
    {
        None,
        Melee1,
        Melee2,
        Melee3,
        AirRocks
    }//enum enemy
    private void OnEnable()
    {

    }
    private void Awake()
    {

        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        playmovementScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;

        //Below are The Clamping technique used
        currentPosition = transform.position.x;
        LeftMaxPos = transform.position.x - OffsetToLeft;
        RightMaxPos = transform.position.x + OffsetToRight;
        rigid.velocity = new Vector2(MoveSpeed, rigid.velocity.y);
        
        _isfollowPlayer = false;

        Debug.Log(LeftMaxPos);
        Debug.Log(RightMaxPos);

    }
    void Update()
    {
        Vector2 playPos = playerTarget.position;
        CheckGround();

        IsAlive();
    }

    void CheckGround()
    {
        isOnGround = Physics2D.Raycast(GroundDetect.position, Vector2.down, 1.4f, GroundLayer);

        if (isOnGround)
        {
            FollowPlayer();
            isOnGround = true;

            // Debug.Log("on ground");
        }
        else
        {
            isOnGround = false;
            // Debug.Log("Not onground"); ;
            rigid.velocity = new Vector2(0, 0);
        }

    }
    void Patrol()
    {
        if (isMoveRight) //ismove right true, moving enemy to right
        {
            rigid.velocity = new Vector2(MoveSpeed, rigid.velocity.y);
            if (rigid.position.x > RightMaxPos)
            {
                isMoveRight = false; //to change direction the enemy's moving
                playmovementScript.Flip(gameObject, -1);
            }
        }
        else if (!isMoveRight)//moving left
        {
            rigid.velocity = new Vector2(-MoveSpeed, rigid.velocity.y);
            if (rigid.position.x < LeftMaxPos)
            {
                isMoveRight = true;
                playmovementScript.Flip(gameObject, 1);
            }
        }

        if (playerTarget.position.x > LeftMaxPos - 3f && playerTarget.position.x < RightMaxPos + 3f)
        {
            _isfollowPlayer = true;
        }
        else
        {
            _isfollowPlayer = false;
        }

    }//patrol

    void FollowPlayer()
    {
        chase_distance = Vector2.Distance(playerTarget.position, transform.position);
        print("chase dis");
        Debug.Log(chase_distance);
        
        if (!_isfollowPlayer) //if not following the player, then what to do here?
        {
            Patrol();
        }
        
        if (_isfollowPlayer)
        {
            if (chase_distance < Random.Range(LeftMaxPos - 3f, RightMaxPos + 3f))
            {
                if (playerTarget.position.x > transform.position.x + attack_Distance)
                {
                    playmovementScript.Flip(gameObject, 1);
                    rigid.velocity = Vector2.right * MoveSpeed;
                }
                else if( playerTarget.position.x < transform.position.x -attack_Distance)
                {                 
                    playmovementScript.Flip(gameObject, -1);
                    rigid.velocity = -Vector2.right * MoveSpeed;
                }
                else if(chase_distance < attack_Distance)
                {
                    rigid.velocity = new Vector2(0, rigid.velocity.y);
                }
            }
            if(chase_distance > (RightMaxPos - LeftMaxPos) + 3)
            {
                _isfollowPlayer = false;
                LeftMaxPos = transform.position.x - OffsetToLeft;
                RightMaxPos = transform.position.x + OffsetToRight;

            }
        }

    }//follow player

    void IsAlive()
    {

    }

}//class
