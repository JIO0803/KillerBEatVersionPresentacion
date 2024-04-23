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
    public bool platCol;
    private GameObject kunai;
    BoxCollider2D bx2d;
    void Start()
    {
        bx2d = GetComponent<BoxCollider2D>();
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
            if (collision.GetComponent<Rigidbody2D>() != null && !collided)
            {
                collided = true;
            }
        }
    }    
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("pared") || collision.CompareTag("ground") || (collision.CompareTag("enemRod") || collision.CompareTag("botonAct")
        || collision.CompareTag("volador") || collision.CompareTag("soldado") || collision.CompareTag("enemy") || collision.CompareTag("headShot")))
        {
            if (collision.GetComponent<Rigidbody2D>() != null && !collided)
            {
                rb2D.gravityScale = 2;    
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground") || collision.CompareTag("enemy") || collision.CompareTag("enemRod") ||
           collision.CompareTag("soldado") || collision.CompareTag("headShot") || (collision.CompareTag("volador")))    
        {
            if (!collided)
            {
                rb2D.velocity = Vector2.zero;
                transform.SetParent(collision.transform);
                collided = true;
                bx2d.isTrigger = false;
                rb2D.gravityScale = 3;
            }  
        }

        if (collision.CompareTag("pared") || collision.CompareTag("botonAct"))
        {
            rb2D.velocity = Vector2.zero;
            transform.SetParent(collision.transform);
            collided = true;
        }

        if (collision.CompareTag("Player") && collided|| collision.CompareTag("bala") || collision.CompareTag("misilTeled") || collision.CompareTag("laser") || collision.gameObject.tag == ("tramp")) 
        {
            AddKunai();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == ("bala") || collision.gameObject.tag == ("misilTeled") || collision.gameObject.tag == ("laser"))
        {
            if (!collided)
            {
                AddKunai();
                Destroy(gameObject);
                collided = true;
            }
        }
    }

    public void AddKunai()
    {
        kunsp.kunaiCount += 1;
        nmdk.kunaiCounts += 1;
    }
}