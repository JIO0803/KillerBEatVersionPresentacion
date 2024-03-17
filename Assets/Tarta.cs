using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tarta : MonoBehaviour
{

    public static bool tarta;
    public  bool tartaTurn;
    // Start is called before the first frame update

    private void Awake()
    {
        tarta = false;
    }
    private void Start()
    {
        if (tarta == true)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tarta = true;
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        tartaTurn = tarta;
    }
}
