using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{

    public PlayerMovement player;
    public Text Combohit;
    public GameObject ComboObj;

    public int combohits = 0;
    public float combo_attack_ResetTimer;
    public float _Defaultcombo_attack_ResetTimer = 0.6f;

    public bool ComboHasToReset;

    private void Awake()
    {

        player = GetComponentInParent<PlayerMovement>();

    }
    void Start()
    {
        combo_attack_ResetTimer = _Defaultcombo_attack_ResetTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (combohits > 0) //combogameobject should be active if the combo is greater than 0
        {
            ComboObj.SetActive(true);
        }

        if (ComboHasToReset) //UICombo has to reset and disappear
        {

            combo_attack_ResetTimer -= Time.deltaTime * 2f;
            if (combo_attack_ResetTimer <= 0f)
            {
                ComboHasToReset = false;
                ComboObj.SetActive(false);
                combohits = 0;
                combo_attack_ResetTimer = _Defaultcombo_attack_ResetTimer;
            }
        }
        if (gameObject.CompareTag("Enemy"))
        {
            print("ashish");
        }
        Combohit.text = combohits.ToString();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && player.swordattack)
        {

            print("player attacked");
            combohits++;
            ComboHasToReset = false;
            combo_attack_ResetTimer = _Defaultcombo_attack_ResetTimer;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            player.swordattack = false;
            ComboHasToReset = true;
        }
    }
}
