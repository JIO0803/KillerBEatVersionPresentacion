using UnityEngine;

public class Trampa : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {
            vidaCount.lifesValue -= 20;
        }
    }
}
