using UnityEngine;

public class BotonStay : MonoBehaviour
{
    public GameObject Muro;
    Plataformas plat1;
    Plataformas2 plat2;
    public static bool act = false;
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
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("BolaActivadora") || collision.gameObject.CompareTag("kunai"))
        {
            act = true;
        }
        else
        {
            act = false;
            currentSprite.sprite = notactivatedSprite;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            act = true;
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
