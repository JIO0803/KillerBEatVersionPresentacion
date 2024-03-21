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
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "tramp")
        {
            rb.velocity = Vector3.zero;
            transform.position = dispensador.transform.position;
        }
    }
}