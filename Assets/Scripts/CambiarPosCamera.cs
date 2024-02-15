using UnityEngine;

public class CambiarPosCamera : MonoBehaviour
{
    public GameObject Cmara;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Cmara.transform.position = gameObject.transform.position;
        }
    }  
    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Cmara.transform.position = gameObject.transform.position;
        }
    }
}