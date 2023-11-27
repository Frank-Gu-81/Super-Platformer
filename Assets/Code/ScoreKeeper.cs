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

    // Update is called once per frame
    void Update()
    {
        tmp.text = "Score: " + score.ToString();
    }
}
