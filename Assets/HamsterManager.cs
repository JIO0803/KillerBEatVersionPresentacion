using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HamsterInteraction : MonoBehaviour
{
    public GameObject foodPrompt;
    public GameObject foodFill;
    public GameObject waterPrompt;
    public GameObject waterFill;
    public GameObject lightPrompt;
    public GameObject heartImage;
    public GameObject RIP;

    public static int lifeCounter = 5;
    public static int currentLifes;
    private bool actionTaken;
    public bool alive = true;

    private void Start()
    {
        if (PlayerPrefs.HasKey("LifeCounter"))
        {
            lifeCounter = PlayerPrefs.GetInt("LifeCounter");
            currentLifes = PlayerPrefs.GetInt("LifeCounter");
        }

        ShowRandomPrompt();
        actionTaken = false;
    }

    private void Update()
    {
        if (!alive)
        {
            gameObject.SetActive(false);
            foodPrompt.SetActive(false);
            waterPrompt.SetActive(false);
            lightPrompt.SetActive(false);
            heartImage.SetActive(false);
            RIP.SetActive(true);
        }

        if (lifeCounter > 5 || PlayerPrefs.GetInt("LifeCounter") > 5)
        {
            lifeCounter = 5;
        }

        if (lifeCounter < 0 || PlayerPrefs.GetInt("LifeCounter") < 0)
        {
            lifeCounter = 0;
        }   
        if (alive)
        {
            RIP.SetActive(false);
        }

        if (lifeCounter <= 0)
        {
            Debug.Log("Me morí");
            alive = false;
        }
    }

    private void ShowRandomPrompt()
    {
        foodPrompt.SetActive(false);
        waterPrompt.SetActive(false);
        lightPrompt.SetActive(false);
        if (alive)
        {
            int randomIndex = Random.Range(0, 3);

            switch (randomIndex)
            {
                case 0:
                    foodPrompt.SetActive(true);
                    foodFill.SetActive(false);
                    break;
                case 1:
                    waterPrompt.SetActive(true);
                    waterFill.SetActive(false);
                    break;
                case 2:
                    lightPrompt.SetActive(true);
                    break;
            }
        }
    }

    public void HandlePlayerAction(string action)
    {
        if (alive)
        {
            switch (action)
            {
                case "Comida":
                    if (foodPrompt.activeSelf)
                    {
                        foodPrompt.SetActive(false);
                        foodFill.SetActive(true);
                        heartImage.SetActive(true);
                        actionTaken = true;
                        return;
                    }
                    break;
                case "Agua":
                    if (waterPrompt.activeSelf)
                    {
                        waterPrompt.SetActive(false);
                        heartImage.SetActive(true);
                        waterFill.SetActive(true);
                        actionTaken = true;
                        return;
                    }
                    break;
                case "Luz":
                    if (lightPrompt.activeSelf)
                    {
                        lightPrompt.SetActive(false);
                        heartImage.SetActive(true);
                        actionTaken = true;
                        return;
                    }
                    break;
            }
        }  
    }

    private void OnDisable()
    {
        if (!actionTaken)
        {
            lifeCounter -= 1;
        }
        PlayerPrefs.SetInt("LifeCounter", lifeCounter);
    }
}