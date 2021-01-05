using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class boxai : MonoBehaviour
{
    public GameObject drone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag== "Player")
        {
            drone.SetActive(true);
            print("dd");
        }
        print("dd");
    }




}
