using UnityEngine;

public class MisilDirigido : MonoBehaviour
{
    public float speed;
    private Transform player;

    Rigidbody2D rb2D;
    [SerializeField] private float changingSpeed;
    [SerializeField] private bool Stop;
    [SerializeField] private bool canCollide = false;
    [SerializeField] private float rotationSpeed;

    public float startTimeBtwShots;
    public GameObject volador;
    vidaCount vc;
    
    private void Start()
    {
        vc = FindObjectOfType<vidaCount>();
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

            Vector2 directionToPlayer = player.position - transform.position;
            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
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
        if (other.CompareTag("Player") && other != null)
        {
            DealDamage();
            DestroyProjectile();
        }

        if (other.CompareTag("enemRod") && canCollide == true && other != null) 
        {
            if (volador != null && other != null)
            {

                other.GetComponent<EnemigoRodante>().lifes -= 1;
                volador.GetComponent<EnemigoVolador>().canShoot = true;
                DestroyProjectile();
            }
                
        }

        if (other.CompareTag("soldado") && canCollide == true && other != null)
        {
            if (volador != null && other != null)
            {
                other.GetComponent<EnemigoSoldado>().lifes -= 1;
                volador.GetComponent<EnemigoVolador>().canShoot = true;
                DestroyProjectile();
            }             
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("enemRod") && collision != null || collision.CompareTag("volador") && collision != null || collision.CompareTag("soldado") && collision != null)
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
        vc.lifesValue -= 1f;
    }
}