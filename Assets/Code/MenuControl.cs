using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{

    // field for corresponding button
    [SerializeField] GameObject menubotton;


    public void Pause()
    {
        menubotton.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        menubotton.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Instruction(int id)
    {
        SceneManager.LoadScene(id);
    }
}