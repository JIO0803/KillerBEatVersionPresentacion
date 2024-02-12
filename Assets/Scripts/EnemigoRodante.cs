using UnityEngine;
using UnityEngine.Rendering;

public class EnemigoRodante : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float rotationSpeed;
    public float distanceBetween;
    public float ReformedSpeed;
    private float distance;
    private Rigidbody2D rb2D;
    private bool canDealDamage;
    private const float DefaultGravityScale = 10f;
    public const float slow = 8f;
    SpawnKunai spkn;
    public int lifes;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        canDealDamage = true;
        spkn = player.GetComponent<SpawnKunai>();
        lifes = 2;
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        MoveTowardsPlayer();
        RotateEnemy();

        if (lifes == 0)
        {
            receiveDamage3();
        }
    }

    void MoveTowardsPlayer()
    {
        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    void RotateEnemy()
    {
        if (distance < distanceBetween)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (player.transform.position.x >= transform.position.x)
            {
                transform.Rotate(new Vector3(0, 0, -ReformedSpeed));
            }

            if (player.transform.position.x <= transform.position.x)
            {
                transform.Rotate(new Vector3(0, 0, ReformedSpeed));
            }
        }
    }

    void DealDamage()
    {
        if (canDealDamage)
        {
            vidaCount.lifesValue -= 20;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DealDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("kunai") || collision.CompareTag("misilTeled") || collision.CompareTag("bala")))
        {
            lifes -= 1;
        }
    }

    private void receiveDamage3()
    {
        rb2D.gravityScale = DefaultGravityScale;
        Puntuacion.scoreValue += 10;
        vidaCount.lifesValue += 10;
        canDealDamage = false;
        enabled = false;
        gameObject.layer = LayerMask.NameToLayer("deadEnemy");
        spkn.kunaiCount += 1;
        Destroy(gameObject);
    }

    public void TakeExplosionDamage()
    {
        lifes = 0;
    }
}