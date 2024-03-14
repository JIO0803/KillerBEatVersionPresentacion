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
    public bool isDead;

    public bool canDealDamage;
    [SerializeField] LayerMask Enviroment;
    [SerializeField] private float DefaultGravityScale = 10f;
    public GameObject projectile;
    public GameObject headShot;
    headShots hs;
    public Transform player;
    pointManager pm;
    Rigidbody2D rb2D;
    Rigidbody2D soldadoRigidBody2d;
    vidaCount vc;
    Animator animator;
    BoxCollider2D boxCollider2d;
    CapsuleCollider2D capsuleCollider2d;
    private void Start()
    {
        boxCollider2d = GetComponent<BoxCollider2D>();
        capsuleCollider2d = GetComponent<CapsuleCollider2D>();
        vc = FindObjectOfType<vidaCount>();
        pm = FindObjectOfType<pointManager>();
        hs = headShot.GetComponent<headShots>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
        rb2D = projectile.GetComponent<Rigidbody2D>();
        lifes = 1;
        animator = GetComponent<Animator>();
        isDead = false;
        boxCollider2d.enabled = false;
        soldadoRigidBody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < detectDist && lifes >= 0)
        {
            Movimiento();
        }
        FlipSprite();

        if (lifes <= 0 && !isDead)
        {
            receiveDamage();
            Debug.Log("Disabled");
        }
    }

    void Movimiento()
    {
        // Verificar si el enemigo está vivo
        if (lifes > 0 && !isDead)
        {
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, charSpeed * Time.deltaTime);
                animator.SetBool("isRobotRunning", true);
            }

            else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
                animator.SetBool("isRobotRunning", false);
            }
            else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -charSpeed * Time.deltaTime);
                animator.SetBool("isRobotRunning", true);
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
        else
        {
            animator.SetBool("isRobotRunning", false); 
        }
    }

    void DisparoDeBala()
    {
        if (lifes > 0)
        {
            Vector3 obj = player.transform.position;
            Vector2 direction = (Vector2)(obj - transform.position);
            direction.Normalize();

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            if (gameObject.transform.localScale.x == 1) 
            {
                GameObject bala = Instantiate(projectile, transform.position + new Vector3(0.5f, 0, 0), Quaternion.identity);
                if (speed != 0.0f)
                {
                    bala.GetComponent<Rigidbody2D>().velocity = direction * speed;
                }
            }            
            
            if (gameObject.transform.localScale.x == -1) 
            {
                GameObject bala = Instantiate(projectile, transform.position + new Vector3(-0.5f, 0, 0), Quaternion.identity);
                if (speed != 0.0f)
                {
                    bala.GetComponent<Rigidbody2D>().velocity = direction * speed;
                }
            }        
            timeBtwShots = startTimeBtwShots;
        }
        
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
        soldadoRigidBody2d.velocity = new Vector2 (0,0); 
        rb2D.gravityScale = DefaultGravityScale;
        Puntuacion.scoreValue += 10;
        pm.Invoke("AddPoints", 0f);
        canDealDamage = false;
        capsuleCollider2d.enabled = false;
        boxCollider2d.enabled = true;  
        headShot.transform.Rotate(0, 0, 90);
        hs.headShotxOffset = newheadShotxOffset;
        hs.headShotyOffset = newheadShotyOffset;
        soldadoRigidBody2d.mass = 13;
        isDead = true;
        animator.SetBool("isRobotDead", true);
        animator.SetBool("isRobotRunning", false);
        speed = 0;
        charSpeed = 0;
        enabled = false;
        //Destroy(gameObject, 2);
    }
}