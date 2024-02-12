using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cañon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bala;
    float timebetween;
    public float startimebetween;
    // Start is called before the first frame update
    void Start()
    {
        timebetween = startimebetween;
    }

    // Update is called once per frame
    void Update()
    {
        if (timebetween <= 0)
        {
            Instantiate(bala, firepoint.position, firepoint.rotation);
            timebetween = startimebetween;
        }
        else
        {
            timebetween -= Time.deltaTime;
        }
    }
}