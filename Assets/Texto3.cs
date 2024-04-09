using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class Texto3 : MonoBehaviour
{
    public TextMeshProUGUI textoGenerado; // Asigna el TextMeshProUGUI del Canvas desde el Inspector
    public string textoAGenerar = "Texto Generado";
    public float velocidadGeneracion = 0.05f; // Velocidad de generaci�n del texto
    private bool generandoTexto = false; // Bandera para verificar si se est� generando texto
    private bool textoGeneradoPrevio = false; // Bandera para verificar si el texto ha sido generado previamente
    private bool activar = false; // Booleano que se activar� cuando se alcancen 20 segundos
    private float contadorSegundos = 0f; // Contador de segundos
    public float maxSecs;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Si se est� generando texto o el texto ya ha sido generado previamente, salir
            if (generandoTexto || textoGeneradoPrevio)
                return;

            // Incrementar el contador de segundos mientras el objeto est� en el trigger
            contadorSegundos += Time.deltaTime;

            // Verificar si se han alcanzado 20 segundos
            if (contadorSegundos >= maxSecs)
            {
                activar = true;
                // Aqu� puedes ejecutar cualquier acci�n que desees cuando se alcancen los 20 segundos
            }

            // Detiene las corrutinas y borra el texto de todos los ColliderTextoGenerador
            Texto3[] scripts = FindObjectsOfType<Texto3>();
            foreach (Texto3 ctg in scripts)
            {
                ctg.StopAllCoroutines();
                ctg.BorrarTexto();
                ctg.textoGeneradoPrevio = false; // Restablece la bandera para permitir que se genere texto nuevamente
            }

            // Genera el texto si no se est� generando actualmente
            if (!generandoTexto && activar)
            {
                textoGenerado.text = "";
                GenerarTexto();
            }
        }
    }

    private void GenerarTexto()
    {
        generandoTexto = true; // Establece la bandera en true para indicar que se est� generando texto
        StartCoroutine(GenerarTextoProgresivo());
    }

    private IEnumerator GenerarTextoProgresivo()
    {
        string textoTemporal = ""; // Texto temporal para evitar la duplicaci�n
        for (int i = 0; i < textoAGenerar.Length; i++)
        {
            textoTemporal += textoAGenerar[i]; // Agregar el nuevo car�cter al texto temporal
            textoGenerado.text = textoTemporal; // Asignar el texto temporal al texto generado
            yield return new WaitForSecondsRealtime(velocidadGeneracion);
        }
        generandoTexto = false; // Establece la bandera en false cuando la generaci�n de texto ha terminado
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
