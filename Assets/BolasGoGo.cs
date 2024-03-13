using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolasGoGo : MonoBehaviour
{
    public bool canPress;
    public GameObject door;
    //public GameObject check;
    public GameObject ball;
    Plataformas pl;
    //SpriteRenderer sr;
    public int doorCount;
    //public Sprite tick;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        //sr = check.GetComponent<SpriteRenderer>();
        doorCount = 0;
        pl = door.GetComponent<Plataformas>();
        pl.enabled = false;
    }

    // Update is called once per frame
    void Update()
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
        else
        {
            pl.enabled = false;
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
