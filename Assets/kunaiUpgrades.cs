using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    public int upgradeCost = 10; 
    public GameObject upgradeButton; 
    public GameObject lockedUpgrade;
    private int intmoney;
    public int realMoney;

    private void Start()
    {
        int currentMoney = PlayerPrefs.GetInt("Money", 0);
        if (currentMoney < upgradeCost)
        {
            lockedUpgrade.SetActive(true);
            upgradeButton.SetActive(false);
            intmoney = currentMoney;
        }
    }
    private void Update()
    {
        realMoney = intmoney;
    }
    public void UpgradeEquipment()
    {
        int currentMoney = PlayerPrefs.GetInt("Money", 0);
        if (currentMoney >= upgradeCost)
        {
            currentMoney -= upgradeCost;
            PlayerPrefs.SetInt("Money", currentMoney);

            if (currentMoney < upgradeCost)
            {
                upgradeButton.SetActive(false);
                lockedUpgrade.SetActive(true);
                intmoney = currentMoney;
            }
        }
    }
}