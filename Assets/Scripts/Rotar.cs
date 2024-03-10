using UnityEngine;

public class Rotar : MonoBehaviour
{
    public bool canRotate = false;
    public float rotationSpeed = 10f;
    public float rotationSpeed2 = 10f;
    public GameObject Plat;

    private void Update()
    {
        RotateObjects();
    }

    private void RotateObjects()
    {   
        if (canRotate == true && Input.GetKey(KeyCode.LeftShift))
        {
            Plat.transform.Rotate(Vector3.forward * -rotationSpeed * Time.deltaTime * 2);
            this.gameObject.transform.Rotate(Vector3.forward * 0.5f);
        }
        else
        {
            Plat.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime * 2);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canRotate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canRotate = false;
        }
    }
}