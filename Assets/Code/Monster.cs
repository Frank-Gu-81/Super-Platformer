using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // Start is called before the first frame update
    public float monsterSpeed = 0.5f;
    private Rigidbody2D monsterRB;
    public AudioSource monsterKilledSound;
    private AudioSource audioSource;
    public ScoreKeeper scoreKeeper;
    public float patrolRange = 5f; // Distance to patrol
    public float speed = 2f; // Speed of patrolling
    private Vector2 startPosition;
    private float patrolTime;

    void Start()
    {
        scoreKeeper = GameObject.FindWithTag("SCOREKEEPER").GetComponent<ScoreKeeper>();
        startPosition = transform.position;
        audioSource = GetComponent<AudioSource>();
        monsterRB = GetComponent<Rigidbody2D>();
        monsterRB.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        patrolTime += Time.deltaTime * speed;
        float newX = startPosition.x + Mathf.Sin(patrolTime) * patrolRange;
        transform.position = new Vector2(newX, startPosition.y);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "PLAYER") {
            Destroy(gameObject);
            scoreKeeper.IncreaseScore();
        }
        if (collision.gameObject.tag == "Bullet") {
            monsterKilledSound.Play();
            scoreKeeper.IncreaseScore();
            Destroy(collision.gameObject);
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Renderer>().enabled = false;
            this.enabled = false;
            Destroy(gameObject, monsterKilledSound.clip.length);
        }
    }

}
