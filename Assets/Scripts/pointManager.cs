using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class pointManager : MonoBehaviour
{
    private int addGained = 10;
    [SerializeField] private int totalPointsGame;
    [HideInInspector] public float currentMoney; // Ocultar en el Inspector

    public TextMeshProUGUI pointsText;
    public float displayDuration = 2f;

    private float displayTimer = 0f;

    private void Awake()
    {
        pointsText.gameObject.SetActive(false);
        totalPointsGame = PlayerPrefs.GetInt("TotalPointsGame", 0);
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("TotalPointsGame", totalPointsGame);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        if (displayTimer > 0f)
        {
            displayTimer -= Time.deltaTime;
            if (displayTimer <= 0f)
            {
                pointsText.gameObject.SetActive(false);
            }
        }
    }

    public void AddPoints()
    {
        totalPointsGame += addGained;

        pointsText.text = totalPointsGame.ToString() + "$";

        pointsText.gameObject.SetActive(true);
        displayTimer = displayDuration;
        currentMoney = totalPointsGame;
    }
}
