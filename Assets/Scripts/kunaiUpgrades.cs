using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    public int upgradeCost = 30;
    public int unlockCost = 10;
    public int TPCost = 20;
    public static int totalPointsMenu;
    public GameObject kunaiOwned;
    public static bool kunaiOwnedd;
    public GameObject tpOwned;
    public static bool tpOwnedd;
    public float money;
    public GameObject blockedTP;
    public GameObject availabelTP;
    public TextMeshProUGUI pointsText;

    private void Awake()
    {
        kunaiOwnedd = false;
        tpOwnedd = false;
        money = 0;
        totalPointsMenu = PlayerPrefs.GetInt("totalPointsGame", 0);
    }

    private void Start()
    {
        LoadPlayerPrefs();
        UpdateUI();
    }

    private void LoadPlayerPrefs()
    {
        kunaiOwnedd = PlayerPrefs.GetInt("KunaiUnlocked", 0) == 1;
        PlayerPrefs.GetInt("totalPointsGame", totalPointsMenu);
        tpOwnedd = PlayerPrefs.GetInt("TPUnlocked", 0) == 1;
        money = totalPointsMenu;
        blockedTP.SetActive(!kunaiOwnedd);
        availabelTP.SetActive(kunaiOwnedd && !tpOwnedd);
    }

    private void SavePlayerPrefs()
    {
        PlayerPrefs.SetInt("KunaiUnlocked", kunaiOwnedd ? 1 : 0);
        PlayerPrefs.SetInt("TPUnlocked", tpOwnedd ? 1 : 0);
        PlayerPrefs.SetInt("totalPointsGame", totalPointsMenu);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        pointsText.text = totalPointsMenu.ToString() + "$";

        if (Input.GetKeyDown(KeyCode.J))
        {
            totalPointsMenu += 50;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            totalPointsMenu -= 50;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            ResetAllUpgrades();
        }
    }

    public void AddKunai()
    {
        if (kunaiOwnedd && tpOwnedd && totalPointsMenu >= upgradeCost)
        {
            totalPointsMenu -= upgradeCost;
            UpdateUI();
            SceneControl.kunaiCount++;
        }
    }

    public void SubstractKunai()
    {
        totalPointsMenu += upgradeCost;
        UpdateUI();
        SceneControl.kunaiCount--;
    }

    public void UnlockKunai()
    {
        if (!kunaiOwnedd && totalPointsMenu >= unlockCost)
        {
            kunaiOwnedd = true;
            totalPointsMenu -= unlockCost;
            kunaiOwned.SetActive(true);
            UpdateUI();
            SavePlayerPrefs();
            blockedTP.SetActive(false);
            availabelTP.SetActive(true);
        }
    }

    public void UnlockTP()
    {
        if (kunaiOwnedd && !tpOwnedd && totalPointsMenu >= TPCost)
        {
            tpOwnedd = true;
            totalPointsMenu -= TPCost;
            tpOwned.SetActive(true);
            UpdateUI();
            SavePlayerPrefs();
        }
    }

    private void ResetAllUpgrades()
    {
        tpOwnedd = false;
        kunaiOwnedd = false;
        totalPointsMenu = 0;
        tpOwned.SetActive(false);
        kunaiOwned.SetActive(false);
        SceneControl.kunaiMax = 1;
        SceneControl.kunaiCount = 1;
        UpdateUI();
        SavePlayerPrefs();
    }

    private void UpdateUI()
    {
        kunaiOwned.SetActive(kunaiOwnedd);
        tpOwned.SetActive(tpOwnedd);

        blockedTP.SetActive(!kunaiOwnedd);
        availabelTP.SetActive(kunaiOwnedd && !tpOwnedd);
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("totalPointsGame", totalPointsMenu);
        PlayerPrefs.Save();
    }
}
