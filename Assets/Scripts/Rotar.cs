using UnityEngine;

public class Rotar : MonoBehaviour
{
    public bool canRotate = false;
    public float rotationSpeed = 10f;
    public float rotationSpeed2 = 10f;
    [SerializeField] private Transform[] _Rotador;

    private void Update()
    {
        if (canRotate)
        {
            if (Input.GetKey(KeyCode.E))
            {
                RotateObjects(-rotationSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                RotateObjects(rotationSpeed * Time.deltaTime);
            }
        }
        if (!Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.E))
        {
            RotateObjects(rotationSpeed2 * Time.deltaTime);
        }
    }

    private void RotateObjects(float angle)
    {
        foreach (Transform rotador in _Rotador)
        {
            rotador.Rotate(Vector3.forward * angle);
        }

        if (canRotate== true && Input.GetKey(KeyCode.Q) || canRotate == true && Input.GetKey(KeyCode.E))
        {
            this.gameObject.transform.Rotate(Vector3.forward * angle);
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
        canRotate = false;
    }
}