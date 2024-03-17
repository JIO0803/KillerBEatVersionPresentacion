using System.Drawing;
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

    void Start()
    {
        PlayerPrefs.GetInt("totalPointsGame", 0);
        pm = FindObjectOfType<pointManager>();
        SetInitialPositions();
    }
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
        if (Input.GetKey(KeyCode.Alpha4))
        {
            startingLevel = 4;
        }        
        if (Input.GetKey(KeyCode.Alpha5))
        {
            startingLevel = 5;
        }               
        if (Input.GetKey(KeyCode.Alpha6))
        {
            startingLevel = 6;
        }        
        if (Input.GetKey(KeyCode.Alpha7))
        {
            startingLevel = 7;
        }        
        if (Input.GetKey(KeyCode.Alpha8))
        {
            startingLevel = 8;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (startingLevel == 2 || startingLevel == 4)
            {
                Puntuacion.scoreValue += 20;
                pm.totalPointsGame += 20;
            }

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
            GameObject.FindGameObjectWithTag("Player").transform.position = playerSpawn4.position;
            transform.position = gameObjectSpawn4.position;
        }          
        
        if (startingLevel == 5)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = playerSpawn5.position;
            transform.position = gameObjectSpawn5.position;
        }
        if (startingLevel == 6)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = playerSpawn6.position;
            transform.position = gameObjectSpawn6.position;
        }        
        
        if (startingLevel == 7)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = playerSpawn7.position;
            transform.position = gameObjectSpawn7.position;
        }         
        
        if (startingLevel == 8)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = playerSpawn8.position;
            transform.position = gameObjectSpawn8.position;
        }           
    }
    void GoToMenu()
    {
        PlayerPrefs.SetInt("totalPointsGame", 0);
        PlayerPrefs.Save();
        SceneControl.changeMenu = true;
        SceneManager.LoadScene("Menu");
    }
}
