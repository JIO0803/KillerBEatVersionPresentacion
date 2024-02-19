using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headShots : MonoBehaviour
{
    EnemigoSoldado enemigoSoldado;
    // Start is called before the first frame update
    void Start()
    {
        enemigoSoldado = GetComponentInParent<EnemigoSoldado>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemigoSoldado.DealDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("kunai") || collision.CompareTag("misilTeled")))
        {
            enemigoSoldado.lifes -= 2;
        }
    }
}