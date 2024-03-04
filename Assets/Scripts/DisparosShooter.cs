using UnityEngine;

public class DisparosShooter : MonoBehaviour
{

    private Transform player;
    Rigidbody2D rb2D;
    private Vector2 initialDirection;
    public Vector2 currentVelocity;
    EnemigoSoldado enemigoSoldado;

    public float startTimeBtwShots;
    public float speed;
    public float slowEffect;
    public float speedBuff;
    public float changingSpeed;
    public bool Stop;
    public bool canCollide = false;
    vidaCount vc;

    private void Start()
    {
        vc = FindAnyObjectByType<vidaCount>();
        rb2D = GetComponent<Rigidbody2D>();
        canCollide = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
       
        if (player != null)
        {
            initialDirection = (player.position - transform.position).normalized;
        }
    }

    void Update()
    {
        transform.Translate(initialDirection * changingSpeed * Time.deltaTime, Space.World);
        rb2D.velocity = Vector2.zero;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("pared") || other.CompareTag("ground") || other.CompareTag("kunai") || other.CompareTag("explosivo") || other.CompareTag("laser"))
        {
            DestroyProjectile();
        }

        if (other.CompareTag("enemRod") && canCollide == true)
        {
            other.GetComponent<EnemigoRodante>().lifes -= 1;
            DestroyProjectile();
        }

        if (other.CompareTag("volador") && canCollide == true)
        {
            other.GetComponent<EnemigoVolador>().lifes -= 1;
            DestroyProjectile();
        }

        if (other.gameObject.tag == "Player")
        {
            DealDamage();
            DestroyProjectile();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("enemRod") || collision.CompareTag("volador") || collision.CompareTag("soldado"))
        {
            canCollide = true;
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    void DealDamage()
    {
        vc.lifesValue -= 0.2f;
    }
}