using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enablePlayer : MonoBehaviour
{
    SpawnKunai sp;
    MovJugador mj;
    wallDetect wd;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        sp = player.GetComponent<SpawnKunai>();
        mj = player.GetComponent<MovJugador>();
        wd = player.GetComponent<wallDetect>();
        mj.enabled = false;
        sp.enabled = false;
        wd.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mj.enabled = true;
            sp.enabled = true;
            wd.enabled = true;
            Destroy(gameObject);    
        }
    }
}
