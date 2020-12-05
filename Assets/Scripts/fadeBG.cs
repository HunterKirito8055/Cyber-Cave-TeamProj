using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeBG : MonoBehaviour
{
    private Renderer rnd;
    bool alpha = true;
    public float fadeSpeed = 5.0f;
    void Start()
    {
        rnd = GetComponent<Renderer>();
    }


    public void Update()
    {
        if (alpha == true)
        {
            rnd.material.SetFloat("_Blend", Mathf.Lerp(0.0f, 1.0f, Time.smoothDeltaTime * fadeSpeed));
            alpha = !alpha;
        }
        if (alpha == false)
        {
            rnd.material.SetFloat("_Blend", Mathf.Lerp(1.0f, 0.0f, Time.smoothDeltaTime * fadeSpeed));
            alpha = !alpha;
        }

    }
}
