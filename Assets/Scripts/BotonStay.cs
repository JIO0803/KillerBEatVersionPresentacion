using Unity.VisualScripting;
using UnityEngine;

public class BotonStay : MonoBehaviour
{
    public GameObject Muro;
    Plataformas plat1;
    Plataformas2 plat2;
    public bool act = false;
    public Sprite activatedSprite;
    public Sprite notactivatedSprite;
    SpriteRenderer currentSprite;
    void Start()
    {
        currentSprite = gameObject.GetComponent<SpriteRenderer>();
        plat1 = Muro.GetComponent<Plataformas>();
        plat2 = Muro.GetComponent<Plataformas2>();
        plat1.enabled = false;
        plat2.enabled = true;
        currentSprite.sprite = notactivatedSprite;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.LeftShift)||  collision.gameObject.CompareTag("kunai"))
        {
            act = true;
        }
        if (collision.gameObject.CompareTag("Player") && !Input.GetKey(KeyCode.LeftShift))
        {
            act = false;
        }
        if (collision.gameObject.CompareTag("BolaActivadora"))
        {
            act = true;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        /*if (!collision.gameObject.CompareTag("Player") || !collision.gameObject.CompareTag("kunai") || !collision.gameObject.CompareTag("BolaActivadora") || collision.gameObject ==null)
        {
            act = false;
            currentSprite.sprite = notactivatedSprite;
        }*/
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("kunai") || collision.gameObject.CompareTag("BolaActivadora"))
        {
            act = false;
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
            plat1.enabled = true;
            plat2.enabled = false;
            currentSprite.sprite = activatedSprite;
        }
        else
        {
            plat1.enabled = false;
            plat2.enabled = true;
            currentSprite.sprite = notactivatedSprite;
        }
    }
}
