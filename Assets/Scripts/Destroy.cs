using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "beat")
        {
            Destroy(col.gameObject);
        }     
    }
}
