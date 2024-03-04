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
    private void Start()
    {
        sp = GetComponent<SpawnKunai>();
        animator = GetComponent<Animator>();
        mj = gameObject.GetComponent<MovJugador>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) && mj.saltos > 0 || Input.GetKeyDown(KeyCode.W)) && mj.saltos > 0)
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
            //animator.SetBool("IsFalling", true);
        }
        else if (rb.velocity.y < 0 || mj.grounded || mj.isWallSliding)
        {
            animator.SetBool("IsJumping", false);
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
        
        if (mj.isWallSliding)
        {
            if (sp == null)
            {
                animator.SetBool("IsSliding", true);
            }
            if (sp != null)
            {
                animator.SetBool("IsSlidingKunai", true);
            }
        }

        if (!mj.isWallSliding)
        {
            if (sp == null)
            {
                animator.SetBool("IsSliding", false);
            }
            if (sp != null)
            {
                animator.SetBool("IsSlidingKunai", false);
            }
        }
    }

    private void Salto()
    {
        if (mj.isWallSliding && isWallOnRight && !mj.grounded)
        {
            rb.AddForce(new Vector2(-10 * forceSumm * Mathf.Sqrt(2) / 2, mj.salto * newSaltoImpr * Mathf.Sqrt(2) / 2) * wallJumpForce, ForceMode2D.Impulse);
        }
        if  (mj.isWallSliding && isWallOnLeft)
        {
            rb.AddForce(new Vector2(10 * forceSumm * Mathf.Sqrt(2) / 2, mj.salto * newSaltoImpr * Mathf.Sqrt(2) / 2) * wallJumpForce, ForceMode2D.Impulse);
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
        }
        else if (isWallOnRight && !mj.grounded)
        {
            mj.isWallSliding = true;
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }
    }
}
