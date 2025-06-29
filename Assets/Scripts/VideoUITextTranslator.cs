using UnityEngine;
using TMPro;

public class VideoUITextTranslator : MonoBehaviour
{
    // Declaración de variables.
    public TextMeshProUGUI txtVolver;
    public TextMeshProUGUI txtInfo;

    private void Start()
    {
        LanguageManager.OnLanguageChanged += UpdateLanguage; // Actualizamos el idioma cuando cambia.

        // Aplica el idioma actual al iniciar
        UpdateLanguage(LanguageManager.Instance != null ? LanguageManager.Instance.GetLanguage() : "Español");
    }


    // Método para destruir el objeto y evitar fugas de memoria.	
    private void OnDestroy()
    {
        LanguageManager.OnLanguageChanged -= UpdateLanguage;
    }

    // Método para actualizar el texto según el idioma seleccionado.
    private void UpdateLanguage(string language)
    {
        // Verificamos el idioma y actualizamos los textos correspondientes.
        switch (language)
        {
            case "Español":
                txtVolver.text = "Volver";
                txtInfo.text = "Más información";
                break;
            case "Inglés":
                txtVolver.text = "Back";
                txtInfo.text = "More info";
                break;
            case "Francés":
                txtVolver.text = "Retour";
                txtInfo.text = "Plus d’infos";
                break;
            case "Alemán":
                txtVolver.text = "Zurück";
                txtInfo.text = "Mehr Infos";
                break;
            case "Italiano":
                txtVolver.text = "Torna";
                txtInfo.text = "Maggiori info";
                break;
            default:
                txtVolver.text = "Volver";
                txtInfo.text = "Más información";
                break;
        }
    }
}