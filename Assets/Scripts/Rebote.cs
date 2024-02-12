using UnityEngine;

public class Rebote : MonoBehaviour
{
    Rigidbody2D rb;
    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Transp"))
        {
            transform.position = new Vector3(565f, -188.58f, 0);
            rb.velocity = new Vector2(0, 0);
        }
    }
}