using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class vidaCount : MonoBehaviour
{
    public float lifesValue = 1;
    public bool canDie;
    public bool free;

    public GameObject newSpawner;

    SpawnKunai sp;
    MovJugador mj;
    wallDetect wd;
    newSpawn ns;

    // Start is called before the first frame update
    void Start()
    {
        ns = newSpawner.GetComponent<newSpawn>();
        canDie = true;
        free = false;
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
            lifesValue = 1000;
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

        if (lifesValue <= 0 && canDie == true && !ns.newSpawnActivated)
        {
            SceneManager.LoadScene("Game");
        } 
        
        if (lifesValue <= 0 && canDie == true && ns.newSpawnActivated)
        {
            gameObject.transform.position = newSpawner.transform.position;
            lifesValue = 1;
        }
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
            free = true;
        }
    }
}