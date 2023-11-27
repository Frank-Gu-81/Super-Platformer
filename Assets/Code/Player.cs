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
    public AudioSource winningSound;
    public AudioSource loseSound;
    public AudioSource ScoreSound;
    public AudioSource MonsterKillSound; 
    public AudioSource audioSource;
    public HealthKeeper healthKeeper;
    public ScoreKeeper s;

    void Start()
    {
        healthKeeper = GameObject.FindWithTag("HEALTHKEEPER").GetComponent<HealthKeeper>();
        playerRB = GetComponent<Rigidbody2D>();
        startingPosition = playerRB.transform.position;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "COIN")
        {
            s.collect_coin();
            Destroy(collision.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if ((collision.gameObject.tag == "GROUND") | (collision.gameObject.tag == "GROUND1")) {
            isGrounded = true;
        }
        else if (collision.gameObject.tag == "ASTEROID")
        {
            healthKeeper.DecreaseHealth();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Monster") {
            healthKeeper.DecreaseHealth();
            MonsterKillSound.Play();
            Destroy(collision.gameObject);
            // Lose the game and update Score
        }
        if ((collision.gameObject.tag == "Teleportal"))
        {
            s.win();
        }
    }

    void FireBullet() {
        Vector3 bulletPos = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
        audioSource.Play();
        GameObject bullet = Instantiate(Bullet, bulletPos, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(10, 0, 0);
    }

    void OnBecameInvisible() {
        healthKeeper.Lose();
    }

}
