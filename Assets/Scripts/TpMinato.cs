using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpMinato : MonoBehaviour
{
    public GameObject Kunai;

    public void Minato()
    {
        gameObject.transform.position = Kunai.transform.position;
    }
}
