using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newSpawn : MonoBehaviour
{
    public GameObject spawner;
    public GameObject newSpawner;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spawner.transform.position = newSpawner.transform.position;
        }
    }
}
