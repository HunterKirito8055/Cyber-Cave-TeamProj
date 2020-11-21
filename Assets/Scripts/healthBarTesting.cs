using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBarTesting : MonoBehaviour
{
    private healthBar hb;
    public float attackStrength = 0.2f;

    public void Start()
    {
        hb = GameObject.Find("Cube").GetComponent<healthBar>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag=="player")
        {
            Debug.Log("player");
            hb.setBarSize(attackStrength);
        }

        //if(collision.collider.tag=="player")
        //{
        //    Debug.Log("player");
        //    hb.setBarSize(attackStrength);
        //}
    }
}
