using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthKeeper : MonoBehaviour
{
    public float health;
    public TextMeshProUGUI tmp;
    public AudioSource on_hit;
    public AudioSource lose;

    private void Start()
    {
        health = 3;
        tmp.text = "Health: " + health.ToString();
    }

    public void DecreaseHealth()
    {
        if (health > 0)
        {
            health -= 1;
            on_hit.Play();
        }
    }

    public void Lose()
    {
        lose.Play();
        health = -1;
        tmp.text = "You Lose!";
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {
            tmp.text = "Health: " + health.ToString();
            if (health < 3)
            {
                tmp.color = Color.red;
            }
        }
        else if (health == 0) {
            
            Lose();
            health--;
        }
    }
}
