using System.Collections.Generic; // Necesario para usar Listas
using UnityEngine;
using TMPro;

// Este bloque crea nuestro propio "molde" para las preguntas
[System.Serializable]
public class PreguntaMatematica
{
    public string laPregunta;
    public int laRespuestaCorrecta;
}

public class MathLevelManager : MonoBehaviour
{
    [Header("Textos en Pantalla")]
    public TextMeshProUGUI textoPregunta;
    public TextMeshProUGUI textoPuntos;
    public TextMeshProUGUI textoVidas;

    [Header("Datos del Juego")]
    public int vidas = 3;
    public int puntos = 0;

    [Header("Lista de Preguntas")]
    // Aquí guardaremos todas las preguntas del nivel
    public List<PreguntaMatematica> listaPreguntas;
    private int indicePreguntaActual = 0; // Para saber en qué pregunta vamos

    void Start()
    {
        MostrarPreguntaActual();
        ActualizarUI();
    }

    void MostrarPreguntaActual()
    {
        // Revisamos si aún nos quedan preguntas en la lista
        if (indicePreguntaActual < listaPreguntas.Count)
        {
            // Mostramos la pregunta que toca
            textoPregunta.text = listaPreguntas[indicePreguntaActual].laPregunta;
        }
        else
        {
            // Si ya respondimos todas... ¡Ganamos!
            textoPregunta.text = "¡NIVEL COMPLETADO!";
            // Aquí luego pondremos código para pasar al siguiente nivel
        }
    }

    public void VerificarRespuesta(int respuestaJugador)
    {
        // Si ya no hay preguntas o perdimos, no hacemos nada
        if (indicePreguntaActual >= listaPreguntas.Count || vidas <= 0) return;

        // Buscamos cuál es la respuesta correcta de la pregunta de AHORA
        int correcta = listaPreguntas[indicePreguntaActual].laRespuestaCorrecta;

        if (respuestaJugador == correcta)
        {
            Debug.Log("¡Respuesta Correcta!");
            puntos += 10;
            indicePreguntaActual++; // Avanzamos a la siguiente pregunta
            MostrarPreguntaActual(); // Cambiamos el texto en pantalla
        }
        else
        {
            Debug.Log("Respuesta Incorrecta...");
            vidas -= 1;

            if (vidas <= 0)
            {
                textoPregunta.text = "¡GAME OVER!";
                // Aquí luego pondremos código para reiniciar el nivel
            }
        }

        ActualizarUI();
    }

    void ActualizarUI()
    {
        textoPuntos.text = "Puntos: " + puntos;
        textoVidas.text = "Vidas: " + vidas;
    }
}