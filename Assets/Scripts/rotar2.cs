using UnityEngine;

public class Rotar2 : MonoBehaviour
{
    public bool canRotate = false;
    public float rotationSpeed = 500;
    [SerializeField] private Transform[] _Rotador;

    private void Update()
    {
        if (canRotate)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                RotateObjects(-rotationSpeed * Time.deltaTime);
            }
        }
    }

    private void RotateObjects(float angle)
    {
        foreach (Transform rotador in _Rotador)
        {
            rotador.Rotate(Vector3.forward * angle);
        }
        if (canRotate == true && Input.GetKey(KeyCode.LeftShift))
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