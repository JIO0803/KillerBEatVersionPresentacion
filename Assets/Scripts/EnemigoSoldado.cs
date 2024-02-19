using System;
using UnityEngine;

public class EnemigoSoldado : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;
    [SerializeField] private float charSpeed;
    [SerializeField] private float detectDist;
    public int lifes;

    public bool canDealDamage;
    public GameObject projectile;
    public Transform player;
    [SerializeField] LayerMask Enviroment;
    public GameObject kunaiText;
    public float DefaultGravityScale = 10f;
    Rigidbody2D rb2D;
    SpawnKunai spkn;
    NumeroDeKunais nmdk;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
        rb2D = projectile.GetComponent<Rigidbody2D>();
        lifes = 2;
        spkn = player.GetComponent<SpawnKunai>();
        nmdk = kunaiText.GetComponent<NumeroDeKunais>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D raycastSuelo = Physics2D.Raycast(transform.position, Vector2.down, 0.25f, Enviroment);
        if (Vector2.Distance(transform.position, player.position) < detectDist)
        {
            Movimiento();
        }
        FlipSprite();

        if (lifes == 0)
        {
            receiveDamage();
        }
    }

    void Movimiento()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, charSpeed * Time.deltaTime);
        }

        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -charSpeed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, charSpeed * Time.deltaTime);
        }

        if (timeBtwShots <= 0)
        {
            DisparoDeBala();
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
    private void FlipSprite()
    {
        transform.localScale = new Vector3(player.position.x >= transform.position.x ? 1f : -1f, 1f, 1f);
    }
    void DisparoDeBala()
    {
        Vector3 obj = player.transform.position;
        Vector2 direction = (Vector2)(obj - transform.position);
        direction.Normalize();

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        GameObject bala = Instantiate(projectile, transform.position, Quaternion.identity);
        if (speed != 0.0f)
        {
            bala.GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
        timeBtwShots = startTimeBtwShots;
    }

    public void DealDamage()
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
        if ((collision.CompareTag("kunai")|| collision.CompareTag("misilTeled")))
        {
            lifes -= 1;
        }
    }

    private void receiveDamage()
    {
        rb2D.gravityScale = DefaultGravityScale;
        Puntuacion.scoreValue += 10;
        vidaCount.lifesValue += 10;
        canDealDamage = false;
        enabled = false;
        gameObject.layer = LayerMask.NameToLayer("deadEnemy");
        spkn.kunaiCount += 1;
        nmdk.kunaiCounts += 1;
        Destroy(gameObject);
    }
}