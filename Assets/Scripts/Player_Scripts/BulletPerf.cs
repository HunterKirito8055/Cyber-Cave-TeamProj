using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPerf : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        StartCoroutine(DisableFire(2f));
    }

    IEnumerator DisableFire(float t)
    {
        yield return new WaitForSeconds(t);
        gameObject.SetActive(false);
        Destroy();
    }
    void Destroy()
    {
        Destroy(gameObject);
    }

    
}
