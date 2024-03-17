using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.VFX;

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

        if (gameObject.tag == "cameraChange" && collision.CompareTag("Player"))
        {
            Cmara.GetComponent<Camera>().orthographicSize = 3f;
        }

        if (gameObject.tag == "cameraChange2" && collision.CompareTag("Player"))
        {
            Cmara.GetComponent<Camera>().orthographicSize = 7.4f;
        }
        if (gameObject.tag == "PosCam" && collision.CompareTag("Player"))
        {
            Cmara.GetComponent<Camera>().orthographicSize = 9.27f;
        }
    }
}