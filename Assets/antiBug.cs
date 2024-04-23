using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antiBug : MonoBehaviour
{
    public float reposicion = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = collision.transform.position + new Vector3(0, reposicion, 0);
        }             
    }
}
