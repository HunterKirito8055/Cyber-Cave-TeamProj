using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public Transform player;
    public Transform enemy;
    public float bulletSpeed;
    Vector2 direction;
    Vector3 rotationDirection;
    float radians, angle;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = GameObject.FindGameObjectWithTag("EnemySniper").transform;
        direction = player.position - enemy.position;
        radians = Mathf.Atan2(player.position.y - enemy.position.y, player.position.x- enemy.position.x);
        angle = radians * (180 / Mathf.PI);
        print(angle);
       // transform.RotateAround(transform.position, Vector3.forward, angle);
     //  gameObject.transform.RotateAroundLocal(Vector3.forward, angle);
        transform.RotateAround(Vector3.forward, angle);
    }

   
    private void Update()
    {
     
       
        // transform.position = enemy.position;
        //bullet.position = hero.position; 
        //bullet.delta = enemy.position - hero.position; 

        //normalize(delta); 

        //bullet.delta *= speed;
     
        //update.bullet.position += bullet.delta * frametimedelta;
        Vector2 playpos = player.transform.position;
       // transform.position = Vector2.MoveTowards(transform.position,playpos, bulletSpeed * Time.deltaTime);
       transform.Translate(direction * bulletSpeed * Time.deltaTime);
      //  print(player.position);
    }


}//class



