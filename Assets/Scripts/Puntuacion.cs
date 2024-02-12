using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Puntuacion : MonoBehaviour
{
    public static int scoreValue = 0;
    TMP_Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TMP_Text>();
        scoreValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Gold" + scoreValue;
    }
}
