using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour
{
    public Transform healthBarTransform;
    float healthCounter = 1.0f;
    public Gradient healthGradient;
    private Renderer hbMaterial;

    void Start()
    {
        healthBarTransform = GameObject.Find("healthBarMain").GetComponent<Transform>();
        hbMaterial = this.GetComponent<Renderer>();

    }
    public void Update()
    {
        healthBarAesthetics();
    }



    public void setBarSize(float s)
    {
        if (healthBarTransform.localScale.x > 0.01f || healthBarTransform.localScale.x < 1.0f)
            healthCounter = healthCounter - s;

    }

    void healthBarAesthetics()
    {

        hbMaterial.material.SetColor("_Color", healthGradient.Evaluate(healthCounter));

        if (healthBarTransform.localScale.x > 0.01f || healthBarTransform.localScale.x < 1.0f)
            healthBarTransform.localScale = new Vector3(Mathf.Lerp(healthBarTransform.localScale.x, healthCounter, 0.5f), healthBarTransform.localScale.y, healthBarTransform.localScale.z);

    }
}
