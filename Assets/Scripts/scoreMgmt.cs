using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreMgmt : MonoBehaviour
{
    private healthBar hb;
    public float attackStrength = 0.2f;

    public void Start()
    {
        hb = GameObject.Find("Cube").GetComponent<healthBar>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        //enemy objects
        if (collision.collider.gameObject.tag == "enemyObj")
        {
            Debug.Log("player");
            if(hb.healthBarTransform.localScale.x > 0.01f)
            hb.setBarSize(attackStrength);
            collision.collider.gameObject.SetActive(false);
        }

        //collectibles
        if (collision.collider.gameObject.tag == "collectibleHealth")
        {
            Debug.Log("player");
            if (hb.healthBarTransform.localScale.x < 1.0f)
            hb.setBarSize(-0.2f);
            collision.collider.gameObject.SetActive(false);
        }

    }
}
