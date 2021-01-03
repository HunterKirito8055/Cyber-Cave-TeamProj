using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuScript : MonoBehaviour
{
    public GameObject[] elements;
    public void buttonPlay()
    {
        SceneManager.LoadScene("introScene");
    }

    public void buttonCredits()
    {

        foreach(GameObject e in elements )
        {
            Color c = e.GetComponent<Renderer>().material.color;
            c.a = Mathf.MoveTowards(1,0,1.0f);
        }
    }
}
