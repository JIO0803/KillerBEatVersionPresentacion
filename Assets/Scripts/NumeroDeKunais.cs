using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NumeroDeKunais : MonoBehaviour
{
    public int kunaiCounts = 3;
    public GameObject kunaiCharge1;
    public GameObject kunaiCharge2;
    public GameObject kunaiCharge3;
    public bool hasKunai;

    private void Start()
    {
        if (!UpgradeMenu.kunaiOwnedd)
        {
            kunaiCounts = 0;
        }        

    }
    void Update()
    {
        if (kunaiCounts > 3)
        {
            kunaiCounts = 3;
        }

        if (kunaiCounts < 0)
        {
            kunaiCounts = 0;
        }
        if (kunaiCounts > SceneControl.kunaiMax)
        {
            kunaiCounts = SceneControl.kunaiMax;
        }
        if (kunaiCounts == 0)
        {
            hasKunai = false;
            kunaiCharge1.SetActive(false);
            kunaiCharge2.SetActive(false);
            kunaiCharge3.SetActive(false);
        }
        if (kunaiCounts == 1)
        {
            hasKunai = true;
            kunaiCharge1.SetActive(true);
            kunaiCharge2.SetActive(false);
            kunaiCharge3.SetActive(false);
        }       
        
        if (kunaiCounts == 2)
        {
            hasKunai = true;
            kunaiCharge1.SetActive(true);
            kunaiCharge2.SetActive(true);
            kunaiCharge3.SetActive(false);
        }        
        
        if (kunaiCounts == 3)
        {
            hasKunai = true;
            kunaiCharge1.SetActive(true);
            kunaiCharge2.SetActive(true);
            kunaiCharge3.SetActive(true);
        }
    }
}