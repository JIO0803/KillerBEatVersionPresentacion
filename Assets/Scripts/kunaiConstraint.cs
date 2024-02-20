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
        nmdk = GameObject.FindGameObjectWithTag("lifeBar").GetComponent<NumeroDeKunais>();
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("pared") || collision.CompareTag("ground") || (collision.CompareTag("enemRod") ||
            collision.CompareTag("volador") || collision.CompareTag("soldado") || collision.CompareTag("enemy")))
        {
            if (collision.GetComponent<Rigidbody2D>() != null)
            {
                transform.SetParent(collision.transform);
                rb2D.velocity = collision.GetComponent<Rigidbody2D>().velocity;
                collided = true;
                this.gameObject.layer = collision.gameObject.layer;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("pared") || collision.CompareTag("ground") || collision.CompareTag("enemy") ||
           collision.CompareTag("enemRod") || collision.CompareTag("volador") || collision.CompareTag("soldado"))    
        {
            StartCoroutine(Stuck(stuckDuration));
        }   
        if (collision.CompareTag("Player") && collided == true || collision.CompareTag("bala") || collision.CompareTag("misilTeled") || collision.CompareTag("laser")) 
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
    }

    public void AddKunai()
    {
        kunsp.kunaiCount += 1;
        nmdk.kunaiCounts += 1;
    }
}