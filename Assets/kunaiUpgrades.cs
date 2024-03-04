using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeMenu : MonoBehaviour
{
    public int upgradeCost = 30;
    public int unlockCost = 10;
    public int TPCost = 20;
    [SerializeField] private int totalPointsMenu;
    public GameObject kunaiOwned;
    public static bool kunaiOwnedd;
    public GameObject tpOwned;
    public static bool tpOwnedd;
    public GameObject blockedTP;
    public GameObject availabelTP;
    public TextMeshProUGUI pointsText;

    private void Start()
    {
        LoadPlayerPrefs();
        UpdateUI();
    }

    private void LoadPlayerPrefs()
    {
        totalPointsMenu = PlayerPrefs.GetInt("TotalPointsGame", 0);
        kunaiOwnedd = PlayerPrefs.GetInt("KunaiUnlocked", 0) == 1;
        tpOwnedd = PlayerPrefs.GetInt("TPUnlocked", 0) == 1;

        blockedTP.SetActive(!kunaiOwnedd);
        availabelTP.SetActive(kunaiOwnedd && !tpOwnedd);
    }

    private void OnDestroy()
    {
        SavePlayerPrefs();
    }

    private void SavePlayerPrefs()
    {
        PlayerPrefs.SetInt("TotalPointsGame", totalPointsMenu);
        PlayerPrefs.SetInt("KunaiUnlocked", kunaiOwnedd ? 1 : 0);
        PlayerPrefs.SetInt("TPUnlocked", tpOwnedd ? 1 : 0);
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
        if (totalPointsMenu >= upgradeCost)
        {
            totalPointsMenu -= upgradeCost;
            UpdateUI();
        }
    }

    public void SubstractKunai()
    {
        totalPointsMenu += upgradeCost;
        UpdateUI();
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
}
