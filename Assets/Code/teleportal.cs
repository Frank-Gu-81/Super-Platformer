using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportal : MonoBehaviour
{
    public ScoreKeeper scoreKeeper;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PLAYER")
        {
            scoreKeeper.win();
        }
    }

}
