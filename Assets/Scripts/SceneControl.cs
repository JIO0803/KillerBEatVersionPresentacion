using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public GameObject Camera;
    //Music
    public GameObject PauseButton;
    public GameObject ResumeButton;
    public GameObject Music1;
    public GameObject Music2;
    public GameObject Music3;
    public GameObject Track1;
    public GameObject Track2;
    public GameObject Track3;
    public GameObject Rain;
    AudioSource audSor1;
    AudioSource audSor2;
    AudioSource audSor3;
    public int MusicCount;
    public int MusicSet;
    public int Raining;
    private float music1PlaybackTime;
    private float music2PlaybackTime;
    private float music3PlaybackTime;
    private bool isMusicPaused = false;
    //Buttons
    public GameObject credits;
    public GameObject bigCredits;
    public GameObject playButton;
    public GameObject optionButton;
    public GameObject turnOffButton;
    public GameObject newsButton;
    //Hamster
    public GameObject hamsterReviver;
    reviveHamster rvhm;
    //Other
    Volume vol;
    //Menus
    public GameObject optionsWindow;

    void Start()
    {
        rvhm = hamsterReviver.GetComponent<reviveHamster>();
        PauseButton.SetActive(true);
        audSor1 = Music1.GetComponent<AudioSource>();
        audSor2 = Music2.GetComponent<AudioSource>();
        audSor3 = Music3.GetComponent<AudioSource>();

        vol = Camera.GetComponent<Volume>();

        MusicCount = PlayerPrefs.GetInt("LastMusicSet", 1);
        SetMusicTrack();

        music1PlaybackTime = PlayerPrefs.GetFloat("Music1PlaybackTime", 0f);
        music2PlaybackTime = PlayerPrefs.GetFloat("Music2PlaybackTime", 0f);
        music3PlaybackTime = PlayerPrefs.GetFloat("Music3PlaybackTime", 0f);

        audSor1.time = music1PlaybackTime;
        audSor2.time = music2PlaybackTime;
        audSor3.time = music3PlaybackTime;

        audSor1.volume = 0.1f;
        audSor2.volume = 0.1f;
        audSor3.volume = 0.1f;

        bigCredits.SetActive(false);

        int rainingProb = Random.Range(1, 7);

        if (rainingProb == 5)
        {
            Rain.SetActive(true);
        }
        else
        {
            Rain.SetActive(false);
        }
    }


    private void Update()
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
        if (MusicCount == 2)
        {
            Track1.SetActive(false);
            Track2.SetActive(true);
            Track3.SetActive(false);
        } 
        if (MusicCount == 3)
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
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("LastMusicSet", MusicCount);

        PlayerPrefs.SetFloat("Music1PlaybackTime", audSor1.time);
        PlayerPrefs.SetFloat("Music2PlaybackTime", audSor2.time);
        PlayerPrefs.SetFloat("Music3PlaybackTime", audSor3.time);
    }
    void SetMusicTrack()
    {
        Track1.SetActive(false);
        Track2.SetActive(false);
        Track3.SetActive(false);

        switch (MusicCount)
        {
            case 1:
                Track1.SetActive(true);
                break;
            case 2:
                Track2.SetActive(true);
                break;
            case 3:
                Track3.SetActive(true);
                break;
        }
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
    
    public void fullScreen(bool is_fullscene)
    {
        Screen.fullScreen = is_fullscene;
        Debug.Log("isFullScreen" + is_fullscene);
    }

    public void StopMusic()
    {
        Debug.Log("Criteria");
    }

    public void NextSong()
    {
        MusicCount++;
        if (MusicCount > 3)
        {
            MusicCount = 1;
        }
    }

    public void News()
    {
        Debug.Log("Criteria");
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

    public void InspectKunai()
    {
        Debug.Log("Criteria");
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
        playButton.SetActive(false);
        optionButton.SetActive(false);
        turnOffButton.SetActive(false);
        newsButton.SetActive(false);
    }    
    public void CloseOptions()
    {
        playButton.SetActive(true);
        optionButton.SetActive(true);
        turnOffButton.SetActive(true);
        newsButton.SetActive(true);
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
}