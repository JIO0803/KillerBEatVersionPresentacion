using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class inGameManager : MonoBehaviour
{
    public GameObject menu;
    public float languageCounter;
    public GameObject english;
    public GameObject inglés;
    public GameObject englisch;
    private bool menuIsActive;
    public Sprite checkedToggle;
    public Sprite uncheckedToggle;
    public Image toggleImage;
    public GameObject musicManager;
    AudioSource audioSource;
    void Start()
    {
        menuIsActive = false;
        menu.SetActive(false);

        languageCounter = PlayerPrefs.GetFloat("LanguageCounter", 0f);
        languageCounter = 0;
        audioSource = musicManager.GetComponent<AudioSource>();
    }

    void Update()
    {
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

        if (languageCounter == 0)
        {
            english.SetActive(true);
            englisch.SetActive(false);
            inglés.SetActive(false);
        }

        if (languageCounter == 1)
        {
            english.SetActive(false);
            englisch.SetActive(true);
            inglés.SetActive(false);
        }

        if (languageCounter == 2)
        {
            english.SetActive(false);
            englisch.SetActive(false);
            inglés.SetActive(true);
        }

        languageCounter = Mathf.Clamp(languageCounter, 0f, 2f);

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("Game");
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

    public void fullScreen(bool is_fullscene)
    {
        Screen.fullScreen = is_fullscene;
        toggleImage.sprite = is_fullscene ? checkedToggle : uncheckedToggle;
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
        audioSource.volume = 0.005f;
        menuIsActive = true;
        menu.SetActive(true);
    }

    public void CloseMenu()
    {
        audioSource.volume = 0.03f;
        menuIsActive = false;
        menu.SetActive(false);
    }
}
