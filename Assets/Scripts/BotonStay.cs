using UnityEngine;

public class BotonStay : MonoBehaviour
{
    public GameObject Muro;
    Plataformas plat1;
    Plataformas2 plat2;
    private bool boolDeSeguridad;

    // Start is called before the first frame update
    void Start()
    {
        plat1 = Muro.GetComponent<Plataformas>();
        plat2 = Muro.GetComponent<Plataformas2>();
        boolDeSeguridad = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("kunai") || other.CompareTag("BolaActivadora"))
        {
            plat1.enabled = true;
            plat2.enabled = false;
            boolDeSeguridad = true;
        }
        else
        {
            plat1.enabled = false;
            plat2.enabled = true;
            boolDeSeguridad = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            plat1.enabled = true;
            plat2.enabled = false;
        }
        else if (boolDeSeguridad == false)
        {
            plat1.enabled = false;
            plat2.enabled = true;
        }
    }
}