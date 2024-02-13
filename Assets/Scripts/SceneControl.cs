using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public GameObject empty;
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

    public void NextMusic()
    {
        Debug.Log("Criteria");
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
}
