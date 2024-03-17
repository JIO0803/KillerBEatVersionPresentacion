using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class pointManager : MonoBehaviour
{
    private int addGained = 10;
    public int totalPointsGame;
    public float currentMoney;

    public TextMeshProUGUI pointsText;
    public float displayDuration = 2f;

    private float displayTimer = 0f;

    private void Awake()
    {
        totalPointsGame = PlayerPrefs.GetInt("totalPointsGame", 0);
        currentMoney = totalPointsGame;
        pointsText.gameObject.SetActive(false);
        UpdatePointsText();
    }

    private void Update()
    {
        UpdatePointsText();
    }

    private void UpdatePointsText()
    {
        pointsText.text = totalPointsGame.ToString() + "$";
    }

    public void AddPoints()
    {
        totalPointsGame += addGained;
        pointsText.gameObject.SetActive(true);
        displayTimer = displayDuration;
        currentMoney = totalPointsGame;
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("totalPointsGame", totalPointsGame);
        PlayerPrefs.Save();
    }

}
