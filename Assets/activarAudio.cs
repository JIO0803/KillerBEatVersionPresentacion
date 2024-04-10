using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarAudio : MonoBehaviour
{
    AudioSource aud;
    EnemigoSoldado es1;
    EnemigoSoldado es2;
    public GameObject enemy1;
    public GameObject enemy2;
    public int times;
    // Start is called before the first frame update
    private void Start()
    {
        times = 0;
        aud = gameObject.GetComponent<AudioSource>();
        es1 = enemy1.GetComponent<EnemigoSoldado>();
        es2 = enemy2.GetComponent<EnemigoSoldado>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (es1.lifes <= 0 && times == 0|| es2.lifes <= 0 && times == 0)
        {
            aud.Play();
            times = 1;
        }
    }
}
