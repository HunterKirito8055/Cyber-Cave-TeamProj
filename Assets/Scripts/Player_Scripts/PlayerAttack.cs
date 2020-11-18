using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Comboattack();
    }
    public void Comboattack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("PlayerAttack1");

        }
    }
}
