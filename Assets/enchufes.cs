using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enchufes : MonoBehaviour
{
    public GameObject enchufe1Desconectado;
    public GameObject enchufe2Desconectado;
    public GameObject mainmenu;
    public GameObject options;
    public GameObject blackScreen;
    public GameObject boton1;
    public GameObject boton2;
    SceneControl sc;
    // Start is called before the first frame update
    void Start()
    {
        sc = GetComponent<SceneControl>();
        enchufe1Desconectado.SetActive(false);
        enchufe2Desconectado.SetActive(false);
        blackScreen.SetActive(false);
        mainmenu.SetActive(true);
    }

    public void desenchufar1()
    {
        enchufe1Desconectado.SetActive(true);
        boton1.SetActive(false);
        sc.canPlay = false;
    }   
    public void enchufar1()
    {
        if (sc.isMusicPaused)
        {
            sc.PauseButton.SetActive(false);
            sc.ResumeButton.SetActive(true);
        }
        if (!sc.isMusicPaused)
        {
            sc.PauseButton.SetActive(true);
            sc.ResumeButton.SetActive(false);
        }
        enchufe1Desconectado.SetActive(false);
        boton1.SetActive(true);
    }    
    public void desenchufar2()
    {
        enchufe2Desconectado.SetActive(true);
        sc.activado = false;
        blackScreen.SetActive(true);
        boton2.SetActive(false);
    }   
    public void enchufar2()
    {
        enchufe2Desconectado.SetActive(false);
        blackScreen.SetActive(false);
        mainmenu.SetActive(true);
        options.SetActive(false);
        sc.activado = true;
        boton2.SetActive(true);
    }
}