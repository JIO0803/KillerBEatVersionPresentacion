using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class VidaPers1 : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject Camera;
    public bool Good;
    public bool doing;
    public int damageDealt = 10;
    SpawnKunai kunaiSpawn;
    Volume vols;
    void Start()
    {
        currentHealth = maxHealth;
        vidaCount.lifesValue = 100;
        Camera.GetComponent<Volume>().weight = 0.3f;
        kunaiSpawn = gameObject.GetComponent<SpawnKunai>();
        vols = Camera.GetComponent<Volume>();
    }

    void Update()
    {
        if (vols.weight == 0f)
        {
            Good = false;
            doing = true;
            Invoke("damage", 0.35f);
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                CancelInvoke("damage");
            }
        }
        if (vols.weight == 0.3f)
        {
            if (Input.GetMouseButtonDown(0))
            {

            }
            Good = true;
        }
    }

    void damage()
    {
        if (doing == true && Good == false)
        {
            currentHealth -= damageDealt;
            vidaCount.lifesValue -= 5;
            doing = false;
            Good = true;
        }
    }    
    
    void damage1()
    {
        currentHealth -= 10;
        vidaCount.lifesValue -= 10;
    }
}