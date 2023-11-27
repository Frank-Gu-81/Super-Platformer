using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreKeeper : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public TextMeshProUGUI tmp;
    public AudioSource coin_collection;
    public AudioSource win_audio;

    void Start()
    {
        score = 0;
        tmp.text = "Score: " + score.ToString();
    }

    public void IncreaseScore()
    {
        score += 1;
    }

    public void collect_coin()
    {
        IncreaseScore();
        coin_collection.Play();
    }

    public void surprise_box()
    {
        IncreaseScore();
        IncreaseScore();
        IncreaseScore();
        IncreaseScore();
        IncreaseScore();
    }

    public void win()
    {
        Time.timeScale = 0f;
        tmp.text = "You Won!";
        tmp.color = Color.red;
        win_audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            tmp.text = "Score: " + score.ToString();
        }
           
    }
}
