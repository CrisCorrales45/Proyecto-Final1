using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Métodos para cargar cada nivel
    public void LoadMathLevel()
    {
        SceneManager.LoadScene("Level_Math");
    }

    public void LoadScienceLevel()
    {
        SceneManager.LoadScene("Level_Science");
    }

    public void LoadSocialLevel()
    {
        SceneManager.LoadScene("Level_Social");
    }

    public void LoadEnglishLevel()
    {
        SceneManager.LoadScene("Level_English");
    }

    public void QuitGame()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
