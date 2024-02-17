using System;
using System.Collections;
using UnityEngine;

public class KunaiConstraint : MonoBehaviour
{
    public float stuckDuration = 0f;
    public float waitingTime = 0f;
    public float destroyDelay = 8f;
    public bool collided = false;
    Rigidbody2D rb2D;
    NumeroDeKunais nmdk;
    SpawnKunai kunsp;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        kunsp = GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnKunai>();
        nmdk = GameObject.FindGameObjectWithTag("kunaiNumber").GetComponent<NumeroDeKunais>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pared") || collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("explosivo"))
        {
            transform.SetParent(collision.transform);
            rb2D.velocity = Vector2.zero;
            collided = true;
            if (collision == null)
            {
                rb2D.gravityScale = 5;
            }
        }

        if (collision.CompareTag("enemRod") || collision.CompareTag("volador") || collision.CompareTag("soldado") || collision.CompareTag("enemy"))
        {
            transform.SetParent(collision.transform);
            rb2D.velocity = Vector2.zero;
            collided = true;
            if (collision == null)
            {
                rb2D.gravityScale = 5;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("explosivo") ||  collision.gameObject.CompareTag("pared") || collision.gameObject.CompareTag("ground"))     
        {
            StartCoroutine(Stuck(stuckDuration));
        }
        if (collision.gameObject.CompareTag("Player") && collided == true || collision.gameObject.CompareTag("bala") || collision.gameObject.CompareTag("misilTeled") || collision.gameObject.CompareTag("laser") 
            || collision.CompareTag("enemRod") || collision.CompareTag("volador") || collision.CompareTag("soldado") || collision.CompareTag("enemy"))
        {
            AddKunai();
            Destroy(gameObject);
        }
    }

    IEnumerator Stuck(float duration)
    {
        yield return new WaitForSeconds(waitingTime);
        Invoke("AddKunai", destroyDelay);
        Destroy(gameObject, destroyDelay);
        Debug.Log("Sumar");
    }

    public void AddKunai()
    {
        kunsp.kunaiCount += 1;
        nmdk.kunaiCounts += 1;
    }
}