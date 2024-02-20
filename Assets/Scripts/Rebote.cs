using UnityEngine;

public class Rebote : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject dispensador;
    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Transp"))
        {
            transform.position = dispensador.transform.position;
            rb.velocity = new Vector2(0, 0);
        }
    }
}