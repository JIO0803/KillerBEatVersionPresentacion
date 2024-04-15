using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empuje : MonoBehaviour
{
    public float impulso;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().AddForce(Vector2.up * impulso, ForceMode2D.Impulse);
    }
}
