using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Tiempo : MonoBehaviour
{
    public GameObject cameraObject;
    public float SlowTime;
    public float timeSpeed;
    MovJugador movjugador;
    public GameObject player;
    void Start()
    {
        cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        movjugador = player.GetComponent<MovJugador>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || gameObject.GetComponent<MovJugador>().grounded == false) 
        {
            Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, Time.deltaTime * timeSpeed); 
            cameraObject.GetComponent<Volume>().weight = Mathf.Lerp(cameraObject.GetComponent<Volume>().weight, 0f, Time.deltaTime * timeSpeed);
            Time.fixedDeltaTime = Time.timeScale * 0.01f;
        }
        else
        {
            Time.timeScale = Mathf.Lerp(Time.timeScale, SlowTime, Time.deltaTime * timeSpeed); 
            cameraObject.GetComponent<Volume>().weight = Mathf.Lerp(cameraObject.GetComponent<Volume>().weight, 1f, Time.deltaTime * timeSpeed);
        }
    }
}