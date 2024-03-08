using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundButton : MonoBehaviour
{
    public List<AudioClip> soundList;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
         if (Input.GetKeyUp(KeyCode.G))
         {
            if (soundList.Count == 0)
            {
                return;
            }

            int randomIndex = Random.Range(0, soundList.Count);

            audioSource.clip = soundList[randomIndex];
            audioSource.Play();
        }
    }

    public void PlayRandomSound()
    {
        if (soundList.Count == 0)
        {
            return;
        }

        int randomIndex = Random.Range(0, soundList.Count);

        audioSource.clip = soundList[randomIndex];
        audioSource.Play();
    }
}
