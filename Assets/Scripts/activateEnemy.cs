using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateEnemy : MonoBehaviour
{
    public GameObject soldadoFriend;
    EnemigoSoldado es;
    // Start is called before the first frame update
    void Start()
    {
        es = soldadoFriend.GetComponent<EnemigoSoldado>();
        es.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        es.enabled = true;
    }
}
