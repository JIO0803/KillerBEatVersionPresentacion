using Unity.VisualScripting;
using UnityEngine;

public class BotonStay : MonoBehaviour
{
    public GameObject Muro;
    Plataformas plat1;
    Plataformas2 plat2;
    public bool act = false;
    public bool touching = false;
    public Sprite activatedSprite;
    public Sprite notactivatedSprite;
    SpriteRenderer currentSprite;
    void Start()
    {
        currentSprite = gameObject.GetComponent<SpriteRenderer>();
        if (Muro != null )
        {
            plat1 = Muro.GetComponent<Plataformas>();
            plat2 = Muro.GetComponent<Plataformas2>();
            plat1.enabled = false;
            plat2.enabled = true;
        }


        currentSprite.sprite = notactivatedSprite;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            touching = true;
        }
        if (touching && Input.GetKey(KeyCode.LeftShift) || collision.gameObject.CompareTag("kunai"))
        {
            act = true;
        }

        if (touching && !Input.GetKey(KeyCode.LeftShift) || !touching && !collision.gameObject.CompareTag("kunai"))
        {
            act = false;
        }
        if (collision.gameObject.CompareTag("BolaActivadora"))
        {
            act = true;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }    
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("kunai") || collision.gameObject.CompareTag("BolaActivadora"))
        {
            act = false;
            touching = false;
        }
    }

    private void Update()
    {
        if (gameObject.GetComponentInChildren<KunaiConstraint>())
        {
            act = true;
        }

        if (act)
        {
            if (Muro != null)
            {
                Debug.Log("Si");
                plat1.enabled = true;
                plat2.enabled = false;
            }
            currentSprite.sprite = activatedSprite;
        }
        if (!act)
        {
            if (Muro != null)
            {
                Debug.Log("No");
                plat1.enabled = false;
                plat2.enabled = true;
            }
            currentSprite.sprite = notactivatedSprite;
        }
    }
}
