using TMPro;
using UnityEngine;

public class UpgradeMenu : MonoBehaviour
{
    public int upgradeCost = 10;
    public int unlockCost = 20;
    public int TPCost = 40;
    [SerializeField] private int totalPointsMenu;
    public GameObject kunaiOwned;
    public bool kunaiOwnedd;
    public GameObject tpOwned;
    public bool tpOwnedd;
    SceneControl sc;
    public TextMeshProUGUI pointsText;

    private void Start()
    {
        sc = GetComponent<SceneControl>();
    }
    private void Awake()
    {
        totalPointsMenu = PlayerPrefs.GetInt("TotalPointsGame", 0);
        if (tpOwnedd == false)
        {
            tpOwned.SetActive(false);
        }      
        if (kunaiOwnedd == false)
        {
            kunaiOwned.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("TotalPointsGame", totalPointsMenu);
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
        totalPointsMenu -= upgradeCost;
    }

    public void SubstractKunai()
    {
        totalPointsMenu += upgradeCost;
    }    
    
    public void UnlockKunai()
    {
        if (kunaiOwnedd == false)
        {

            kunaiOwnedd = true;
            totalPointsMenu -= unlockCost;
            kunaiOwned.SetActive(true);
        }
    }   
    public void UnlockTP()
    {
        if (tpOwnedd == false)
        {
            tpOwnedd = true;
            totalPointsMenu -= TPCost;
            tpOwned.SetActive(true);
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
        sc.kunaiCount = 1;
    }
}