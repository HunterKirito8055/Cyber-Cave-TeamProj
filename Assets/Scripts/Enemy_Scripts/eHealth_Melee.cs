using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eHealth_Melee : MonoBehaviour
{
    public float eHealthCounter = 1.0f;
    public bool recieveDamage = true;
    public Animator anim;

    public void Start()
    {
       anim = GetComponent<Animator>();
    }

    public IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.gameObject.tag == "playerObj")
        {
            if (eHealthCounter > 0 && recieveDamage == true)
            {
                //anim.SetTrigger("Impact");
                eHealthCounter -= 0.40f;
            }
            else if (eHealthCounter <= 0 && recieveDamage == true)
            {
                recieveDamage = false;
                gameObject.GetComponent<EnemyMotor>().enabled = false;
                //anim.SetTrigger("Die");
                yield return new WaitForSeconds(2f);
                Destroy(gameObject);
            }
        }
    }
}
