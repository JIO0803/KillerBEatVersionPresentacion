using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class inGameManager : MonoBehaviour
{
    public GameObject menu;
    public float languageCounter;
    private bool menuIsActive;
    public Sprite checkedToggle;
    public Sprite uncheckedToggle;
    public Image toggleImage;

    public GameObject Player;
    public GameObject unckeckedToggle;
    public GameObject ckeckedToggle;

    SpawnKunai sp;
    MovJugador mj;
    private int qualityCounter;

    public GameObject wow;
    public GameObject boff;
    public GameObject nah;

    //Languages
    public GameObject ingles;
    public GameObject español;
    public GameObject aleman;
    public GameObject italiano;
    public GameObject frances;
    public GameObject portugues;

    public float defaultVolume = 0.05f;

    AudioSource audioSource;
    public GameObject slider;
    Slider sli;
    GameObject musicManager;
    AudioSource aud;

    void Start()
    {


        musicManager = GameObject.FindGameObjectWithTag("MusicMan");

        GameObject[] gladosObjects = GameObject.FindGameObjectsWithTag("Glados");

        foreach (GameObject gladosObject in gladosObjects)
        {
            AudioSource gladosAudioSource = gladosObject.GetComponent<AudioSource>();
            if (gladosAudioSource != null)
            {
                gladosAudioSource.volume = defaultVolume;

            }
        }

        aud = musicManager.GetComponent<AudioSource>();
        sli = slider.GetComponent<Slider>();
        audioSource = musicManager.GetComponent<AudioSource>();
        audioSource.volume = 0.05f;
        sli.value = 0.05f;

        unckeckedToggle.SetActive(false);
        ckeckedToggle.SetActive(true);
        mj = Player.GetComponent<MovJugador>();
        sp = Player.GetComponent<SpawnKunai>(); 
        menuIsActive = false;
        menu.SetActive(false);

        languageCounter = PlayerPrefs.GetFloat("LanguageCounter", 0f);
        qualityCounter = PlayerPrefs.GetInt("QualityCounter", 0);
        languageCounter = 0;

        PlayerPrefs.GetInt("KunaiUnlocked", 0);
        PlayerPrefs.GetInt("TPUnlocked", 0);
        if (PlayerPrefs.HasKey("SliderVolume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("SliderVolume");
            sli.value = savedVolume;
            SetGladosVolume(savedVolume);
        }
    }

    void Update()
    {
        if (sli.value != PlayerPrefs.GetFloat("SliderVolume"))
        {
            float sliderValue = sli.value;
            PlayerPrefs.SetFloat("SliderVolume", sliderValue);
            SetGladosVolume(sliderValue);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuIsActive)
            {
                CloseMenu();
            }
            else
            {
                OpenMenu();
            }
        }

        if (qualityCounter < 0)
        {
            qualityCounter = 2;
        }

        if (qualityCounter > 2)
        {
            qualityCounter = 0;
        }

        if (languageCounter == 0)
        {
            ingles.SetActive(true);
            aleman.SetActive(false);
            español.SetActive(false);
            italiano.SetActive(false);
            frances.SetActive(false);
            portugues.SetActive(false);
        }

        if (languageCounter == 1)
        {
            ingles.SetActive(false);
            aleman.SetActive(true);
            español.SetActive(false);
            italiano.SetActive(false);
            frances.SetActive(false);
            portugues.SetActive(false);
        }

        if (languageCounter == 2)
        {
            ingles.SetActive(false);
            aleman.SetActive(false);
            español.SetActive(true);
            italiano.SetActive(false);
            frances.SetActive(false);
            portugues.SetActive(false);
        }

        if (languageCounter == 3)
        {
            ingles.SetActive(false);
            aleman.SetActive(false);
            español.SetActive(false);
            italiano.SetActive(true);
            frances.SetActive(false);
            portugues.SetActive(false);
        }

        if (languageCounter == 4)
        {
            ingles.SetActive(false);
            aleman.SetActive(false);
            español.SetActive(false);
            italiano.SetActive(false);
            frances.SetActive(true);
            portugues.SetActive(false);
        }

        if (languageCounter == 5)
        {
            ingles.SetActive(false);
            aleman.SetActive(false);
            español.SetActive(false);
            italiano.SetActive(false);
            frances.SetActive(false);
            portugues.SetActive(true);
        }

        if (languageCounter < 0)
        {
            languageCounter = 5;
        }

        if (languageCounter > 5)
        {
            languageCounter = 0;
        }

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("Game");
        }

        if (qualityCounter == 0)
        {
            wow.SetActive(true);
            boff.SetActive(false);
            nah.SetActive(false);
        }

        if (qualityCounter == 1)
        {
            wow.SetActive(false);
            boff.SetActive(true);
            nah.SetActive(false);
        }

        if (qualityCounter == 2)
        {
            wow.SetActive(false);
            boff.SetActive(false);
            nah.SetActive(true);
        }
    }

    void SetGladosVolume(float volume)
    {
        GameObject[] gladosObjects = GameObject.FindGameObjectsWithTag("Glados");
        foreach (GameObject gladosObject in gladosObjects)
        {
            AudioSource gladosAudioSource = gladosObject.GetComponent<AudioSource>();
            if (gladosAudioSource != null)
            {
                gladosAudioSource.volume = volume;
            }
        }
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene("Game");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void qualityRightArrow()
    {
        qualityCounter++;
    }

    public void qualityLeftArrow()
    {
        qualityCounter--;
    }

    public void fullScreenOn1()
    {
        StartCoroutine(fullScreenOn());
    }
    public void fullScreenOff1()
    {
        StartCoroutine(fullScreenOff());
    }

    public void RightArrow()
    {
        languageCounter++;
    }
    public void LeftArrow()
    {
        languageCounter--;
    }

    public void OpenMenu()
    {
        aud.volume = 0.005f;
        menuIsActive = true;
        menu.SetActive(true);
        Time.timeScale = 0;
        sp.enabled = false;
        mj.enabled = false;
    }

    public void CloseMenu()
    {
        Time.timeScale = 0.5f;
        aud.volume = 0.03f;
        menuIsActive = false;
        menu.SetActive(false);
        sp.enabled = true;
        mj.enabled = true;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
        PlayerPrefs.Save();
    }

    private IEnumerator fullScreenOn()
    {
        yield return new WaitForSecondsRealtime(0.01f);
        {
            Screen.fullScreen = true;
            unckeckedToggle.SetActive(false);
            ckeckedToggle.SetActive(true);
        }
    }    
    
    private IEnumerator fullScreenOff()
    {
        yield return new WaitForSecondsRealtime(0.01f);
        {
            Screen.fullScreen = false;
            unckeckedToggle.SetActive(true);
            ckeckedToggle.SetActive(false);
        }
    }
}
