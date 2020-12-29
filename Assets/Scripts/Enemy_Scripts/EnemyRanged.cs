using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : MonoBehaviour
{
    [Space(15)]
    [Header("Stats")]
    [Space(20)]
    public float speed;
    public float stoppingDistance;
    public float rangedDistance;
    public float retreatDistance;
    public float startTimeBtwnShots;
    [SerializeField]
    private float timeBtwnShots;

    public GameObject bulletSlot;
    //public float bulletSpeed;
    public Transform player;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwnShots = startTimeBtwnShots;
    }

    private void Update()
    {
        //if (Vector2.Distance(transform.position, player.position) > stoppingDistance && Vector2.Distance(transform.position, player.position) < rangedDistance)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        //}
        //else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        //{
        //    transform.position = this.transform.position;
        //}
        //else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        //}

        if (Vector2.Distance(transform.position,player.position) < rangedDistance)
        {
            TimeToShoot();
            
        }
       
    }
    void TimeToShoot()
    {
        if (timeBtwnShots >0)
        {
            timeBtwnShots -= Time.deltaTime;
        }
        else
        {
            anim.SetTrigger("Shoot");
            Instantiate(bulletSlot, transform.position, Quaternion.identity);
           
            timeBtwnShots = startTimeBtwnShots;
        }
    }
  
}//class
