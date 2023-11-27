using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthKeeper : MonoBehaviour
{
    public float health;
    public TextMeshProUGUI tmp;
    public AudioSource on_hit;

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

    // Update is called once per frame
    void Update()
    {
        if (health > 0)
        {
            tmp.text = "Health: " + health.ToString();
            tmp.color = Color.red;
        }
        if (health == 0) {
            Time.timeScale = 0f;
            tmp.text = "You Lose!";
        }
    }
}