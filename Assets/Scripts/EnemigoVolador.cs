using System.Net;
using UnityEngine;

public class EnemigoVolador : MonoBehaviour
{
    [SerializeField] private float charSpeed;
    [SerializeField] private float stoppingDistance;
    [SerializeField] private float retreatDistance;
    [SerializeField] private float startTimeBtwShots;
    [SerializeField] private float detectDist;
    [SerializeField] private LayerMask obstacleLayer; 
    public GameObject missilePrefab;
    public Transform player;
    private Rigidbody2D rb2D;
    private const float DefaultGravityScale = 3f;
    private bool canDealDamage;
    public bool canShoot;
    private float timeBtwShots;
    private Vector2 moveDirection = Vector2.zero;
    public int lifes;
    pointManager pm;
    vidaCount vc;
    Animator animator;
    public float rotationSpeed;
    Quaternion initialRotation = Quaternion.identity;

    private void Start()
    {
        initialRotation = transform.rotation;
        animator = GetComponent<Animator>();
        vc = FindObjectOfType<vidaCount>();
        pm = FindObjectOfType<pointManager>();
        canShoot = true;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
        rb2D = GetComponent<Rigidbody2D>();
        lifes = 1;
        animator.SetBool("IsDead", false);
    }

    private void Update()
    {
        RaycastHit2D[] raycastHitBuffer = new RaycastHit2D[1];
        int hitCount = Physics2D.RaycastNonAlloc(transform.position, Vector2.down, raycastHitBuffer, 0.25f);
        if (hitCount > 0)
        {
            if (Vector2.Distance(transform.position, player.position) < detectDist)
            {
                Movement();
            }
        }
        FlipSprite();
    }

    private void Movement()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer > stoppingDistance)
        {
            moveDirection = (player.position - transform.position).normalized;

            Quaternion targetRotation = Quaternion.identity;

            if (rb2D.velocity.x < 0)
            {
                targetRotation = Quaternion.Euler(0, 0, 60);
            }
            else if (rb2D.velocity.x > 0)
            {
                targetRotation = Quaternion.Euler(0, 0, -60);
            }

            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
        if (rb2D.velocity.x == 0)   
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, initialRotation, Time.deltaTime * rotationSpeed);
        }

        else if (distanceToPlayer < stoppingDistance && distanceToPlayer > retreatDistance)
        {
            moveDirection = Vector2.zero;
        }
        else if (distanceToPlayer < retreatDistance)
        {

            moveDirection = (transform.position - player.position).normalized;
        }

        /*RaycastHit2D obstacleHit = Physics2D.Raycast(transform.position, moveDirection, 1f, obstacleLayer);
        if (obstacleHit.collider != null)
        {
            moveDirection = Quaternion.AngleAxis(90, Vector3.forward) * moveDirection;
        }*/

        rb2D.velocity = moveDirection * charSpeed;

        if (timeBtwShots <= 0 && canShoot == true)
        {
            DisparoDeBala();
            timeBtwShots = startTimeBtwShots; 
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        if (lifes == 0)
        {
            receiveDamage2();
        }
    }

    private void DisparoDeBala()
    {
        Vector3 obj = player.transform.position;
        Vector2 direction = (obj - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        GameObject kunaiInst = Instantiate(missilePrefab, transform.position, Quaternion.identity);

        kunaiInst.GetComponent<Rigidbody2D>().velocity = direction * charSpeed;
    }

    private void FlipSprite()
    {
        transform.localScale = new Vector3(player.position.x >= transform.position.x ? 1f : -1f, 1f, 1f);
    }

    private void DealDamage()
    {
        if (canDealDamage)
        {
            vc.lifesValue -= 1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DealDamage();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("kunai") || collision.CompareTag("bala")))
        {
            lifes -= 1;
            receiveDamage2();
            if (collision.CompareTag("kunai"))
            {
                UpdateChildLayersExceptKunai(collision.gameObject.transform.parent.gameObject);
            }
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

    private void receiveDamage2()
    {
        animator.SetBool("IsDead", true);
        rb2D.gravityScale = DefaultGravityScale;
        canDealDamage = false;
        enabled = false;
        rb2D.mass = 10;
        gameObject.layer = LayerMask.NameToLayer("deadEnemy");
    }

}
