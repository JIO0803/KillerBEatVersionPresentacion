using UnityEngine;

public class MovJugador : MonoBehaviour
{
    private Rigidbody2D rb;
    public float Velocidad = 5f;
    public float salto;
    public int saltos = 1;
    public int wallJumpForce = 10;
    public LayerMask capaPared;

    private Animator animator;
    public bool isWallSliding;
    public bool grounded;

    public float wallSlidingSpeed = 0.5f;

    private wallDetect wallDetection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        wallDetection = GetComponent<wallDetect>();
        isWallSliding = false;
        //gameObject.GetComponent<MovJugador>().enabled = false;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * Velocidad, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        RaycastHit2D raycastSuelo = Physics2D.Linecast(transform.position, transform.position + Vector3.down * 0.25f, capaPared);

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

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && saltos > 0)
        {
            if (isWallSliding)
            {
                if (wallDetection.isWallOnRight)
                {
                    // Jump left and up
                    rb.AddForce(new Vector2(-Velocidad * Mathf.Sqrt(2) / 2, salto * Mathf.Sqrt(2) / 2), ForceMode2D.Impulse);
                }
                else if (wallDetection.isWallOnLeft)
                {
                    // Jump right and up
                    rb.AddForce(new Vector2(Velocidad + 1 * Mathf.Sqrt(2) / 2, salto * Mathf.Sqrt(2) / 2), ForceMode2D.Impulse);
                }
            }
            else
            {
                // Jump straight up
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
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pared") && rb.velocity.y <= 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * wallSlidingSpeed);
            isWallSliding = true;
            saltos += 1;
        }
        else
        {
            isWallSliding = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pared"))
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
