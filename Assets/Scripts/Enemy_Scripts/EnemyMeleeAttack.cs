using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {







        if (other.tag == "Player" )
        {

            print("playerdamaged");
        }

        if (other.tag == "Enemy")
        {
            var c = other.GetComponent<Collider2D>();
            var e = other.gameObject.GetComponent<eHealth_Melee>();
            StartCoroutine(e.OnTriggerEnter2D(c));
            e.OnTriggerEnter2D(c);
        }

        



    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {

        }
    }
}
