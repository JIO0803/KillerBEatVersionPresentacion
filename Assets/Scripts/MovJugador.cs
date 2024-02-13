using System.Collections;
using UnityEngine;

public class MovJugador : MonoBehaviour
{
    private Rigidbody2D rb;
    public float Velocidad = 5f;
    public float salto;
    public int saltos = 1;
    public LayerMask Enviroment;

    private Animator animator;
    public bool isWallSliding;
    public bool grounded;

    public float wallSlidingSpeed = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //gameObject.GetComponent<MovJugador>().enabled = false;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * Velocidad, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        RaycastHit2D raycastSuelo = Physics2D.Raycast(transform.position, Vector2.down, 0.25f, Enviroment);

        if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        if (Input.GetKey(KeyCode.D) && isWallSliding && !grounded)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
        if (Input.GetKey(KeyCode.A) && isWallSliding && !grounded)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)))
        {
            if (isWallSliding)
            {
                rb.velocity = new Vector2(25 * -horizontalInput, 25);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, salto);
            }
            saltos -= 1;
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

        if (grounded == true || isWallSliding == true)
        {
            animator.SetBool("IsGrounded", true);
        }
        if (grounded == false || isWallSliding == false)
        {
            animator.SetBool("IsGrounded", false);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger && collision.CompareTag("ground"))
        {
            grounded = true;
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
        }
        if (collision.CompareTag("PosCam"))
        {
            gameObject.GetComponent<MovJugador>().enabled = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pared") && rb.velocity.y <= 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * wallSlidingSpeed);
            isWallSliding = true;
            saltos += 1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pared"))
        {
            isWallSliding = false;
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
