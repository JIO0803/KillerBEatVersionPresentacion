using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovBeat : MonoBehaviour
{
    public float speed = 4;
    public float speed2 = 50;
    Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Time.timeScale >= 1)
        {
            rb2D.velocity = transform.right * speed;
        }
        if (Time.timeScale < 1 && Time.timeScale > 0.1f)
        {
            rb2D.velocity = transform.right * speed2;
        }

        if (Time.timeScale < 0.001f)
        {
            rb2D.velocity = transform.right;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("UI"))
        {
            Destroy(gameObject);
        }
    }

}