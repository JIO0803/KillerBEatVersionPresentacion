using UnityEngine;

public class EnemigoVolador : MonoBehaviour
{
    [SerializeField] private float charSpeed;
    [SerializeField] private float stoppingDistance;
    [SerializeField] private float retreatDistance;
    [SerializeField] private float startTimeBtwShots;
    [SerializeField] private float detectDist;
    [SerializeField] private LayerMask obstacleLayer; // Capa para detectar obstáculos
    public GameObject missilePrefab;
    public Transform player;
    private Rigidbody2D rb2D;
    public GameObject kunaiText;
    private const float DefaultGravityScale = 3f;
    private bool canDealDamage;
    public bool canShoot;
    private float timeBtwShots;
    private Vector2 moveDirection = Vector2.zero;
    SpawnKunai spkn;
    public int lifes;
    NumeroDeKunais nmdk;

    private void Start()
    {
        canShoot = true;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
        rb2D = GetComponent<Rigidbody2D>();
        canShoot = true;
        lifes = 1;
        spkn = player.GetComponent<SpawnKunai>();
        nmdk = kunaiText.GetComponent<NumeroDeKunais>();
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
        }
        else if (distanceToPlayer < stoppingDistance && distanceToPlayer > retreatDistance)
        {
            moveDirection = Vector2.zero;
        }
        else if (distanceToPlayer < retreatDistance)
        {
            moveDirection = (transform.position - player.position).normalized;
        }

        // Evitar obstáculos
        RaycastHit2D obstacleHit = Physics2D.Raycast(transform.position, moveDirection, 1f, obstacleLayer);
        if (obstacleHit.collider != null)
        {
            // Si hay un obstáculo, girar en otra dirección
            moveDirection = Quaternion.AngleAxis(90, Vector3.forward) * moveDirection;
        }

        rb2D.velocity = moveDirection * charSpeed;

        if (timeBtwShots <= 0 && canShoot ==true)
        {
            DisparoDeBala();
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
        timeBtwShots = startTimeBtwShots;
        canShoot = true;
    }

    private void FlipSprite()
    {
        transform.localScale = new Vector3(player.position.x >= transform.position.x ? 1f : -1f, 1f, 1f);
    }

    private void DealDamage()
    {
        if (canDealDamage)
        {
            vidaCount.lifesValue -= 20; 
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
            Debug.Log("mediste");
            lifes -= 1;
            receiveDamage2();
        }
    }

    private void receiveDamage2()
    {
        Debug.Log("F");
        rb2D.gravityScale = DefaultGravityScale;
        Puntuacion.scoreValue += 10; 
        vidaCount.lifesValue += 10; 
        canDealDamage = false;
        enabled = false;
        gameObject.layer = LayerMask.NameToLayer("deadEnemy");
        spkn.kunaiCount += 1;
        nmdk.kunaiCounts += 1;
    }
}
