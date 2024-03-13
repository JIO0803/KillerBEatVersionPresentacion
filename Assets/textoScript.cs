using UnityEngine;
using TMPro;
using System.Collections;

public class ColliderTextoGenerador : MonoBehaviour
{
    public TextMeshProUGUI textoGenerado; // Asigna el TextMeshProUGUI del Canvas desde el Inspector
    public string textoAGenerar = "Texto Generado";
    public float velocidadGeneracion = 0.2f; // Velocidad de generación del texto
    private static bool generandoTexto = false; // Variable estática para rastrear si se está generando texto en algún otro GameObject

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !generandoTexto)
        {
            GenerarTexto();
        }
    }

    private void GenerarTexto()
    {
        generandoTexto = true; // Marcar que se está generando texto
        StartCoroutine(GenerarTextoProgresivo());
    }

    private IEnumerator GenerarTextoProgresivo()
    {
        textoGenerado.text = ""; // Reiniciar el texto antes de comenzar

        string textoTemporal = ""; // Texto temporal para evitar la duplicación
        for (int i = 0; i < textoAGenerar.Length; i++)
        {
            textoTemporal += textoAGenerar[i]; // Agregar el nuevo carácter al texto temporal
            textoGenerado.text = textoTemporal; // Asignar el texto temporal al texto generado
            yield return new WaitForSeconds(velocidadGeneracion);
        }

        generandoTexto = false; // Restablecer la variable cuando se haya terminado de generar el texto
    }
}
