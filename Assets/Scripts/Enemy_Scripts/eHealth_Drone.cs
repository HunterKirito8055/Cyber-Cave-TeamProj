using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eHealth_Drone : MonoBehaviour
{
    public float eHealthCounter = 1.0f;
    public bool recieveDamage = true;
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    public IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "playerObj")
        {
            
                eHealthCounter -= 1.2f;
            
            if (eHealthCounter <= 0 && recieveDamage == true)
            {
                recieveDamage = false;
                //gameObject.GetComponent<EnemyRanged>().enabled = false;
                anim.SetTrigger("droneDie");
                yield return new WaitForSeconds(1f);
                Destroy(gameObject);
            }
        }
    }
}
