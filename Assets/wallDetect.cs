using UnityEngine;

public class wallDetect : MonoBehaviour
{
    public LayerMask Pared; 
    public float raycastDistance = 0.1f; 
    public bool isWallOnLeft { get; private set; } 
    public bool isWallOnRight { get; private set; } 

    void Update()
    {
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, raycastDistance, Pared);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, raycastDistance, Pared);

        isWallOnLeft = hitLeft.collider != null;
        isWallOnRight = hitRight.collider != null;

        Debug.DrawRay(transform.position, Vector2.left * raycastDistance, isWallOnLeft ? Color.red : Color.green);
        Debug.DrawRay(transform.position, Vector2.right * raycastDistance, isWallOnRight ? Color.red : Color.green);

        if (isWallOnLeft)
        {
            Debug.Log("wallLeft");
        }       
        
        if (isWallOnRight)
        {
            Debug.Log("wallRight");
        }
    }
}
