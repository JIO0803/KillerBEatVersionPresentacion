using System;
using System.Collections;
using UnityEngine;

public class KunaiConstraint : MonoBehaviour
{
    //[SerializeField] private float stuckDuration = 0f;
    //[SerializeField] private float waitingTime = 0f;
    //[SerializeField] private float destroyDelay = 8f;
    [SerializeField] private bool collided = false;
    [SerializeField] private float kunaiMass;
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
        if (collision.CompareTag("pared") || collision.CompareTag("ground") || (collision.CompareTag("enemRod") || collision.CompareTag("botonAct")
        || collision.CompareTag("volador") || collision.CompareTag("soldado") || collision.CompareTag("enemy") || collision.CompareTag("headShot")))
        {
            if (collision.GetComponent<Rigidbody2D>() != null)
            {
                transform.SetParent(collision.transform);
                rb2D.velocity = collision.GetComponent<Rigidbody2D>().velocity;
                collided = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("pared") || collision.CompareTag("ground") || collision.CompareTag("enemy") || collision.CompareTag("botonAct") ||
           collision.CompareTag("enemRod") || collision.CompareTag("volador") || collision.CompareTag("soldado") || collision.CompareTag("headShot"))    
        {
            //StartCoroutine(Stuck(stuckDuration));
            Stuck();
        }   

        if (collision.CompareTag("enemRod") || collision.CompareTag("volador") || collision.CompareTag("soldado") || collision.CompareTag("headShot"))
        {
            transform.SetParent(collision.transform);
            rb2D.velocity = collision.GetComponent<Rigidbody2D>().velocity;
            collided = true;
        }

        if (collision.CompareTag("Player") && collided|| collision.CompareTag("bala") || collision.CompareTag("misilTeled") || collision.CompareTag("laser")) 
        {
            AddKunai();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == ("bala") || collision.gameObject.tag == ("misilTeled") || collision.gameObject.tag == ("laser"))
        {
            AddKunai();
            Destroy(gameObject);
            collided = true;
        }
    }

    /*IEnumerator Stuck(float duration)
    {
        yield return new WaitForSeconds(waitingTime);
        Invoke("AddKunai", destroyDelay);
        Destroy(gameObject, destroyDelay);
        collided = true;
    }
    */
    private void Stuck()
    {
        collided = true;
    }

    public void AddKunai()
    {
        kunsp.kunaiCount += 1;
        nmdk.kunaiCounts += 1;
    }
}