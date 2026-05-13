using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Configuración")]
    public Transform objetivo; // A quién va a seguir (el jugador)
    public float velocidadSuavizado = 5f; // Qué tan rápido lo sigue
    public Vector3 compensacion = new Vector3(0f, 1.5f, -10f); // Para que la cámara no esté en los pies y no se acerque en Z

    void FixedUpdate()
    {
        // Si no hay objetivo, no hacemos nada
        if (objetivo == null) return;

        // Calculamos a dónde debería ir la cámara
        Vector3 posicionDeseada = objetivo.position + compensacion;

        // Movemos la cámara suavemente desde donde está hasta donde debería estar
        Vector3 posicionSuavizada = Vector3.Lerp(transform.position, posicionDeseada, velocidadSuavizado * Time.deltaTime);
        transform.position = posicionSuavizada;
    }
}