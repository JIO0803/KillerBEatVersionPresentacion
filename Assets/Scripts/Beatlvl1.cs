using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Beatlvl1 : MonoBehaviour
{
    public float WaitingTimee = 0.7f;
    public float WaitingTimee2 = 0.35f;
    public float Locuraa = 0.35f;
    public GameObject Cameraa;
    Beatlvl1 bl1;
    public bool damagee;
    public bool slowerr;
    Monocroma monitito;
    Volume camVol;  
    void Start()
    {
        StartCoroutine(ControlarTiempoo(Locuraa));
        bl1 = GetComponent<Beatlvl1>();
        monitito = GameObject.FindGameObjectWithTag("Player").GetComponent<Monocroma>();
        camVol = Cameraa.GetComponent<Volume>();
    }

    IEnumerator ControlarTiempoo(float waitTime)
    {
        {
            yield return new WaitForSeconds(0.35f);
            while (true)
            {
                if (bl1.enabled == true)
                {
                    yield return StartCoroutine(Slowmoo(WaitingTimee));
                    yield return StartCoroutine(AntiSlowmoo(WaitingTimee2));
                }
                   
            }
        }
    }

    IEnumerator Slowmoo(float waitTime)
    {
         if (bl1.enabled == true)
         {
             yield return new WaitForSeconds(waitTime);
            if (bl1.enabled == true)
            {
                camVol.weight = 0f;
                slowerr = false;
            }    
         }
    }

    IEnumerator AntiSlowmoo(float waitTime)
    {
        if (bl1.enabled == true)
        {
            yield return new WaitForSeconds(waitTime);
            if (bl1.enabled == true)
            {
                camVol.weight = 0.3f;
                damagee = true;
                damagee = false;
                slowerr = true;
            }   
        }
    }
    private void Update()
    {
        Monocroma monocromaComponent = monitito;
        if (monocromaComponent != null && monocromaComponent.Stop == true)
        {
            bl1.enabled = false;
        }
        bl1.enabled = true;
    }
}