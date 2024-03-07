using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;

public class KunaiConstraint : MonoBehaviour
{
    //[SerializeField] private float stuckDuration = 0f;
    //[SerializeField] private float waitingTime = 0f;
    //[SerializeField] private float destroyDelay = 8f;
    [SerializeField] private bool collided = false;
    [SerializeField] private float kunaiMass;
    public Sprite carga1;
    public Sprite carga2;
    public Sprite carga3;
    Rigidbody2D rb2D;
    NumeroDeKunais nmdk;
    SpawnKunai kunsp;
    SpriteRenderer sr;
    private GameObject kunai;
    void Start()
    {
        kunai = GameObject.FindGameObjectWithTag("kunai");
        sr = kunai.GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        kunsp = GameObject.FindGameObjectWithTag("Player").GetComponent<SpawnKunai>();
        nmdk = GameObject.FindGameObjectWithTag("lifeBar").GetComponent<NumeroDeKunais>();
    }

    private void Update()
    {
        if (SceneControl.kunaiCount == 1 && kunai != null)
        {
            sr.sprite = carga1;
        }

        if (SceneControl.kunaiCount == 2 && kunai != null)
        {
            sr.sprite = carga2;
        }

        if (SceneControl.kunaiCount == 3 && kunai !=null)
        {
            sr.sprite = carga3;
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("pared") || collision.CompareTag("ground") || (collision.CompareTag("enemRod") || collision.CompareTag("botonAct")
        || collision.CompareTag("volador") || collision.CompareTag("soldado") || collision.CompareTag("enemy") || collision.CompareTag("headShot")))
        {
            if (collision.GetComponent<Rigidbody2D>() != null)
            {

                Stuck();
            }
        }
    }  /*  
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("pared") || collision.CompareTag("ground") || (collision.CompareTag("enemRod") || collision.CompareTag("botonAct")
        || collision.CompareTag("volador") || collision.CompareTag("soldado") || collision.CompareTag("enemy") || collision.CompareTag("headShot")))
        {
            if (collision.GetComponent<Rigidbody2D>() != null)
            {
                rb2D.gravityScale = 5;    
            }
        }
    }
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("pared") || collision.CompareTag("ground") || collision.CompareTag("enemy") || collision.CompareTag("botonAct") ||
           collision.CompareTag("enemRod") || collision.CompareTag("volador") || collision.CompareTag("soldado") || collision.CompareTag("headShot"))    
        {
            rb2D.velocity = collision.GetComponent<Rigidbody2D>().velocity;
            transform.SetParent(collision.transform);
            Stuck();
        }   

        if (collision.CompareTag("enemRod") || collision.CompareTag("volador") || collision.CompareTag("soldado") || collision.CompareTag("headShot"))
        {
            if (!collided)
            {
                transform.SetParent(collision.transform);
                rb2D.velocity = collision.GetComponent<Rigidbody2D>().velocity;
                Stuck();
            }           
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
            Stuck();
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