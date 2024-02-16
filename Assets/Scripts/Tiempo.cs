using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Tiempo : MonoBehaviour
{
    public GameObject cameraObject;
    public Volume cameraVolume;
    public float SlowTime;
    public float timeSpeed;
    public GameObject player;
    MovJugador movJug;

    void Start()
    {
        cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        cameraVolume = cameraObject.GetComponent<Volume>();
        movJug = gameObject.GetComponent<MovJugador>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) 
            || movJug.grounded == false && movJug.isWallSliding == false)
        {
            Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, Time.deltaTime * timeSpeed);
            cameraVolume.weight = Mathf.Lerp(cameraVolume.weight, 0f, Time.deltaTime * timeSpeed);
            Time.fixedDeltaTime = Time.timeScale * 0.01f;
        }
        else
        {
            Time.timeScale = Mathf.Lerp(Time.timeScale, SlowTime, Time.deltaTime * timeSpeed);
            cameraVolume.weight = Mathf.Lerp(cameraVolume.weight, 1f, Time.deltaTime * timeSpeed);
        }
    }
}
