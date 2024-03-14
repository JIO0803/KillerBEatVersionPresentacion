using UnityEngine;

public class wallDetect : MonoBehaviour
{
    public LayerMask Pared;
    public float raycastDistance = 0.1f;
    public bool isWallOnLeft { get; private set; }
    public bool isWallOnRight { get; private set; }
    public float wallSlidingSpeed = 0.5f;
    public float wallJumpForce;
    public float forceSumm;
    public float newSaltoImpr;
    MovJugador mj;
    Rigidbody2D rb;
    Animator animator;
    SpawnKunai sp;
    NumeroDeKunais nk;
    vidaCount vc;
    public GameObject numeroDeKunais;

    // Tiempo de desactivación del script del jugador después de saltar desde la pared
    public float tiempoDesactivacion = 1f;
    private bool desactivarMovimiento = false;

    private void Start()
    {
        vc = GetComponent<vidaCount>();
        nk = numeroDeKunais.GetComponent<NumeroDeKunais>();
        sp = GetComponent<SpawnKunai>();
        animator = GetComponent<Animator>();
        mj = gameObject.GetComponent<MovJugador>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (desactivarMovimiento)
        {
            mj.enabled = false;
        }   
        
        if (!desactivarMovimiento && vc.free)
        {
            mj.enabled = true;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && mj.saltos > 0)
        {
            Salto();
            mj.saltos -= 1;
        }

        WallSlider();
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, raycastDistance, Pared);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, raycastDistance, Pared);

        isWallOnLeft = hitLeft.collider != null;
        isWallOnRight = hitRight.collider != null;

        if (rb.velocity.y > 0 && !mj.grounded && !mj.isWallSliding)
        {
            animator.SetBool("IsJumping", true);
            animator.SetBool("IsFalling", false);
        }
        if (rb.velocity.y < 0 && !mj.grounded && !mj.isWallSliding)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", true);
            animator.SetBool("IsSliding", false);
            animator.SetBool("IsSlidingKunai", false);
        }
        if (mj.grounded || mj.isWallSliding)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", false);
        }

        if (mj.isWallSliding)
        {
            if (!sp.enabled && !mj.grounded || !nk.hasKunai && !mj.grounded)
            {
                animator.SetBool("IsSliding", true);
            }
            if (sp.enabled && !mj.grounded || nk.hasKunai && !mj.grounded)
            {
                animator.SetBool("IsSlidingKunai", true);
            }
        }

        if (!mj.isWallSliding)
        {
            animator.SetBool("IsSliding", false);
            animator.SetBool("IsSlidingKunai", false);
        }
    }

    private void FixedUpdate()
    {
        if (isWallOnLeft && rb.velocity.y <= 0 && !Input.GetKey(KeyCode.D) || isWallOnRight && rb.velocity.y <= 0 && !Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(0, rb.velocity.y * wallSlidingSpeed);
            mj.isWallSliding = true;
            mj.saltos += 1;
        }
        else
        {
            mj.isWallSliding = false;
        }
    }

    private void Salto()
    {
        if (mj.isWallSliding && !mj.grounded)
        {
            desactivarMovimiento = true;
            Invoke("ActivarMovimiento", tiempoDesactivacion);
            int direction = isWallOnRight ? -1 : 1;
            rb.velocity = new Vector2(direction * wallJumpForce, forceSumm);
            mj.saltos -= 1;
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, mj.salto);
        }
    }

    private void WallSlider()
    {
        if (isWallOnLeft && !mj.grounded)
        {
            mj.isWallSliding = true;
            transform.localScale = new Vector2(1, transform.localScale.y);
            mj.animator.SetBool("IsRunning", false);
        }
        else if (isWallOnRight && !mj.grounded)
        {
            mj.isWallSliding = true;
            transform.localScale = new Vector2(-1, transform.localScale.y);
            mj.animator.SetBool("IsRunning", false);
        }
        if (isWallOnLeft && mj.grounded || isWallOnRight && mj.grounded)
        {
            mj.isWallSliding = false;
            transform.localScale = transform.localScale;
            mj.animator.SetBool("IsRunning", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "pared")
        {
            CancelInvoke("ActivarMovimiento");
            Invoke("ActivarMovimiento", 0);
        }
    }

    // Método para activar el movimiento del jugador después de un tiempo específico
    private void ActivarMovimiento()
    {
        desactivarMovimiento = false;
    }
}
