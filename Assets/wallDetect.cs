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
    private void Start()
    {
        mj = gameObject.GetComponent<MovJugador>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, raycastDistance, Pared);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, raycastDistance, Pared);

        isWallOnLeft = hitLeft.collider != null;
        isWallOnRight = hitRight.collider != null;

        Debug.DrawRay(transform.position, Vector2.left * raycastDistance, isWallOnLeft ? Color.red : Color.green);
        Debug.DrawRay(transform.position, Vector2.right * raycastDistance, isWallOnRight ? Color.red : Color.green);

        if (isWallOnLeft && !mj.grounded)
        {
            mj.isWallSliding = true;
            transform.localScale = new Vector2(1, transform.localScale.y);
        }       
        
        if (isWallOnRight && !mj.grounded)
        {
            mj.isWallSliding = true;
            transform.localScale = new Vector2(-1, transform.localScale.y);
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && mj.saltos > 0)
        {
            if (mj.isWallSliding && isWallOnRight)
            {
                rb.AddForce(new Vector2(-mj.Velocidad * forceSumm * Mathf.Sqrt(2) / 2, mj.salto * newSaltoImpr * Mathf.Sqrt(2) / 2) * wallJumpForce, ForceMode2D.Impulse);
            }
            if (mj.isWallSliding && isWallOnLeft)
            {
                rb.AddForce(new Vector2(mj.Velocidad * forceSumm * Mathf.Sqrt(2) / 2, mj.salto * newSaltoImpr * Mathf.Sqrt(2) / 2) * wallJumpForce, ForceMode2D.Impulse);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, mj.salto);
            }
            mj.saltos -= 1;
        }

        if (isWallOnLeft && rb.velocity.y <= 0 || isWallOnRight && rb.velocity.y <= 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * wallSlidingSpeed);
            mj.isWallSliding = true;
            mj.saltos += 1;
        }
        else
        {
            mj.isWallSliding = false;
        }

        if (mj.isWallSliding && !Input.GetKey(KeyCode.D) || mj.isWallSliding && !Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

    }
}
