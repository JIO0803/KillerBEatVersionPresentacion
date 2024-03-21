using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DontDestroy : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject slider;
    Slider sli;
    private static DontDestroy instance;

    void Start()
    {
        sli = slider.GetComponent<Slider>();
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = 0.05f;
        sli.value = 0.05f;
        sli.value = audioSource.volume;
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {

        if (SceneManager.sceneCount == 0)
        {
            this.gameObject.SetActive(false);
        }        
        if (SceneManager.sceneCount == 1)
        {
            this.gameObject.SetActive(true);
        }
    }
}
