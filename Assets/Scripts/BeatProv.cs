using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatProv : MonoBehaviour
{
    private static BeatProv backgroundMusic;
    void Awake()
    {
        if (backgroundMusic == null)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(backgroundMusic);
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
