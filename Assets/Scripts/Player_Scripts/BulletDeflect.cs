using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDeflect : MonoBehaviour
{
    Rigidbody2D rb;
    Vector3 lastvel;
    CircleCollider2D cc2d;
    CapsuleCollider2D capsuleC2dd;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cc2d = GetComponent<CircleCollider2D>();
        capsuleC2dd = GetComponent<CapsuleCollider2D>();
    }
    private void Start()
    {
        if (cc2d.isTrigger.Equals(false))
        {
            //cc2d.isTrigger = true;
        }
    }
    private void Update()
    {
        lastvel = rb.velocity;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Deflection")
        {
            Debug.Log(collision.gameObject.tag);
            cc2d.isTrigger = false;
            capsuleC2dd.isTrigger = false;
            var speed = lastvel.magnitude;
            var direction = Vector3.Reflect(lastvel.normalized, collision.contacts[0].normal);
            rb.velocity = direction * Mathf.Max(speed, 0f);

        }
        else
        {
            cc2d.isTrigger = true;
            capsuleC2dd.isTrigger = true;
        }
    }
}
