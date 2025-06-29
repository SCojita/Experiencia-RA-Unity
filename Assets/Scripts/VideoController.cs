using UnityEngine;
using Vuforia;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    // Declaración de variables.
    public VideoPlayer videoPlayer;
    private ObserverBehaviour observerBehaviour;

    // Método Start se llama al inicio de la cámara.
    private void Start()
    {
        observerBehaviour = GetComponent<ObserverBehaviour>(); // Obtenemos el componente ObserverBehaviour del GameObject al que está adjunto este script.

        // Si el componente ObserverBehaviour está presente, suscribimos el evento OnTargetStatusChanged.
        if (observerBehaviour)
        {
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }

        // Nos aseguramos de que el vídeo esté detenido al inicio.
        videoPlayer.Stop();
    }

    // Método OnDestroy se llama cuando el objeto es destruido.
    private void OnDestroy()
    {
        // Si el componente ObserverBehaviour está presente, desuscribimos el evento OnTargetStatusChanged.
        if (observerBehaviour)
        {
            observerBehaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }

    // Método que se llama cuando cambia el estado del objetivo.
    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        // Comprobamos si el estado del objetivo es TRACKED o EXTENDED_TRACKED.
        if (targetStatus.Status == Status.TRACKED || 
            targetStatus.Status == Status.EXTENDED_TRACKED)
        {
            Debug.Log("Reproduciendo el vídeo de estrellas"); // Mensaje en consola cuando el vídeo comienza a reproducirse.
            videoPlayer.Play(); // Reproducimos el vídeo.
        }
        else
        {
            Debug.Log("Deteniendo el vídeo de estrellas"); // Mensaje en consola cuando el vídeo se detiene.
            videoPlayer.Stop(); // Detenemos el vídeo.
        }
    }
}