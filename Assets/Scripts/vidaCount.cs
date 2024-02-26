using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class vidaCount : MonoBehaviour
{
    public float lifesValue = 1;
    TMP_Text vida;
    public bool canDie;
    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        vida = GetComponent<TMP_Text>();
        canDie = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            canDie = false;
        }
        if (Input.GetKey(KeyCode.M))
        {
            canDie = true;
        }
        if (Input.GetKey(KeyCode.K))
        {
            canDie = true;
            lifesValue = 0;
        }

        if (lifesValue < 0)
        {
            lifesValue = 0;
        }

        if (lifesValue <= 0.1f && canDie == true)
        {
            SceneManager.LoadScene("Menu");
        }
        healthBar.fillAmount = lifesValue;  
    }
}
