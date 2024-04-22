using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newSpawn : MonoBehaviour
{
    public bool newSpawnActivated = false;
    public GameObject spawner;
    public GameObject newSpawner;
    public Transform[] gameObjectSpawns;
    nextLevel nl;
    // Start is called before the first frame update
    private void Start()
    {
        if (nextLevel.startingLevel == 3)
        {
            gameObject.transform.position = gameObjectSpawns[0].transform.position;
        }        
        if (nextLevel.startingLevel == 6)
        {
            gameObject.transform.position = gameObjectSpawns[1].transform.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            newSpawnActivated = true;
        }
    }
}
