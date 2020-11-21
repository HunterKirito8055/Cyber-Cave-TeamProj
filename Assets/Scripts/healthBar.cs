using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour
{
    public Transform healthBarTransform;
    float healthCounter = 1.0f;
    void Start()
    {
        healthBarTransform = GameObject.Find("healthBarMain").GetComponent<Transform>();
    }
    public void setBarSize(float s)
    {
        if (healthBarTransform.localScale.x > 0.01f || healthBarTransform.localScale.x < 1.0f)
        {
            healthCounter = healthCounter - s;
            healthBarTransform.localScale = new Vector3(healthCounter, healthBarTransform.localScale.y, healthBarTransform.localScale.z);
        }
    }
}
