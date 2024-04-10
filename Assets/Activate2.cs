using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activate2 : MonoBehaviour
{
    public GameObject signs;
    private float contadorSegundos = 0f; // Contador de segundos
    public float maxSecs;
    // Start is called before the first frame update
    void Start()
    {
        signs.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            contadorSegundos += Time.deltaTime;
            {
                if (contadorSegundos >= maxSecs)
                {
                    signs.SetActive(true);
                }
            }
        }
    }
}
