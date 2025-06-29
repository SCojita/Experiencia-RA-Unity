using UnityEngine;
using Vuforia;
using TMPro;

public class ARController : MonoBehaviour
{
    // Declaración de variables.
    public TextMeshProUGUI txtPulsa;
    public GameObject imgFlecha;
    private ObserverBehaviour observerBehaviour;

    // Método que se llama al inicio del script.
    private void Start()
    {
        observerBehaviour = GetComponent<ObserverBehaviour>(); // Obtenemos el componente ObserverBehaviour. Que es lo que nos permite interactuar con los targets de Vuforia.

        // Comprobamos si el componente ObserverBehaviour está presente.
        if (observerBehaviour)
        {
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged; // Cambiamos el estado del target.
        }

        // Cambiamos el idioma del texto al idioma seleccionado por el usuario.
        LanguageManager.OnLanguageChanged += UpdateLanguage;

        // Actualizamos el idioma al iniciar
        UpdateLanguage(LanguageManager.Instance != null ? LanguageManager.Instance.GetLanguage() : "Español");
    }

    // Método que se llama al destruir el script.
    // Aquí se saldrá del evento de cambio de idioma y del evento de cambio de estado del target.
    private void OnDestroy()
    {
        // Comprobamos si el componente ObserverBehaviour está presente.
        if (observerBehaviour)
        {
            observerBehaviour.OnTargetStatusChanged -= OnTargetStatusChanged; // Cambiamos el estado del target.
        }

        // Nos salimos del evento de cambio de idioma.
        LanguageManager.OnLanguageChanged -= UpdateLanguage;
    }

    // Creamos un método para cambiar el idioma del texto.
    private void UpdateLanguage(string language)
    {
        Debug.Log("Idioma actualizado a: " + language); // Imprimimos el idioma actualizado en la consola (esto es solo para realizar pruebas).

        // Comprobamos si el componente TextMeshProUGUI está presente.
        if (txtPulsa != null)
        {
            // Cambiamos el texto según el idioma seleccionado.
            // En este caso, solo se cambia el texto de la variable txtPulsa.
            switch (language)
            {
                case "Español":
                    txtPulsa.text = "Pulsa";
                    break;
                case "Francés":
                    txtPulsa.text = "Appuie";
                    break;
                case "Inglés":
                    txtPulsa.text = "Tap";
                    break;
                case "Alemán":
                    txtPulsa.text = "Drücken";
                    break;
                case "Italiano":
                    txtPulsa.text = "Premi";
                    break;
                default:
                    txtPulsa.text = "Pulsa";
                    break;
            }
        }
        else
        {
            Debug.LogWarning("txtPulsa no está asignado.");  // Imprimimos una advertencia en la consola si el componente TextMeshProUGUI no está presente.
        }
    }

    // Método que se llama cuando cambia el estado del target.
    // Aquí se comprueba si el target está siendo rastreado o no.
    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        // Comprobamos si el target está siendo rastreado o no.
        // Si el target está siendo rastreado, se activa el texto y la flecha.
        if (targetStatus.Status == Status.TRACKED || 
            targetStatus.Status == Status.EXTENDED_TRACKED)
        {
            txtPulsa.gameObject.SetActive(true);
            imgFlecha.SetActive(true);
        }
        else
        {
            // Si el target no está siendo rastreado, se desactivan el texto y la flecha.
            txtPulsa.gameObject.SetActive(false);
            imgFlecha.SetActive(false);
        }
    }
}