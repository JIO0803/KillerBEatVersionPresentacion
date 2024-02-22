using UnityEngine;

public class BotonStay : MonoBehaviour
{
    public GameObject Muro;
    Plataformas plat1;
    Plataformas2 plat2;

    // Start is called before the first frame update
    void Start()
    {
        plat1 = Muro.GetComponent<Plataformas>();
        plat2 = Muro.GetComponent<Plataformas2>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("kunai") || other.CompareTag("BolaActivadora") || other.CompareTag("Player"))
        {
            plat1.enabled = true;
            plat2.enabled = false;
        }
        else
        {
            plat1.enabled = false;
            plat2.enabled = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player") || collision.gameObject.tag == ("BolaActivadora"))
        {
            plat1.enabled = true;
            plat2.enabled = false;
        }
    }
}