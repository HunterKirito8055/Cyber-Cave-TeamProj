using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPrefab : MonoBehaviour
{
    public Transform firepoint;
    public GameObject fireprefab;
    public Transform rotatable;
    public Transform crosshair;

    Vector3 mPos, sPos;
    float angle;
    [SerializeField]
    float offsetX=625f, offsetY=200f;
    
    void Update()
    {
        crosshair.transform.rotation = Camera.main.transform.rotation;
        if (Input.GetMouseButtonDown(1))
        {
            Shoot();
        }

        spawnPointRotate();
    }
    void Shoot()
    {
        Instantiate(fireprefab, firepoint.position, firepoint.rotation);
    }

    void spawnPointRotate()
    {
        mPos = Input.mousePosition;
        sPos = Camera.main.WorldToScreenPoint(rotatable.localPosition);
        var offSet = new Vector2(mPos.x - (sPos.x-offsetX), mPos.y - (sPos.y+offsetY));
        angle = Mathf.Atan2(offSet.y, offSet.x) * Mathf.Rad2Deg;
        rotatable.rotation = Quaternion.Euler(0,0,angle);

    }

}
