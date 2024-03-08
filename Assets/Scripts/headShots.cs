using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headShots : MonoBehaviour
{
    EnemigoSoldado enemigoSoldado;
    public GameObject enemy;
    public Vector3 loli;
    public float headShotxOffset = 0.21f;
    public float headShotyOffset = 0.85f;
    // Start is called before the first frame update
    void Start()
    {
        enemigoSoldado = enemy.GetComponent<EnemigoSoldado>();
    }

    private void Update()
    {
        transform.position = loli;
        loli = new Vector3(enemy.transform.position.x - headShotxOffset, enemy.transform.position.y + headShotyOffset, 0);
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