using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CargarEscenaPorTarget : MonoBehaviour
{
    // Declaración de variables.
    public Transform imageTarget;
    public string escenaADesplegar;

    void Update()
    {
        // Si el ratón está disponible y se presiona el botón izquierdo, o si hay un toque en la pantalla,
        // se detecta el toque en el objeto especificado.
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            DetectarToque(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue())); // Detectamos toque con el ratón
        }

        // Verificamos si hay un toque en la pantalla táctil.
        // Si hay un toque, se detecta el toque en el objeto especificado.
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue(); // Obtenemos la posición del toque
            DetectarToque(Camera.main.ScreenPointToRay(touchPosition)); // Detectamos toque con la pantalla táctil
        }
    }

    // Método para detectar el toque en el objeto especificado.
    private void DetectarToque(Ray ray)
    {
        RaycastHit hit; // Variable para almacenar el resultado del raycast

        // Realizamos un raycast desde la cámara hacia el objeto especificado.
        // Si el raycast colisiona con el objeto, se carga la escena especificada.
        if (Physics.Raycast(ray, out hit))
        {
            // Verificamos si el objeto tocado es el imageTarget.
            // Si es así, se carga la escena especificada.
            if (hit.transform == imageTarget)
            {
                SceneManager.LoadScene(escenaADesplegar);
            }
        }
    }
}
