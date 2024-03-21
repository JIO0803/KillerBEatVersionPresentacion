using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolasGoGo : MonoBehaviour
{
    public bool canPress;
    public GameObject door;
    public GameObject number2;
    //public GameObject check;
    public GameObject ball;
    Plataformas pl;
    Plataformas2 pl2;
    //SpriteRenderer sr;
    public int doorCount;
    //public Sprite tick;
    // Start is called before the first frame update
    BotonStay bs;
    public GameObject botonStay;
    BolasGoGo bg;
    void Start()
    {
        if (number2 != null)
        {
            bg = number2.GetComponent<BolasGoGo>();
        }
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        //sr = check.GetComponent<SpriteRenderer>();
        doorCount = 0;
        pl = door.GetComponent<Plataformas>();
        pl.enabled = false;
        pl2 = door.GetComponent<Plataformas2>();
        bs = botonStay.GetComponent<BotonStay>();
    }

    // Update is called once per frame
    void Update()
    {
        if (number2 != null)
        {
            bg = number2.GetComponent<BolasGoGo>();
            if (canPress && Input.GetKeyDown(KeyCode.LeftShift) && bs.touching)
            {
                doorCount++;
                Debug.Log("usu");
            }
            if (bg.doorCount >= 1)
            {
                Destroy(bg.ball);
                number2.GetComponent<SpriteRenderer>().color = Color.green;
            }
            if (doorCount >= 1 && bg.doorCount >= 1)
            {
                pl.enabled = true;
                pl2.enabled = false;
                //sr.sprite = tick;
                //sr.color = Color.green;
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                Destroy(ball);
            }
        }
        if (number2 == null)
        {
            if (canPress && Input.GetKeyDown(KeyCode.LeftShift))
            {
                doorCount++;
                Debug.Log("plus");
            }

            if (doorCount >= 1)
            {
                pl.enabled = true;
                //sr.sprite = tick;
                //sr.color = Color.green;
                this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                Destroy(ball);
            }
        }       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BolaActivadora"))
        {
            canPress = true;
        }
    }    
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("BolaActivadora"))
        {
            canPress = false;
        }
    }

}
