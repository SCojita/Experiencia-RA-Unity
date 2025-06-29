using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    // Declaración de variables.
    public static LanguageManager Instance;
    [SerializeField] private string selectedLanguage = "Español"; // Idioma por defecto. Lo hacemos SerializeField para poder cambiarlo desde el editor.
    public delegate void LanguageChanged(string newLanguage); 
    public static event LanguageChanged OnLanguageChanged;

    // Método Awake para inicializar el singleton.
    // Este método se llama cuando el script se inicializa.
    private void Awake()
    {
        // Comprobar si ya existe una instancia de LanguageManager.
        // Si no existe, se asigna esta instancia a la variable estática Instance.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // No destruimos el objeto al cargar una nueva escena.
        }
        else
        {
            Destroy(gameObject); // Si ya existe una instancia, destruimos este objeto para evitar duplicados.
        }
    }

    // Creamos un método para establecer el idioma seleccionado.
    public void SetLanguage(string language)
    {
        selectedLanguage = language; // Asignamos el idioma seleccionado a la variable.
        Debug.Log("Idioma seleccionado: " + selectedLanguage); // Imprimimos el idioma seleccionado en la consola.

        // Llamamos al evento OnLanguageChanged para notificar a otros scripts que el idioma ha cambiado.
        OnLanguageChanged?.Invoke(selectedLanguage);
    }

    // Creamos un método para obtener el idioma seleccionado.
    public string GetLanguage()
    {
        return selectedLanguage;
    }
    
}
