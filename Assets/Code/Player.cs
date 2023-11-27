using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerSpeed = 5f;
    private Rigidbody2D playerRB;
    public float playerJumpForce = 5f;
    public bool isGrounded = true;
    public AudioClip winningSound;
    public AudioClip loseSound;
    public AudioClip SoreSound;
    public AudioClip backgroundSound; 
    private AudioSource audioSource;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0f)
        {
            return;
        }
        if (Input.GetKey(KeyCode.RightArrow)){
            moveRight();
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            moveLeft();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded){
            jump();
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
        Debug.Log("Jumping");
        playerRB = GetComponent<Rigidbody2D>();
        playerRB.AddForce(Vector2.up * playerJumpForce, ForceMode2D.Impulse);
        isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            isGrounded = true;
        }
        if (collision.gameObject.tag == "Enemy") {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = loseSound;
            audioSource.Play();
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Win") {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = winningSound;
            audioSource.Play();
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Sore") {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = SoreSound;
            audioSource.Play();
            Destroy(gameObject);
        }
    }
}
