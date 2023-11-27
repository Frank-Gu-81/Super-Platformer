using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerSpeed = 5f;
    public GameObject Bullet;
    private Rigidbody2D playerRB;
    public float playerJumpForce = 5f;
    private Vector3 startingPosition;
    public bool isGrounded = true;
    public AudioClip winningSound;
    public AudioClip loseSound;
    public AudioClip ScoreSound;
    public AudioClip bulletSound; 
    private AudioSource audioSource;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        startingPosition = playerRB.transform.position;
        audioSource = GetComponent<AudioSource>();
        // audioSource.clip = backgroundSound;
        // audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)){
            moveRight();
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            moveLeft();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded){
            jump();
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            FireBullet();
        }
    }

    void moveRight() {
        var currentPosition = transform.position;
        var newPosition = currentPosition + Vector3.right * playerSpeed * Time.deltaTime;
        transform.position = newPosition;
    }

    void moveLeft() {
        var currentPosition = transform.position;
        var newPosition = currentPosition + Vector3.left * playerSpeed * Time.deltaTime;
        transform.position = newPosition;
    }

    void jump() {
        playerRB = GetComponent<Rigidbody2D>();
        playerRB.AddForce(Vector2.up * playerJumpForce, ForceMode2D.Impulse);
        isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            isGrounded = true;
        }
        if (collision.gameObject.tag == "Monster") {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = loseSound;
            audioSource.Play();
            Destroy(gameObject);
            // Lose the game and update Score
        }
        if (collision.gameObject.tag == "Coin") {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = ScoreSound;
            audioSource.Play();
            Destroy(collision.gameObject);
            // Update Score
        }
    }

    void FireBullet() {
        var bulletPos = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
        var bullet = Instantiate(Bullet, bulletPos, Quaternion.identity) as GameObject;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(10, 0, 0);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bulletSound;
        audioSource.Play();
    }

    void OnBecameInvisible() {
        transform.position = startingPosition;
    }
}
