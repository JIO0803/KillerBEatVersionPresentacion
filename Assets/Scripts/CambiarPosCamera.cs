using UnityEngine;

public class CambiarPosCamera : MonoBehaviour
{
    public GameObject Cmara;
    public GameObject sala;

    private void Start()
    {
        sala.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Cmara.transform.position = gameObject.transform.position;
            sala.SetActive(true);
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