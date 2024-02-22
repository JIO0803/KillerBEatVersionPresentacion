using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneControl : MonoBehaviour
{
    public GameObject Camera;
    public GameObject PauseButton;
    public GameObject ResumeButton;
    public GameObject Music1;
    public GameObject Music2;
    public GameObject Music3;
    public GameObject Track1;
    public GameObject Track2;
    public GameObject Track3;
    public GameObject Rain;
    public GameObject bigCredits;
    public GameObject credits;
    public GameObject optionsWindow;
    public GameObject mainMenu;
    public GameObject kunaiUpgradesWindow;
    public GameObject unckeckedToggle;
    public GameObject ckeckedToggle;
    public GameObject english;
    public GameObject inglés;
    public GameObject englisch;
    public GameObject wow;
    public GameObject boff;
    public GameObject nah;
    public GameObject kunaiUp3;
    public GameObject kunaiUp2;
    public GameObject kunaiUp1;
    public GameObject kunailvl1;
    public GameObject kunailvl2;
    public GameObject kunailvl3;
    public Image toggleImage;

    private AudioSource audSor1;
    private AudioSource audSor2;
    private AudioSource audSor3;
    private Volume vol;
    private reviveHamster rvhm;
    private bool isMusicPaused = false;
    [SerializeField] private int MusicCount;
    [SerializeField] private float music1PlaybackTime;
    [SerializeField] private float music2PlaybackTime;
    [SerializeField] private float music3PlaybackTime;
    private float languageCounter;
    private float qualityCounter;
    private float kunaiCount;

    void Start()
    {
        unckeckedToggle.SetActive(false);   
        ckeckedToggle.SetActive(true);
        rvhm = FindObjectOfType<reviveHamster>();
        audSor1 = Music1.GetComponent<AudioSource>();
        audSor2 = Music2.GetComponent<AudioSource>();
        audSor3 = Music3.GetComponent<AudioSource>();
        vol = Camera.GetComponent<Volume>();

        MusicCount = PlayerPrefs.GetInt("LastMusicSet", 1);
        SetMusicTrack();
        languageCounter = 0;
        music1PlaybackTime = PlayerPrefs.GetFloat("Music1PlaybackTime", 0f);
        music2PlaybackTime = PlayerPrefs.GetFloat("Music2PlaybackTime", 0f);
        music3PlaybackTime = PlayerPrefs.GetFloat("Music3PlaybackTime", 0f);
        languageCounter = PlayerPrefs.GetFloat("LanguageCounter", 0f);
        qualityCounter = PlayerPrefs.GetFloat("QualityCounter", 0f);
        kunaiCount = PlayerPrefs.GetFloat("kunaiCount", 0f);

        audSor1.time = music1PlaybackTime;
        audSor2.time = music2PlaybackTime;
        audSor3.time = music3PlaybackTime;

        audSor1.volume = 0.1f;
        audSor2.volume = 0.1f;
        audSor3.volume = 0.1f;

        bigCredits.SetActive(false);

        int rainingProb = Random.Range(1, 7);
        Rain.SetActive(rainingProb == 5);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            rvhm.ResetCounter();
        }

        if (MusicCount == 1)
        {
            Track1.SetActive(true);
            Track2.SetActive(false);
            Track3.SetActive(false);
        }
        else if (MusicCount == 2)
        {
            Track1.SetActive(false);
            Track2.SetActive(true);
            Track3.SetActive(false);
        }
        else if (MusicCount == 3)
        {
            Track1.SetActive(false);
            Track2.SetActive(false);
            Track3.SetActive(true);
        }

        if (audSor1.volume >= 0.8f || audSor2.volume >= 0.8f || audSor3.volume >= 0.8f)
        {
            audSor1.volume = 0.8f;
            audSor2.volume = 0.8f;
            audSor3.volume = 0.8f;
        }

        if (audSor1.volume <= 0f || audSor2.volume <= 0f || audSor3.volume <= 0f)
        {
            audSor1.volume = 0f;
            audSor2.volume = 0f;
            audSor3.volume = 0f;
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

        if (languageCounter < 0)
        {
            languageCounter = 2;
        }        
        
        if (languageCounter > 2)
        {
            languageCounter = 0;
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
        
        if (kunaiCount == 0)
        {
            kunaiUp1.SetActive(true);
            kunaiUp2.SetActive(false);
            kunaiUp3.SetActive(false);
            kunailvl1.SetActive(true);
            kunailvl2.SetActive(false);
            kunailvl3.SetActive(false);
        }        
        
        if (kunaiCount == 1)
        {
            kunaiUp1.SetActive(false);
            kunaiUp2.SetActive(true);
            kunaiUp3.SetActive(false);
            kunailvl1.SetActive(false);
            kunailvl2.SetActive(true);
            kunailvl3.SetActive(false);
        }        
        
        if (kunaiCount == 2)
        {
            kunaiUp1.SetActive(false);
            kunaiUp2.SetActive(false);
            kunaiUp3.SetActive(true);
            kunailvl1.SetActive(false);
            kunailvl2.SetActive(true);
            kunailvl3.SetActive(false);
        }

        if (qualityCounter < 0)
        {
            qualityCounter = 2;
        }        
        
        if (qualityCounter > 2)
        {
            qualityCounter = 0;
        }

        if (kunaiCount < 0)
        {
            kunaiCount = 0;
        }

        if (kunaiCount > 2)
        {
            kunaiCount = 2;
        }
    }

    void OnDestroy()
    {
        PlayerPrefs.SetInt("LastMusicSet", MusicCount);
        PlayerPrefs.SetFloat("Music1PlaybackTime", audSor1.time);
        PlayerPrefs.SetFloat("Music2PlaybackTime", audSor2.time);
        PlayerPrefs.SetFloat("Music3PlaybackTime", audSor3.time);
    }

    void SetMusicTrack()
    {
        Track1.SetActive(MusicCount == 1);
        Track2.SetActive(MusicCount == 2);
        Track3.SetActive(MusicCount == 3);
    }
    public void languageRightArrow()
    {
        languageCounter++;
    }

    public void languageLeftArrow()
    {
        languageCounter--;
    }

    public void qualityRightArrow()
    {
        qualityCounter++;
    }

    public void qualityLeftArrow()
    {
        qualityCounter--;
    }

    public void VolumeUp()
    {
        audSor1.volume += 0.02f;
        audSor2.volume += 0.02f;
        audSor3.volume += 0.02f;
    }

    public void VolumeDown()
    {
        audSor1.volume -= 0.02f;
        audSor2.volume -= 0.02f;
        audSor3.volume -= 0.02f;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void fullScreenOn()
    {
        Screen.fullScreen = true;
        unckeckedToggle.SetActive(false);
        ckeckedToggle.SetActive(true);
        Debug.Log("Si");
    }       
    public void fullScreenOff()
    {
        Screen.fullScreen = false;
        unckeckedToggle.SetActive(true);
        ckeckedToggle.SetActive(false);
        Debug.Log("No");
    }    


    public void StopMusic()
    {
        Debug.Log("Criteria");
    }

    public void NextSong()
    {
        MusicCount = (MusicCount % 3) + 1;
        SetMusicTrack();
    }

    public void ChangeLightDown()
    {
        vol.weight -= 0.1f;
        Debug.Log("Down");
    }

    public void ChangeLightUp()
    {
        vol.weight += 0.1f;
        Debug.Log("Up");
    }

    public void Credits()
    {
        bigCredits.SetActive(true);
        credits.SetActive(false);
    }

    public void CreditsBack()
    {
        bigCredits.SetActive(false);
        credits.SetActive(true);
    }

    public void OpenOptions()
    {
        optionsWindow.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void CloseOptions()
    {
        optionsWindow.SetActive(false);
        kunaiUpgradesWindow.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void PauseMusic()
    {
        PauseButton.SetActive(false);
        ResumeButton.SetActive(true);
        Debug.Log("Pause");
        audSor1.Pause();
        audSor2.Pause();
        audSor3.Pause();
        isMusicPaused = true;
    }

    public void ResumeMusic()
    {
        PauseButton.SetActive(true);
        ResumeButton.SetActive(false);
        Debug.Log("Resume");
        if (!isMusicPaused)
        {
            return;
        }
        audSor1.Play();
        audSor2.Play();
        audSor3.Play();
        isMusicPaused = false;
    }

    public void KunaiUpgrades()
    {
        mainMenu.SetActive(false);
        optionsWindow.SetActive(false);
        kunaiUpgradesWindow.SetActive(true);
    }

    public void AddKunai()
    {
        kunaiCount++;
        Debug.Log("awa");
    }

    public void MinusKunai()
    {
        kunaiCount--;
    }
}