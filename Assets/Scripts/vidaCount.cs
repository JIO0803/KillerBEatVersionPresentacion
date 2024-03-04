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

    SpawnKunai sp;
    MovJugador mj;
    wallDetect wd;

    // Start is called before the first frame update
    void Start()
    {
        vida = GetComponent<TMP_Text>();
        canDie = true;
        sp = GetComponent<SpawnKunai>();
        mj = GetComponent<MovJugador>();
        wd = GetComponent<wallDetect>();
        mj.enabled = false;
        sp.enabled = false;
        wd.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.I))
        {
            lifesValue = 100;
            canDie = false;
        }
        if (Input.GetKey(KeyCode.M))
        {
            lifesValue = 1;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "tramp")
        {
            lifesValue = 0;
        }       
        
        if (collision.gameObject.tag == "pared" || collision.gameObject.tag == "ground")
        {
            mj.enabled = true;
            sp.enabled = true;
            wd.enabled = true;
        }
    }
}