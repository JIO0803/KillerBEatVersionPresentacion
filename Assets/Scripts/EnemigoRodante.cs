using UnityEngine;
using UnityEngine.Rendering;

public class EnemigoRodante : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float distanceBetween;
    [SerializeField] private float ReformedSpeed;
    private float distance;
    private Rigidbody2D rb2D;
    private bool canDealDamage;
    private const float DefaultGravityScale = 10f;
    public const float slow = 8f;
    public int lifes;
    pointManager pm;
    vidaCount vc;
    Animator animator;

    private void Start()
    {
        vc = FindObjectOfType<vidaCount>();
        pm = FindObjectOfType<pointManager>();
        rb2D = GetComponent<Rigidbody2D>();
        canDealDamage = true;
        lifes = 1;
        animator = GetComponent<Animator>();
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
            vc.lifesValue -= 1f;
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
        if (collision.CompareTag("kunai"))
        {
            UpdateChildLayersExceptKunai(collision.gameObject.transform.parent.gameObject);
        }
    }

    private void UpdateChildLayersExceptKunai(GameObject enemy)
    {
        // Recorremos todos los hijos del enemigo
        foreach (Transform child in enemy.transform)
        {
            // Si el hijo no es el Kunai, actualizamos su capa
            if (!child.CompareTag("kunai"))
            {
                child.gameObject.layer = LayerMask.NameToLayer("deadEnemy");
            }
        }
    }
    private void receiveDamage3()
    {
        rb2D.gravityScale = DefaultGravityScale;
        canDealDamage = false;
        enabled = false;
        rb2D.mass = 13;
        animator.SetBool("isDead", true);
        gameObject.layer = LayerMask.NameToLayer("deadEnemy");
    }
}