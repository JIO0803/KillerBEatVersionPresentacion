using UnityEngine;

public class Trampa : MonoBehaviour
{
    // Start is called before the first frame update
    vidaCount vc;

    private void Start()
    {
        vc = FindObjectOfType<vidaCount>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            vc.lifesValue -= 20;
        }
    }
}
