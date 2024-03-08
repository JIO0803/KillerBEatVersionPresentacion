using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoothfollow : MonoBehaviour
{
    public Transform follow;
    public Vector3 offset;
    public float velocidad;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, follow.position + offset, velocidad * Time.deltaTime);

        if (gameObject.transform.position != new Vector3 (follow.position.x, follow.position.y, -10))
        {
            gameObject.transform.position = new Vector3(follow.position.x, follow.position.y, -10);
        }
    }
}
