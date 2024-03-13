using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDots : MonoBehaviour
{
    public GameObject dot;
    BolasGoGo bg;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        bg = dot.GetComponent<BolasGoGo>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (bg.doorCount >= 1)
        {
            sr.color = Color.green;
        }
    }
}
