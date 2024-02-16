using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public GameObject PauseButton;
    public GameObject ResumeButton;
    public GameObject Music1;
    public GameObject Music2;
    public GameObject Music3;
    AudioSource audSor1;
    AudioSource audSor2;
    AudioSource audSor3;
    public int MusicCount;
    public GameObject Track1;
    public GameObject Track2;
    public GameObject Track3;

    private void Awake()
    {
        PauseButton.SetActive(false);
        audSor1 = Music1.GetComponent<AudioSource>();
        audSor2 = Music2.GetComponent<AudioSource>();
        audSor3 = Music3.GetComponent<AudioSource>();
        MusicCount = 1;

        audSor1.volume = 0.2f;
        audSor2.volume = 0.2f;
        audSor3.volume = 0.2f;
    }

    private void Update()
    {
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

    public void VolumeUp()
    {
        audSor1.volume += 0.05f;
        audSor2.volume += 0.05f;
        audSor3.volume += 0.05f;
    }

    public void VolumeDown()
    {
        audSor1.volume -= 0.05f;
        audSor2.volume -= 0.05f;
        audSor3.volume -= 0.05f;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
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

    public void ChangeLight()
    {
        Debug.Log("Criteria");
    }

    public void InspectKunai()
    {
        Debug.Log("Criteria");
    }

    public void PauseMusic()
    {
        PauseButton.SetActive(false);
        ResumeButton.SetActive(true);
        Debug.Log("Stop");
        audSor1.enabled = false;
        audSor2.enabled = false;
        audSor3.enabled = false;
    }

    public void ResumeMusic()
    {
        PauseButton.SetActive(true);
        ResumeButton.SetActive(false);
        Debug.Log("Go");
        audSor1.enabled = true;
        audSor2.enabled = true;
        audSor3.enabled = true;
    }
}