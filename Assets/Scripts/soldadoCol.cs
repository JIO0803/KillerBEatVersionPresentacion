using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldadoCol : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (GetComponentInParent<EnemigoSoldado>().canDealDamage)  
        {
            gameObject.SetActive(true);
        }
    }
}
