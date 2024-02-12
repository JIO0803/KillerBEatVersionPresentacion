using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;

public class Beatlvl3 : MonoBehaviour
{
    public float WaitingTime = 1;
    public float WaitingTime2 = 0.5f;
    public float Locura = 0.5f;
    public GameObject Camera;
    Beatlvl3 bl3;
    public bool damage;
    public bool slower;
    Volume volume;
    Monocroma monito;
    void Start()
    {
        StartCoroutine(ControlarTiempo(Locura));
        bl3 = GetComponent<Beatlvl3>();
        monito = GameObject.FindGameObjectWithTag("Player").GetComponent<Monocroma>();
        volume = Camera.GetComponent<Volume>();
    }

    IEnumerator ControlarTiempo(float waitTime)
    {
        {
            yield return new WaitForSeconds(0.5f);
            while (true)
            {
                if (bl3.enabled == true)
                {  
                    yield return StartCoroutine(Slowmo(WaitingTime));
                    yield return StartCoroutine(AntiSlowmo(WaitingTime2));
                }   
            }
        }
    }

    IEnumerator Slowmo(float waitTime)
    {
         if (bl3.enabled == true)
         {
             yield return new WaitForSeconds(waitTime);
            if (bl3.enabled == true)
            {
                volume.weight = 0f;
                slower = false;
            }    
         }
    }

    IEnumerator AntiSlowmo(float waitTime)
    {
        if (bl3.enabled == true)
        {
            yield return new WaitForSeconds(waitTime);
            if (bl3.enabled == true)
            {
                volume.weight = 0.3f;
                damage = true;
                damage = false;
                slower = true;
            }   
        }
    }
    private void Update()
    {
        Monocroma monocromaComponent = monito;
        if (monocromaComponent != null && monocromaComponent.Stop == true)
        {
            bl3.enabled = false;
        }
    }
}