using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SumarOuntos : MonoBehaviour
{
    private GameObject kamera;
    Rigidbody2D rb2D;
    public float Locura;
    public float waitTime;
    Volume kameraa;
    public void Start()
    {
        kamera = GameObject.FindGameObjectWithTag("MainCamera");
        rb2D = GetComponent<Rigidbody2D>();
        kameraa = kamera.GetComponent<Volume>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("enemRod") || collision.CompareTag("volador") || collision.CompareTag("soldado") || collision.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "pared")
        {
            Destroy(gameObject);
        }        
        
        if (collision.gameObject.tag == "ground")
        {
            Destroy(gameObject);
        }

        if (kameraa.weight == 1)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y) * 0.3f;
            StartCoroutine(AvanceRapido(Locura));
        }
    }

    IEnumerator AvanceRapido(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y) * 3.33333f;
        }
    }
}
