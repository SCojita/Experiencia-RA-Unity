using UnityEngine;
using UnityEngine.SceneManagement;

public class LanguageSelectionManager : MonoBehaviour
{
    // Método para decirle al LanguageManager que el idioma ha cambiado
    public void SetLanguage(string language)
    {
        // Si el LanguageManager existe, establecemos el idioma que toca.
        if (LanguageManager.Instance != null)
        {
            LanguageManager.Instance.SetLanguage(language);
        }

        // Cargamos la escena principal.
        SceneManager.LoadScene("MainARScene");
    }
}