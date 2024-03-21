using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolasActBotonStay : MonoBehaviour
{
    public GameObject boton;
    BotonStay bs;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        bs = boton.GetComponent<BotonStay>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (bs.act)
        {
            sr.color = Color.green;
        }
        if (!bs.act)
        {
            sr.color = Color.white;
        }
    }
}
