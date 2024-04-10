using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldadoSalvado : MonoBehaviour
{
    public static bool salvado;
    public bool salvadoCheck;
    public GameObject texto;
    AudioSource aud;
    // Start is called before the first frame update
    EnemigoSoldado es;
    
    private void Awake()
    {
        if (nextLevel.startingLevel == 4)
        {
            salvado = false;
        }
    }
    private void Start()
    {
        aud = gameObject.GetComponent<AudioSource>();
        if (nextLevel.startingLevel == 4)
        {
            es = gameObject.GetComponent<EnemigoSoldado>();
            if (salvado == true)
            {
                Destroy(gameObject);
                texto.SetActive(false);
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (nextLevel.startingLevel == 4)
        {
            salvadoCheck = salvado;
            if (es = null)
            {
                salvado = false;
            }
            else
            {
                salvado = true;
            }
        }       
    }
}
