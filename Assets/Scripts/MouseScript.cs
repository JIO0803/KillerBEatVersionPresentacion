using UnityEngine;

public class EstelaMouse : MonoBehaviour
{
    /*public GameObject estelaPrefab;
    public float intervalo = 0.1f; // Controla la frecuencia de las instancias de la estela
    public float duracionEstela = 1.5f; // Duración total de la estela
    public float velocidadReduccionOpacidad = 1.0f; // Velocidad de reducción de opacidad

    private float tiempoUltimaInstancia;

    void Update()
    {
        // Verifica si ha pasado suficiente tiempo desde la última instancia de la estela
        if (Time.time > tiempoUltimaInstancia + intervalo)
        {
            // Crea una instancia del prefab de estela en la posición actual del mouse
            GameObject estela = Instantiate(estelaPrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);

            // Destruye la estela después de cierto tiempo
            Destroy(estela, duracionEstela);

            // Actualiza el tiempo de la última instancia
            tiempoUltimaInstancia = Time.time;
        }
    }

    void FixedUpdate()
    {
        // Reduce la opacidad de todas las instancias de la estela en cada frame
        GameObject[] estelas = GameObject.FindGameObjectsWithTag("mouseRay");
        foreach (GameObject estela in estelas)
        {
            SpriteRenderer spriteRenderer = estela.GetComponent<SpriteRenderer>();
            Color color = spriteRenderer.color;
            color.a -= velocidadReduccionOpacidad * Time.fixedDeltaTime / duracionEstela;
            spriteRenderer.color = color;
        }
    }*/
}
