using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPrefab : MonoBehaviour
{
    public Transform firepoint;
    public GameObject fireprefab;
    public Transform rotatable;

    Vector3 mPos, sPos;
    float angle;
    public Texture2D crosshairTexture;
    [SerializeField]
    Vector2 cursorOffset = new Vector2(58,157);
    public void Start()
    {       
        Cursor.SetCursor(crosshairTexture, cursorOffset, CursorMode.Auto);
    }
    void Update()
    {
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

        mPos = Input.mousePosition - Camera.main.WorldToScreenPoint(rotatable.position);
        angle = Mathf.Atan2(mPos.y, mPos.x) * Mathf.Rad2Deg;
        rotatable.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }

}
