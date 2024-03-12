// Script SceneControl
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
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
    public static bool changeMenu;
    //Languages
    public GameObject ingles;
    public GameObject español;
    public GameObject aleman;
    public GameObject italiano;
    public GameObject frances;
    public GameObject portugues;
    //Quality
    public GameObject wow;
    public GameObject boff;
    public GameObject nah;
    public GameObject kunaiUp3;
    public GameObject kunaiUp2;
    public GameObject kunaiUp1;
    public GameObject kunailvl1;
    public GameObject kunailvl2;
    public GameObject kunailvl3;    
    public GameObject kr1;
    public GameObject kr2;
    public GameObject kr3;
    public GameObject LeftArrow;
    public GameObject RightArrow;

    public Image toggleImage;
    public GameObject levels;

    //Alt+F4
    public GameObject Alt;
    public GameObject F4;
    public bool canF4;

    Image brillo;
    public Image panelDeBrillo;
    private float Opacity;
    public bool activado;
    public bool canPlay;

    public Vector2 defaultPlayerPosition;

    private AudioSource audSor1;
    private AudioSource audSor2;
    private AudioSource audSor3;
    private Volume vol;
    private reviveHamster rvhm;
    public bool isMusicPaused = false;
    [SerializeField] private int MusicCount;
    [SerializeField] private float music1PlaybackTime;
    [SerializeField] private float music2PlaybackTime;
    [SerializeField] private float music3PlaybackTime;
    private int languageCounter;
    private int qualityCounter;
    public static int kunaiCount;
    public static int kunaiMax;
    public GameObject cursor;
    public GameObject Lock1;
    public GameObject Lock2;
    UpgradeMenu up;
    public GameObject slider;
    Slider sli;
    private void Awake()
    {
        Opacity = PlayerPrefs.GetFloat("Brillo", 1f);
        brillo = panelDeBrillo.GetComponent<Image>();
        MusicCount = 1;
    }
    void Start()
    {
        if (changeMenu)
        {
            mainMenu.SetActive(false);
            kunaiUpgradesWindow.SetActive(true);
        }
        if (!changeMenu)
        {
            mainMenu.SetActive(true);
            kunaiUpgradesWindow.SetActive(false);
        }
        sli = slider.GetComponent<Slider>();

        up = GetComponent<UpgradeMenu>();
        if (NextLevel.startingLevel > 1)
        {
            mainMenu.SetActive(false);
            optionsWindow.SetActive(false);
            kunaiUpgradesWindow.SetActive(true);
        }

        int level = PlayerPrefs.GetInt("Level", 1);

        float playerPosX = PlayerPrefs.GetFloat("PlayerPosX", defaultPlayerPosition.x);
        float playerPosY = PlayerPrefs.GetFloat("PlayerPosY", defaultPlayerPosition.y);

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = new Vector2(playerPosX, playerPosY);
        }
        canF4 = false;
        activado = true;
        canPlay = true;
        Opacity = 0f;
        Screen.fullScreen = true;
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
        PlayerPrefs.GetFloat("Music1PlaybackTime", audSor1.time);
        PlayerPrefs.GetFloat("Music2PlaybackTime", audSor2.time);
        PlayerPrefs.GetFloat("Music3PlaybackTime", audSor3.time);

        music1PlaybackTime = PlayerPrefs.GetFloat("Music1PlaybackTime", 0f);
        music2PlaybackTime = PlayerPrefs.GetFloat("Music2PlaybackTime", 0f);
        music3PlaybackTime = PlayerPrefs.GetFloat("Music3PlaybackTime", 0f);
        languageCounter = PlayerPrefs.GetInt("LanguageCounter", 0);
        qualityCounter = PlayerPrefs.GetInt("QualityCounter", 0);
        kunaiCount = PlayerPrefs.GetInt("kunaiCount", kunaiCount);
        kunaiMax = PlayerPrefs.GetInt("kunaiMax", kunaiMax);

        audSor1.time = music1PlaybackTime;
        audSor2.time = music2PlaybackTime;
        audSor3.time = music3PlaybackTime;

        audSor1.volume = 0.1f;
        audSor2.volume = 0.1f;
        audSor3.volume = 0.1f;
        sli.value = 0.1f;
        bigCredits.SetActive(false);

        int rainingProb = Random.Range(1, 7);
        Rain.SetActive(rainingProb == 5);

        if (MusicCount == 1)
        {
            sli.value = audSor1.volume;
        }
        else if (MusicCount == 2)
        {
            sli.value = audSor2.volume;
        }
        else if (MusicCount == 3)
        {
            sli.value = audSor3.volume;
        }
    }

    void Update()
    {
        if (MusicCount == 1)
        {
            audSor1.volume = sli.value;
        }
        else if (MusicCount == 2)
        {
            audSor2.volume = sli.value;
        }
        else if (MusicCount == 3)
        {
            audSor3.volume = sli.value;
        }
        //mouse.transform.position == cursor.transform.position;
        //Vector3 worldMousePos = Camera.ScreenToWorldPoint;
        if (Opacity > 0.8f)
        {
            Opacity = 0.8f;
        }
        kunaiMax = kunaiCount;
        if (Input.GetKey(KeyCode.Y))
        {
            rvhm.ResetCounter();
        }

        if (Input.GetKey(KeyCode.Alpha1))
        {
            NextLevel.startingLevel = 1;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            NextLevel.startingLevel = 2;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            NextLevel.startingLevel = 3;
        }        
        if (Input.GetKey(KeyCode.Alpha4))
        {
            NextLevel.startingLevel = 4;
        }       
        if (Input.GetKey(KeyCode.Alpha5))
        {
            NextLevel.startingLevel = 5;
        }
        if (Input.GetKey(KeyCode.Alpha6))
        {
            NextLevel.startingLevel = 6;
        }
        if (Input.GetKey(KeyCode.Alpha7))
        {
            NextLevel.startingLevel = 7;
        }        
        if (Input.GetKey(KeyCode.Alpha8))
        {
            NextLevel.startingLevel = 8;
        }

        if (MusicCount == 1 && canPlay)
        {
            Track1.SetActive(true);
            Track2.SetActive(false);
            Track3.SetActive(false);
        }
        else if (MusicCount == 2 && canPlay)
        {
            Track1.SetActive(false);
            Track2.SetActive(true);
            Track3.SetActive(false);
        }
        else if (MusicCount == 3 && canPlay)
        {
            Track1.SetActive(false);
            Track2.SetActive(false);
            Track3.SetActive(true);
        }
        if (!canPlay)
        {
            Track1.SetActive(false);
            Track2.SetActive(false);
            Track3.SetActive(false);
        }

        if (audSor1.volume >= 0.6f || audSor2.volume >= 0.6f || audSor3.volume >= 0.6f || sli.value >= 0.6f)
        {
            audSor1.volume = 0.6f;
            audSor2.volume = 0.6f;
            audSor3.volume = 0.6f;
            sli.value = 0.6f;
        }

        if (audSor1.volume <= 0 || audSor2.volume <= 0 || audSor3.volume <= 0 || sli.value <= 0)
        {
            audSor1.volume = 0;
            audSor2.volume = 0;
            audSor3.volume = 0;
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

        if (kunaiCount == 1 && UpgradeMenu.kunaiOwnedd)
        {
            kunaiUp1.SetActive(true);
            kunaiUp2.SetActive(false);
            kunaiUp3.SetActive(false);
            kunailvl1.SetActive(true);
            kunailvl2.SetActive(false);
            kunailvl3.SetActive(false);           
            kr1.SetActive(true);
            kr2.SetActive(false);
            kr3.SetActive(false);
            LeftArrow.SetActive(false);
            RightArrow.SetActive(true);
            Lock1.SetActive(false);
            Lock2.SetActive(false);
        }

        if (kunaiCount == 2 && UpgradeMenu.kunaiOwnedd)
        {
            kunaiUp1.SetActive(false);
            kunaiUp2.SetActive(true);
            kunaiUp3.SetActive(false);
            kunailvl1.SetActive(false);
            kunailvl2.SetActive(true);
            kunailvl3.SetActive(false);
            kr1.SetActive(false);
            kr2.SetActive(true);
            kr3.SetActive(false);
            LeftArrow.SetActive(true);
            RightArrow.SetActive(true);
            Lock1.SetActive(false);
            Lock2.SetActive(false);
        }

        if (kunaiCount == 3 && UpgradeMenu.kunaiOwnedd)
        {
            kunaiUp1.SetActive(false);
            kunaiUp2.SetActive(false);
            kunaiUp3.SetActive(true);
            kunailvl1.SetActive(false);
            kunailvl2.SetActive(false);
            kunailvl3.SetActive(true);
            kr1.SetActive(false);
            kr2.SetActive(false);
            kr3.SetActive(true);
            LeftArrow.SetActive(true);
            RightArrow.SetActive(false);
            Lock1.SetActive(false);
            Lock2.SetActive(false);
        }

        if (!UpgradeMenu.kunaiOwnedd)
        {
            kunailvl1.SetActive(false);
            kunailvl2.SetActive(false);
            kunailvl3.SetActive(false);
            kr1.SetActive(true);
            kr2.SetActive(false);
            kr3.SetActive(false);
            Lock1.SetActive(true);
        }

        if (!UpgradeMenu.tpOwnedd) 
        {
            kunaiUp1.SetActive(false);
            kunaiUp2.SetActive(false);
            kunaiUp3.SetActive(false);
            LeftArrow.SetActive(false);
            RightArrow.SetActive(false);
            Lock2.SetActive(true);
        }

        if (qualityCounter < 0)
        {
            qualityCounter = 2;
        }

        if (qualityCounter > 2)
        {
            qualityCounter = 0;
        }       
        if (kunaiCount < 1)
        {
            kunaiCount = 1;
        }

        if (kunaiCount > 3)
        {
            kunaiCount = 3;
        }
    }
    public void AltButton()
    {
        canF4 = true;
    }    
    public void F4Button()
    {
        if (canF4)
        {
            Application.Quit();
        }
    }
    public void KunaiUpgrades()
    {
        if (activado)
        {
            mainMenu.SetActive(false);
            optionsWindow.SetActive(false);
            kunaiUpgradesWindow.SetActive(true);
        }
    }

    void OnDestroy()
    {
        if (audSor1 != null)
        {
            PlayerPrefs.SetFloat("Music1PlaybackTime", audSor1.time);
        }
        if (audSor2 != null)
        {
            PlayerPrefs.SetFloat("Music2PlaybackTime", audSor2.time);
        }
        if (audSor3 != null)
        {
            PlayerPrefs.SetFloat("Music3PlaybackTime", audSor3.time);
        }
        PlayerPrefs.SetInt("LastMusicSet", MusicCount);
        PlayerPrefs.SetInt("kunaiMax", kunaiMax);
        PlayerPrefs.SetInt("kunaiCount", kunaiCount);
        changeMenu = false;
        PlayerPrefs.Save();
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
        sli.value += 0.02f;
    }

    public void VolumeDown()
    {
        audSor1.volume -= 0.02f;
        audSor2.volume -= 0.02f;
        audSor3.volume -= 0.02f;
        sli.value -= 0.02f;
    }

    public void PlayGame()
    {
        mainMenu.SetActive(false);
        levels.SetActive(true);
    }
    public void LevelsBack()
    {
        levels.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void Level1()
    {
        NextLevel.startingLevel = 1;
        SceneManager.LoadScene("Game");
    }    
    
    public void Level2()
    {
        NextLevel.startingLevel = 2;
        SceneManager.LoadScene("Game");
    }   
    
    public void Level3()
    {
        NextLevel.startingLevel = 3;
        SceneManager.LoadScene("Game");
    }    
    public void Level4()
    {
        NextLevel.startingLevel = 4;
        SceneManager.LoadScene("Game");
    }    
    
    public void Level5()
    {
        NextLevel.startingLevel = 5;
        SceneManager.LoadScene("Game");
    }   
    
    public void Level6()
    {
        NextLevel.startingLevel = 6;
        SceneManager.LoadScene("Game");
    }    
    public void Level7()
    {
        NextLevel.startingLevel = 7;
        SceneManager.LoadScene("Game");
    }   
    
    public void Level8()
    {
        NextLevel.startingLevel = 8;
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
    }
    public void fullScreenOff()
    {
        Screen.fullScreen = false;
        unckeckedToggle.SetActive(true);
        ckeckedToggle.SetActive(false);
    }

    public void NextSong()
    {
        MusicCount = (MusicCount % 3) + 1;
        SetMusicTrack();
    }

    public void ChangeLightDown()
    {
        Opacity += 0.1f;
        brillo.color = new Color(brillo.color.r, brillo.color.g, brillo.color.b, Opacity);
        PlayerPrefs.SetFloat("Brillo", Opacity); 
    }

    public void ChangeLightUp()
    {
        Opacity -= 0.1f;
        brillo.color = new Color(brillo.color.r, brillo.color.g, brillo.color.b, Opacity);
        PlayerPrefs.SetFloat("Brillo", Opacity); 
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
        audSor1.Pause();
        audSor2.Pause();
        audSor3.Pause();
        isMusicPaused = true;
    }

    public void ResumeMusic()
    {
        PauseButton.SetActive(true);
        ResumeButton.SetActive(false);
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
