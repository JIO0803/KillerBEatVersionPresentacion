using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antiProjectiles : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("kunai") || collision.CompareTag("bala") || collision.CompareTag("misilTeled"))
        {
            Destroy(collision.gameObject);
        }
    }
}