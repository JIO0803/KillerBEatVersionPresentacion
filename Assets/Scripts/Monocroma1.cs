using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class Monocroma1 : MonoBehaviour
{
    public GameObject Camera;
    public float DetenerSlow;
    public float ActivarSlow;
    public float stopTimecd;
    public float slowMo;
    public bool stopTime;
    Rigidbody2D rb2D;
    Beatlvl1 Beat1;
    VidaPers1 vidaPers1;
    public bool Stop;
    public bool Cancelar;
    Volume volumen;
    void Start()
    {
        stopTime = true;
        rb2D = GetComponent<Rigidbody2D>();
        Beat1 = GetComponent<Beatlvl1>();
        vidaPers1 = GetComponent<VidaPers1>();
        volumen = Camera.GetComponent<Volume>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && volumen.weight == 0 || Input.GetKeyDown(KeyCode.LeftShift) && volumen.weight == 0.3f)
        {
            StartCoroutine(ControlarTiempo(Camera));
            StartCoroutine(stoppingTime(Camera));
            stopTime = false;
            Cancelar = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && volumen.weight == 1 && Cancelar == false)
        {
            Debug.Log("Estamos");
            Time.timeScale = 1;
            volumen.weight = 0;
            Cancelar = true;
        }

        if (volumen.weight == 1)
        {
            rb2D.gravityScale = 2f;
            rb2D.velocity = new Vector2(rb2D.velocity.x, -3);
            Time.timeScale = slowMo;
            Time.fixedDeltaTime = Time.timeScale * 0.01f;
            Beat1.enabled = false;
            vidaPers1.enabled = false;
        }

        if (volumen.weight == 0 || volumen.weight == 0.3f)
        {
            Beat1.enabled = true;
            vidaPers1.enabled = true;
            rb2D.gravityScale = 5f;
            Time.timeScale = 1f;
        }
    }
    IEnumerator ControlarTiempo(GameObject Camera)
    {
        yield return new WaitForSeconds(ActivarSlow);
        {
            Stop = true;
            volumen.weight = 1;
        }

        yield return new WaitForSeconds(DetenerSlow);
        {
            Stop = false;
            volumen.weight = 0.3f;
        }
    }      
    IEnumerator stoppingTime(GameObject Camera)
    {
        yield return new WaitForSeconds(stopTimecd);
        {
            stopTime = false;
        }
        yield return new WaitForSeconds(stopTimecd + 5f);
        {
            stopTime = true;
        }
    }
}