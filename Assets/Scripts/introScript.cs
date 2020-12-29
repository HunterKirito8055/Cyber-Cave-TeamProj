using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class introScript : MonoBehaviour
{
    public GameObject[] frames;
    private int i = 0;
    
    void Start()
    {
        frames[i].gameObject.SetActive(true);
    }

    public void clickNext()
    {
        frames[i].gameObject.SetActive(false); 
        i++;

        if(i>=0 && i<=4)
        frames[i].gameObject.SetActive(true);
        else
        Debug.Log("Frames Completed");
        
        //Debug.Log(i);
        if (i >= frames.Length-1)
            SceneManager.LoadScene("prototypeScene");


        
    }
}
