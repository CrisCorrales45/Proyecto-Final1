using UnityEngine;
using TMPro; // Para controlar el texto de la burbuja

public class BurbujaRespuesta : MonoBehaviour
{
    [Header("Configuración de la Burbuja")]
    public int valorRespuesta; // El número que vale esta burbuja
    public TextMeshPro textoBurbuja; // El componente de texto hijo

    private MathLevelManager levelManager;

    void Start()
    {
        // Al iniciar, buscamos automáticamente al "cerebro" del nivel
        levelManager = FindFirstObjectByType<MathLevelManager>();

        // Actualizamos el texto visible para que coincida con el valor
        if (textoBurbuja != null)
        {
            textoBurbuja.text = valorRespuesta.ToString();
        }
    }

    // Este evento se activa cuando algo "atraviesa" la burbuja
    private void OnTriggerEnter2D(Collider2D colision)
    {
        // Verificamos si el que la atravesó fue el Jugador
        if (colision.gameObject.CompareTag("Player"))
        {
            // Le enviamos el número de esta burbuja al GameManager
            levelManager.VerificarRespuesta(valorRespuesta);

            // Destruimos la burbuja para que desaparezca con un efecto de sonido visual
            Destroy(gameObject);
        }
    }
}
