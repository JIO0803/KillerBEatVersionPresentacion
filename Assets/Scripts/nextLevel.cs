using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class nextLevel : MonoBehaviour
{
    public Transform[] playerSpawns;
    public Transform[] gameObjectSpawns;
    public static int startingLevel = 1; // Inicializamos el nivel de inicio en 1

    private HashSet<int> completedLevels = new HashSet<int>(); // Conjunto para mantener un registro de los niveles completados

    pointManager pm;

    void Start()
    {
        LoadCompletedLevels();

        PlayerPrefs.SetInt("totalPointsGame", 0); // Inicializamos los puntos totales del juego
        PlayerPrefs.Save();

        pm = FindObjectOfType<pointManager>();
        SetInitialPositions();
    }

    private void Update()
    {
        // Este bloque de código se puede optimizar, pero lo dejo así por simplicidad
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            startingLevel = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            startingLevel = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            startingLevel = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            startingLevel = 4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            startingLevel = 5;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            startingLevel = 6;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            startingLevel = 7;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            startingLevel = 8;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !IsLevelCompleted(startingLevel))
        {
            GetPoints();
            completedLevels.Add(startingLevel); // Agregamos el nivel completado a la lista

            SaveCompletedLevels();
        }

        if (collision.CompareTag("Player"))
        {
            Invoke("GoToMenu", 0f);
        }
    }

    void SetInitialPositions()
    {
        int index = startingLevel - 1; // Los arrays comienzan en índice 0, por eso restamos 1 al nivel
        if (index >= 0 && index < playerSpawns.Length && index < gameObjectSpawns.Length)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = playerSpawns[index].position;
            transform.position = gameObjectSpawns[index].position;
        }
    }

    void GoToMenu()
    {
        PlayerPrefs.SetInt("totalPointsGame", 0);
        PlayerPrefs.Save();
        SceneControl.changeMenu = true;
        SceneManager.LoadScene("Menu");
    }

    void GetPoints()
    {
        Puntuacion.scoreValue += 15;
        pm.totalPointsGame += 15;
    }

    void LoadCompletedLevels()
    {
        string levelsString = PlayerPrefs.GetString("CompletedLevels", "");
        string[] levelsArray = levelsString.Split(',');
        foreach (string levelStr in levelsArray)
        {
            int level;
            if (int.TryParse(levelStr, out level))
            {
                completedLevels.Add(level);
            }
        }
    }

    void SaveCompletedLevels()
    {
        string levelsString = string.Join(",", completedLevels);
        PlayerPrefs.SetString("CompletedLevels", levelsString);
        PlayerPrefs.Save();
    }

    bool IsLevelCompleted(int level)
    {
        return completedLevels.Contains(level);
    }
}
