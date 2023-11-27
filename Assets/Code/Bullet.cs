using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "SURPRISE_BOX")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "GROUND1")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "ASTEROID")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
