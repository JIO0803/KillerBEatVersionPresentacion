using System;
using UnityEngine;

public class EnemigoSoldado : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float stoppingDistance;
    [SerializeField] private float retreatDistance;

    private float timeBtwShots;
    [SerializeField] private float startTimeBtwShots;
    [SerializeField] private float charSpeed;
    [SerializeField] private float detectDist;
    public int lifes;
    public float newheadShotxOffset;
    public float newheadShotyOffset;

    public bool canDealDamage;
    [SerializeField] LayerMask Enviroment;
    [SerializeField] private float DefaultGravityScale = 10f;
    public GameObject projectile;
    public GameObject headShot;
    headShots hs;
    public Transform player;
    pointManager pm;
    Rigidbody2D rb2D;
    vidaCount vc;

    private void Start()
    {
        vc = FindObjectOfType<vidaCount>();
        pm = FindObjectOfType<pointManager>();
        hs = headShot.GetComponent<headShots>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
        rb2D = projectile.GetComponent<Rigidbody2D>();
        lifes = 2;
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

        if (lifes <= 0)
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

    private void FlipSprite()
    {
        transform.localScale = new Vector3(player.position.x >= transform.position.x ? 1f : -1f, 1f, 1f);
    }

    public void DealDamage()
    {
        if (canDealDamage)
        {
            vc.lifesValue -= 0.2f;
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
        pm.Invoke("AddPoints", 0f);
        canDealDamage = false;
        enabled = false;
        transform.Rotate(0, 0, 90);
        headShot.transform.Rotate(0, 0, 90);
        hs.headShotxOffset = newheadShotxOffset;
        hs.headShotyOffset = newheadShotyOffset;
        rb2D.mass = 13;
    }
}