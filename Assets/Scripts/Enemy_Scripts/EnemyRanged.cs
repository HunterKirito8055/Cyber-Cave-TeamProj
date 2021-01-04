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
    private float timeBtwnShots;

    public GameObject bulletSlot;
    public Transform bulletSpawnPosition;
    public Transform SpawnRotation;
    //public float bulletSpeed;
    public Transform player;
    public Animator anim;
    Vector2 directionForBullet;
    float angle;

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
            RotateBullet();
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

            Shoot();
            timeBtwnShots = startTimeBtwnShots;
        }
    }
    void RotateBullet()
    {
        directionForBullet = player.position - transform.position; 
        angle = Mathf.Atan2(directionForBullet.y, directionForBullet.x) * Mathf.Rad2Deg;
        SpawnRotation.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Shoot()
    {
        Instantiate(bulletSlot, bulletSpawnPosition.position, bulletSpawnPosition.rotation);
    }
    public void ImpactShot()
    {
        anim.SetTrigger("Impact");
    }
}//class
