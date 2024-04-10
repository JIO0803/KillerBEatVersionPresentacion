using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class textGen2 : MonoBehaviour
{
    public TextMeshProUGUI textoGenerado; // Asigna el TextMeshProUGUI del Canvas desde el Inspector
    public string textoAGenerar = "Texto Generado";
    public float velocidadGeneracion = 0.05f; // Velocidad de generación del texto

    private bool generandoTexto = false; // Bandera para verificar si se está generando texto
    private bool textoGeneradoPrevio = false; // Bandera para verificar si el texto ha sido generado previamente
    AudioSource aud;
    private void Start()
    {
        aud = gameObject.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Si se está generando texto o el texto ya ha sido generado previamente, salir
            if (generandoTexto || textoGeneradoPrevio)
                return;

            // Detiene las corrutinas y borra el texto de todos los ColliderTextoGenerador
            textGen2[] scripts = FindObjectsOfType<textGen2>();
            foreach (textGen2 ctg in scripts)
            {
                ctg.StopAllCoroutines();
                ctg.BorrarTexto();
                ctg.textoGeneradoPrevio = false; // Restablece la bandera para permitir que se genere texto nuevamente
            }

            // Genera el texto si no se está generando actualmente
            if (!generandoTexto)
            {
                textoGenerado.text = "";
                GenerarTexto();
                aud.Play();
            }
        }
    }

    private void GenerarTexto()
    {
        generandoTexto = true; // Establece la bandera en true para indicar que se está generando texto
        StartCoroutine(GenerarTextoProgresivo());
    }

    private IEnumerator GenerarTextoProgresivo()
    {
        string textoTemporal = ""; // Texto temporal para evitar la duplicación
        for (int i = 0; i < textoAGenerar.Length; i++)
        {
            textoTemporal += textoAGenerar[i]; // Agregar el nuevo carácter al texto temporal
            textoGenerado.text = textoTemporal; // Asignar el texto temporal al texto generado
            yield return new WaitForSecondsRealtime(velocidadGeneracion);
        }
        generandoTexto = false; // Establece la bandera en false cuando la generación de texto ha terminado
        textoGeneradoPrevio = true; // Establece la bandera en true cuando el texto ha sido generado
    }

    private void BorrarTexto()
    {
        if (textoGenerado != null)
        {
            textoGenerado.text = ""; // Borra el texto
        }
    }
}
