using UnityEngine;

public class VolumeValueChange : MonoBehaviour {

    // Reference to Audio Source component
    private AudioSource audioSrc1;
    private AudioSource audioSrc2;
    private AudioSource audioSrc3;
    public GameObject track1;
    public GameObject track2;
    public GameObject track3;

    // Music volume variable that will be modified
    // by dragging slider knob
    private float musicVolume;

	// Use this for initialization
	void Start () {
        musicVolume = 0.3f;
        // Assign Audio Source component to control it
        audioSrc1 = track1.GetComponent<AudioSource>();
        audioSrc2 = track2.GetComponent<AudioSource>();
        audioSrc3 = track3.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        // Setting volume option of Audio Source to be equal to musicVolume
        audioSrc1.volume = musicVolume;
        audioSrc2.volume = musicVolume;
        audioSrc3.volume = musicVolume;
	}

    // Method that is called by slider game object
    // This method takes vol value passed by slider
    // and sets it as musicValue
    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}