using UnityEngine;

public class BotonStay : MonoBehaviour
{
    public GameObject Muro;
    Plataformas plat1;
    Plataformas2 plat2;
    public bool act;
    public bool act1;
    // Start is called before the first frame update
    void Start()
    {
        plat1 = Muro.GetComponent<Plataformas>();
        plat2 = Muro.GetComponent<Plataformas2>();
    }

    private void Update()
    {
        if (act)
        {
            plat1.enabled = true;
            plat2.enabled = false;
        }
        if (!act) 
        {
            plat1.enabled = false;
            plat2.enabled = true;
        }    
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("kunai"))
        {
            act = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player") || collision.gameObject.tag == ("BolaActivadora"))
        {
            act = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("kunai"))
        {
            act = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player") || collision.gameObject.tag == ("BolaActivadora"))
        {
            act = false;
        }
    }
}