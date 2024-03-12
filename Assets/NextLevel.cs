using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public Transform playerSpawn1;
    public Transform playerSpawn2;
    public Transform playerSpawn3;
    public Transform playerSpawn4;
    public Transform playerSpawn5;
    public Transform playerSpawn6;
    public Transform playerSpawn7;
    public Transform playerSpawn8;
    public Transform gameObjectSpawn1;
    public Transform gameObjectSpawn2;
    public Transform gameObjectSpawn3;
    public Transform gameObjectSpawn4;
    public Transform gameObjectSpawn5;
    public Transform gameObjectSpawn6;
    public Transform gameObjectSpawn7;
    public Transform gameObjectSpawn8;

    public static int startingLevel;
    public int currentLevel;

    pointManager pm;

    private void Update()
    {
        currentLevel = startingLevel;
        if (Input.GetKey(KeyCode.Alpha1))
        {
            startingLevel = 1;
        }               
        if (Input.GetKey(KeyCode.Alpha2))
        {
            startingLevel = 2;
        }        
        if (Input.GetKey(KeyCode.Alpha3))
        {
            startingLevel = 3;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Puntuacion.scoreValue += 50;
            pm.totalPointsGame += 50;
            startingLevel += 1;

            if (startingLevel > 8)
            {
                startingLevel = 1;
            }            
            if (startingLevel < 1)
            {
                startingLevel = 1;
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
        if (startingLevel == 1)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = playerSpawn1.position;
            transform.position = gameObjectSpawn1.position;
        }
        if (startingLevel == 2)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = playerSpawn2.position;
            transform.position = gameObjectSpawn2.position;
        }        
        
        if (startingLevel == 3)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = playerSpawn3.position;
            transform.position = gameObjectSpawn3.position;
        }         
        
        if (startingLevel == 4)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = playerSpawn3.position;
            transform.position = gameObjectSpawn3.position;
        }          
        
        if (startingLevel == 5)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = playerSpawn1.position;
            transform.position = gameObjectSpawn1.position;
        }
        if (startingLevel == 6)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = playerSpawn2.position;
            transform.position = gameObjectSpawn2.position;
        }        
        
        if (startingLevel == 7)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = playerSpawn3.position;
            transform.position = gameObjectSpawn3.position;
        }         
        
        if (startingLevel == 8)
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
