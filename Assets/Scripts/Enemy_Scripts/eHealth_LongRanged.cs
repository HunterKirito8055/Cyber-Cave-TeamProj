using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eHealth_LongRanged : MonoBehaviour
{
    public float eHealthCounter = 1.0f;
    public bool recieveDamage = true;
    public Animator anim;
    public AudioSource death;

    void Start()
    {
        anim = GetComponent<Animator>();
        death = GetComponent<AudioSource>();
    }


    public IEnumerator OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.tag == "playerObj")
        {
            if (eHealthCounter > 0 && recieveDamage == true)
            {
                anim.SetTrigger("Impact");
                eHealthCounter -= 0.30f;
            }
            else if (eHealthCounter <= 0 && recieveDamage == true)
            {
                recieveDamage = false;
                gameObject.GetComponent<EnemyRanged>().enabled = false;
                anim.SetTrigger("Die");
                death.Play();
                yield return new WaitForSeconds(2f);
                Destroy(gameObject);
            }
        }
    }
}
