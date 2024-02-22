using Pathfinding.Util;
using UnityEngine;

public class MovJugador : MonoBehaviour
{
    private Rigidbody2D rb;
    public float Velocidad = 5f;
    public float salto;
    public int saltos = 1;
    //[SerializeField] private int wallJumpForce = 10;
    public LayerMask capaPared;

    public Animator animator;
    public bool isWallSliding;
    public bool grounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isWallSliding = false;
        //gameObject.GetComponent<MovJugador>().enabled = false;
    }

    void Update()
    {
        Movimiento();
        if (grounded == true || isWallSliding == true)
        {
            animator.SetBool("IsGrounded", true);
        }
        if (grounded == false || isWallSliding == false)
        {
            animator.SetBool("IsGrounded", false);
        }
    }

    public void Movimiento()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
        RaycastHit2D raycastSuelo = Physics2D.Linecast(transform.position, transform.position + Vector3.down * 0.25f, capaPared);
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(horizontalInput * Velocidad, rb.velocity.y);
        }

        if (Input.GetKey(KeyCode.D) && !isWallSliding && !grounded)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
        if (Input.GetKey(KeyCode.A) && !isWallSliding && !grounded)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }

        if (grounded)
        {
            saltos = 1;
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
        if (!collision.isTrigger && collision.CompareTag("ground"))
        {
            grounded = true;
            rb.velocity = new Vector2 (0, rb.velocity.y);
        }

        if (collision.CompareTag("PosCam"))
        {
            gameObject.GetComponent<MovJugador>().enabled = true;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.isTrigger && collision.CompareTag("ground"))
        {
            grounded = true;
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (collision.CompareTag("PosCam"))
        {
            gameObject.GetComponent<MovJugador>().enabled = true;
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
