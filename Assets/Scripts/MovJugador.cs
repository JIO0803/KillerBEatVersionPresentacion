using UnityEngine;

public class MovJugador : MonoBehaviour
{
    public Rigidbody2D rb;
    public float Velocidad = 5f;
    public float salto;
    public int saltos = 1;
    //[SerializeField] private int wallJumpForce = 10;
    public LayerMask capaPared;

    Animator animator;
    public bool isWallSliding;
    public bool grounded;
    wallDetect wd;
    void Start()
    {
        wd = GetComponent<wallDetect>();
        rb = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        isWallSliding = false;
    }

    void Update()
    {
        Movimiento();
    }

    public void Movimiento()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        //animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        RaycastHit2D raycastSuelo = Physics2D.Linecast(transform.position, transform.position + Vector3.down * 0.25f, capaPared);
        if (Input.GetKey(KeyCode.D) && !wd.isWallOnRight|| Input.GetKey(KeyCode.A) && !wd.isWallOnLeft)
        {
            rb.velocity = new Vector2(horizontalInput * Velocidad, rb.velocity.y);
        }        
       
        if (Input.GetKey(KeyCode.D) && !isWallSliding)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);          
        }
        if (Input.GetKey(KeyCode.A) && !isWallSliding)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        if (Input.GetKey(KeyCode.A) && !isWallSliding && grounded && !Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.D) && !isWallSliding && grounded && !Input.GetKey(KeyCode.A))
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
    }

    public void FixedUpdate()
    {
        if (grounded)
        {
            saltos = 1;
            animator.SetBool("IsSliding", false);
            animator.SetBool("IsSlidingKunai", false);
        }

        if (saltos > 1)
        {
            saltos = 1;
        }

        if (saltos < 0)
        {
            saltos = 0;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("pared") || collision.CompareTag("ground") || (collision.CompareTag("enemRod") || collision.CompareTag("botonAct")
        || collision.CompareTag("volador") || collision.CompareTag("soldado") || collision.CompareTag("enemy") || collision.CompareTag("headShot")))
        {
            if (gameObject != null)
            {
                grounded = true;
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("pared") || collision.CompareTag("ground") || (collision.CompareTag("enemRod") || collision.CompareTag("botonAct")
        || collision.CompareTag("volador") || collision.CompareTag("soldado") || collision.CompareTag("enemy") || collision.CompareTag("headShot")))
        {
            grounded = true;
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            grounded = false;
        }
    }
}