using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Tiempo : MonoBehaviour
{
    public GameObject cameraObject;
    public Volume cameraVolume;
    [SerializeField] private float SlowTime;
    [SerializeField] private float timeSpeed;
    public GameObject player;
    MovJugador movJug;
    wallDetect wd;

    void Start()
    {
        cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        cameraVolume = cameraObject.GetComponent<Volume>();
        movJug = gameObject.GetComponent<MovJugador>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) 
            || !movJug.grounded || movJug.isWallSliding)
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
