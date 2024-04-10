using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarAudio : MonoBehaviour
{
    AudioSource aud;
    EnemigoSoldado es;
    public static int times;
    // Start is called before the first frame update
    void Start()
    {
        times = 0;
        aud = gameObject.GetComponent<AudioSource>();
        es = gameObject.GetComponent<EnemigoSoldado>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (es.lifes <= 0 && times == 0)
        {
            aud.Play();
            times++;
        }
    }
}
