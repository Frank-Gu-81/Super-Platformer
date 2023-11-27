using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid : MonoBehaviour
{
    private ground g;
    // Start is called before the first frame update
    void Start()
    {
        g = GameObject.FindWithTag("GROUND").GetComponent<ground>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GROUND1") {
            g.asteroid_collision.Play();
            Destroy(this.gameObject);
        }
    }
}
