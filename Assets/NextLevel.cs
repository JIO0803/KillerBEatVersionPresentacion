using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public Transform playerSpawn1;
    public Transform playerSpawn2;
    public Transform playerSpawn3;
    public Transform gameObjectSpawn1;
    public Transform gameObjectSpawn2;
    public Transform gameObjectSpawn3;

    public static int startingLevel;
    public int currentLevel;

    pointManager pm;

    private void Update()
    {
        currentLevel = startingLevel;
        if (Input.GetKey(KeyCode.Alpha1))
        {
            startingLevel = 0;
        }               
        if (Input.GetKey(KeyCode.Alpha2))
        {
            startingLevel = 1;
        }        
        if (Input.GetKey(KeyCode.Alpha3))
        {
            startingLevel = 2;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Puntuacion.scoreValue += 50;
            pm.totalPointsGame += 50;
            startingLevel += 1;

            if (startingLevel > 2)
            {
                startingLevel = 0;
            }            
            if (startingLevel < 0)
            {
                startingLevel = 0;
            }
            Invoke("GoToMenu", 0f);
            Debug.Log("Next");
        }
    }

    void Start()
    {
        pm = FindObjectOfType<pointManager>();
        SetInitialPositions();
    }

    void SetInitialPositions()
    {
        if (startingLevel == 0)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = playerSpawn1.position;
            transform.position = gameObjectSpawn1.position;
        }
        if (startingLevel == 1)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = playerSpawn2.position;
            transform.position = gameObjectSpawn2.position;
        }        
        
        if (startingLevel == 2)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = playerSpawn3.position;
            transform.position = gameObjectSpawn3.position;
        }           
    }
    void GoToMenu()
    {
        SceneControl.changeMenu = true;
        Destroy(gameObject);
        SceneManager.LoadScene("Menu");
        PlayerPrefs.Save();
    }
}
