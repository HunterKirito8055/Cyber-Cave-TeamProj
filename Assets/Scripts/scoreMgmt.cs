using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreMgmt : MonoBehaviour
{
    private healthBar hb;
    public float attackStrength = 0.2f;
    public Animator anim;
    private bool recieveDamage = true;

    public void Start()
    {
        recieveDamage = true;
        anim = GetComponent<Animator>();
        hb = GameObject.Find("Cube").GetComponent<healthBar>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemyObj")
        {
            
            
            if ((hb.healthBarTransform.localScale.x > 0.01f)&& recieveDamage == true)
            {
                collision.gameObject.SetActive(false);
                hb.setBarSize(attackStrength);
                anim.SetTrigger("Impact");
            }

            if (hb.healthBarTransform.localScale.x <= 0.01f && recieveDamage == true)
            {
                recieveDamage = false;
                anim.SetTrigger("Death");
            }

        }

        //collectibles
        if (collision.gameObject.tag == "collectibleHealth")
        {
            Debug.Log("player");
            if (hb.healthBarTransform.localScale.x < 1.0f)
                hb.setBarSize(-0.2f);
            collision.gameObject.SetActive(false);
        }
    }
}
