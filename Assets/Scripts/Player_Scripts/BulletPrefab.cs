using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPrefab : MonoBehaviour
{
    public Transform firepoint;
    public GameObject fireprefab;

   
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            Shoot();
        }
    }
   void Shoot()
    {
        Instantiate(fireprefab, firepoint.position, firepoint.rotation); 
    }
}
