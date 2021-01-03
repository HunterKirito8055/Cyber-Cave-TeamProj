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
    public float startTimeBtwnShots = 2f;
    [SerializeField]
    private float timeBtwnShots;

    public GameObject bulletPrefab;
    public Transform bulletPoint;
    public Transform bulletRotation;
    //public float bulletSpeed;
    public Transform player;
    public Animator anim;

    public Vector3 dirVector;
    public float angle;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwnShots = startTimeBtwnShots;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance && Vector2.Distance(transform.position, player.position) < rangedDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

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
            timeBtwnShots = startTimeBtwnShots;
            anim.SetTrigger("Shoot");
            Shoot();
            
        }
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
    }
    void RotateBullet()
    {
        dirVector = player.transform.position - bulletPoint.position;
        angle = Mathf.Atan2(dirVector.y, dirVector.x) * Mathf.Rad2Deg;
        bulletRotation.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(bulletPoint.transform.position, dirVector* 3f);
    }
    public void ImpactShot()
    {
        anim.SetTrigger("Impact");
    }
}//class
