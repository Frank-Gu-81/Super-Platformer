using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{

    // field for corresponding button
    [SerializeField] GameObject menubotton;

    public bool inst = false;

    public void Pause()
    {
        if (GameObject.FindObjectOfType<HealthKeeper>())
        {
           if (GameObject.FindObjectOfType<ScoreKeeper>())
           {
                if (!GameObject.FindObjectOfType<HealthKeeper>().badend)
                {
                    if (!GameObject.FindObjectOfType<ScoreKeeper>().goodend)
                    {
                        menubotton.SetActive(true);
                        Time.timeScale = 0f;
                    }   
                }
           }
        }  
    }

    public void Resume()
    {
        menubotton.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Instruction(int id)
    {
        if(id == 1)
        {
            inst = true;
        }
        else
        {
            inst = false;
        }
        SceneManager.LoadScene(id);
        Time.timeScale = 1f;
    }
}