using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    // Start is called before the first frame update
    private bool triggered = false;
    private SpriteRenderer spriteRenderer;
    public AudioSource trap_audio;
    public HealthKeeper health_keeper;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        health_keeper = GameObject.FindWithTag("HEALTHKEEPER").GetComponent<HealthKeeper>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggered)
        {
            if (collision.gameObject.tag == "PLAYER")
            {
                trap_audio.Play();
                health_keeper.DecreaseHealth();
                spriteRenderer.color = Color.white;
                triggered = true;
            }
        }
    }
}
