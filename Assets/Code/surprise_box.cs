using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriceBox : MonoBehaviour
{
    public float patrolRange = 5f; // Distance to patrol
    public float speed = 2f; // Speed of patrolling
    private Vector2 startPosition;
    private float patrolTime;
    private bool collided = false;
    private SpriteRenderer spriteRenderer;
    public AudioSource box_audio;
    public ScoreKeeper scoreKeeper;

    // Update is called once per frame
    void Start()
    {
        scoreKeeper = GameObject.FindWithTag("SCOREKEEPER").GetComponent<ScoreKeeper>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        startPosition = transform.position;
        spriteRenderer.color = Color.red;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collided)
        {
            if (collision.gameObject.tag == "PLAYER")
            {
                collided = true;
                spriteRenderer.color = Color.grey;
                box_audio.Play();
                scoreKeeper.surprise_box();
            }
        }
    }

    void Update()
    {
        patrolTime += Time.deltaTime * speed;
        float newX = startPosition.x + Mathf.Sin(patrolTime) * patrolRange;
        transform.position = new Vector2(newX, startPosition.y);
    }
}
