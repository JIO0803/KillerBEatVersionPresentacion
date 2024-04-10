using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActAud2 : MonoBehaviour
{
    AudioSource aud;
    EnemigoSoldado es1;
    public GameObject enemy1;
    public int times;
    // Start is called before the first frame update
    private void Start()
    {
        times = 0;
        aud = gameObject.GetComponent<AudioSource>();
        es1 = enemy1.GetComponent<EnemigoSoldado>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (es1.lifes <= 0 && times == 0)
        {
            aud.Play();
            times = 1;
        }
    }
}
