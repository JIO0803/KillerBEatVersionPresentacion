using UnityEngine;

public class MisilDirigido : MonoBehaviour
{
    public float speed;
    private Transform player;

    Rigidbody2D rb2D;
    public float changingSpeed;
    public bool Stop;
    public bool canCollide = false;

    public float startTimeBtwShots;
    GameObject volador;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2D = GetComponent<Rigidbody2D>();
        canCollide = false;
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized * changingSpeed;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
            rb2D.velocity = Vector2.zero;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("pared") || other.CompareTag("ground") || other.CompareTag("kunai") || other.CompareTag("explosivo") || other.CompareTag("laser"))
        {
            if (volador != null)
            {
                volador.GetComponent<EnemigoVolador>().canShoot = true;
                DestroyProjectile();
            }
        }
        if (other.CompareTag("Player"))
        {
            DealDamage();
            DestroyProjectile();
        }

        if (other.CompareTag("enemRod") && canCollide == true) 
        {
            if (volador != null)
            {
                other.GetComponent<EnemigoRodante>().lifes -= 1;
                volador.GetComponent<EnemigoVolador>().canShoot = true;
                DestroyProjectile();
            }
                
        }
        if (other.CompareTag("volador") && canCollide == true)
        {
            if (volador != null)
            {
                other.GetComponent<EnemigoVolador>().lifes -= 1;
                volador.GetComponent<EnemigoVolador>().canShoot = true;
                DestroyProjectile();
            }
                
        }

        if (other.CompareTag("soldado") && canCollide == true)
        {
            if (volador != null)
            {
                other.GetComponent<EnemigoSoldado>().lifes -= 1;
                volador.GetComponent<EnemigoVolador>().canShoot = true;
                DestroyProjectile();
            }
                
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("enemRod")|| collision.CompareTag("volador")|| collision.CompareTag("soldado"))
        {
            canCollide = true;
            volador = collision.gameObject;
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    void DealDamage()
    {
        Debug.Log("lavidaaaa");
        vidaCount.lifesValue -= 20;
    }
}