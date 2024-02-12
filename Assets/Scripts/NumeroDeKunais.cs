using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumeroDeKunais : MonoBehaviour
{
    public int kunaiCounts = 3;
    TMP_Text kunais;
    // Start is called before the first frame update
    void Start()
    {
        kunais = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        kunais.text = "" + kunaiCounts;
        if (kunaiCounts > 3)
        {
            kunaiCounts = 3;
        }

        if (kunaiCounts < 0)
        {
            kunaiCounts = 0;
        }
    }
}