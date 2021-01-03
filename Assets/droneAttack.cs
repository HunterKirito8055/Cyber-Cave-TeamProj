using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droneAttack : MonoBehaviour
{
    Collider2D playerCollider;

    public void Start()
    {
        Invoke("OnTriggerEnter2D", 2f);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerCollider = collision;
            Attack();
        }

    }

    void Attack()
    {
        playerCollider.gameObject.GetComponent<scoreMgmt>().OnTriggerEnter2D(gameObject.GetComponent<Collider2D>());

    }


    //Collider2D c;

    //void Update()
    //{
    //    c = Physics2D.OverlapCircle(new Vector2(0,0), 50);
    //    Debug.Log(c.gameObject.tag);
    //    if(c.gameObject.tag=="Player")
    //    {
    //        electricify();
    //    }

    //}
    //void electricify()
    //{
    //    Debug.Log("Electricify"); 
    //    if(c.gameObject.tag=="Player")
    //    {
    //        c.GetComponent<scoreMgmt>().OnTriggerEnter2D(gameObject.GetComponent<Collider2D>());
    //    }
    //}
}
