using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour
{
    public AudioSource asteroid_collision;
    public GameObject asteroid_prefab;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // Increment the timer by the time passed since last frame

        if (timer >= 2f) // Check if 2 seconds have passed
        {
            float randomX = Random.Range(-10f, 10f); // Generate a random X position, adjust range as needed
            Vector3 spawnPosition = new Vector3(randomX, 3f, 0); // Set spawn position with y = 3 and random x

            Instantiate(asteroid_prefab, spawnPosition, Quaternion.identity); // Instantiate the prefab

            timer = 0f; // Reset the timer
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ASTEROID")
        {
            // Destroy this GameObject
            asteroid_collision.Play();
            Destroy(collision.gameObject);
        }
    }
}
