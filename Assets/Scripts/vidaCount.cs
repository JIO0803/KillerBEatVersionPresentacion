using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vidaCount : MonoBehaviour
{
    public static int lifesValue = 100;
    TMP_Text vida;
    public bool canDie;
    // Start is called before the first frame update
    void Start()
    {
        vida = GetComponent<TMP_Text>();
        canDie = true;
        lifesValue = 100;
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

        vida.text = "Life" + lifesValue;

        if (lifesValue == 0 && canDie == true)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
