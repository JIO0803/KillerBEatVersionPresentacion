using UnityEngine;

public class BotonStay : MonoBehaviour
{
    public GameObject Muro;
    Plataformas plat1;
    Plataformas2 plat2;
    private bool act;
    private bool act1;
    // Start is called before the first frame update
    void Start()
    {
        plat1 = Muro.GetComponent<Plataformas>();
        plat2 = Muro.GetComponent<Plataformas2>();
    }

    private void Update()
    {
        if (act || act1)
        {
            plat1.enabled = true;
            plat2.enabled = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("kunai"))
        {
            act = true;
        }
        else
        {
            act = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player") || collision.gameObject.tag == ("BolaActivadora"))
        {
            act1 = true;
        }
        else
        {
            act1 = false;
        }
    }
}