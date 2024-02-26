using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    vidaCount vc;

    private void Start()
    {
        vc = FindObjectOfType<vidaCount>();

    }
    void Update()
    {
        if (vc.lifesValue == 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
