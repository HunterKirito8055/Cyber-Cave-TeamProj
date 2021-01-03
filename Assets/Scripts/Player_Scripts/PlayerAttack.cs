using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerAttack : MonoBehaviour
{

    public PlayerMovement player;
    




    private void Awake()
    {

        player = GetComponentInParent<PlayerMovement>();

    }
    void Start()
    {
       
    }

  
    private void OnTriggerEnter2D(Collider2D other)
    {

        


       
        
        
        if (other.tag == "Enemy" || other.tag == "EnemySniper")
        {
            
                print("player attacked");
                player.combohits++;
                player.combo_attack_ResetTimer = player._Defaultcombo_attack_ResetTimer;
                // player.ComboHasToReset = false;
                player.ComboHasToReset = true;

            other.gameObject.GetComponent<EnemyRanged>().ImpactShot();
        }

        if(other.tag=="Enemy")
        {
            var c = other.GetComponent<Collider2D>();
            var e = other.gameObject.GetComponent<eHealth_Melee>();
            StartCoroutine(e.OnTriggerEnter2D(c));
            e.OnTriggerEnter2D(c);
        }

        if (other.tag == "EnemySniper" )
        {
            var c = other.GetComponent<Collider2D>();
            var e = other.gameObject.GetComponent<eHealth_LongRanged>();
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
