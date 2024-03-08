using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Input.mousePosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("screen"))
        {
            Debug.Log("Pantalla");
        }
    }    
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("screen"))
        {
            Debug.Log("Fuera");
        }
    }
}
