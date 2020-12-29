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

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            
            print("player attacked");
           player.combohits++;
            
           player.combo_attack_ResetTimer = player._Defaultcombo_attack_ResetTimer;
            // player.ComboHasToReset = false;
            player.ComboHasToReset = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
           
        }
    }
   
}
