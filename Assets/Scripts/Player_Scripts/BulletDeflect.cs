using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDeflect : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 lastvel;
    CircleCollider2D cc2d;
    CapsuleCollider2D capsuleC2d;
    BoxCollider2D bc2d;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cc2d = GetComponent<CircleCollider2D>();
        capsuleC2d = GetComponent<CapsuleCollider2D>();
        bc2d = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
    }
    private void Update()
    {
        lastvel = rb.velocity;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Deflection")
        {
            Debug.Log(collision.gameObject.tag);
            cc2d.isTrigger = false;
            capsuleC2d.isTrigger = false;
            bc2d.isTrigger = false;
            var speed = lastvel.magnitude;
            var direction = Vector3.Reflect(new Vector2(1,1), collision.contacts[0].normal);
            rb.velocity = direction * Mathf.Max(speed, 0f);

        }
        else if(collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Ground")
        {
           
        }
    }
}
