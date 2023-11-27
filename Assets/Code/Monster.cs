using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    // Start is called before the first frame update
    public float monsterSpeed = 0.5f;
    private Rigidbody2D monsterRB;
    private Vector3 startingPosition;
    public AudioClip monsterKilledSound;
    private AudioSource audioSource;

    void Start()
    {
        monsterRB = GetComponent<Rigidbody2D>();
        startingPosition = transform.position;
        monsterRB.freezeRotation = true;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // make the monster move horizontally between left and right within the screen
        transform.position = new Vector3(Mathf.PingPong(Time.time * monsterSpeed, 4) - 2, transform.position.y, transform.position.z);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Bullet") {
            audioSource.PlayOneShot(monsterKilledSound);
            Destroy(collision.gameObject);
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Renderer>().enabled = false;
            this.enabled = false;
            Destroy(gameObject, monsterKilledSound.length);
        }
    }

    void OnBecameInvisible() {
        transform.position = startingPosition;
    }
}
