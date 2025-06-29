using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using System.Collections;

public class VideoSceneController : MonoBehaviour
{
    public string url = "https://palaciosalort.com";
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;

    public void VolverAEscenaAR()
    {
        SceneManager.LoadScene("MainARScene");
    }

    public void AbrirURL()
    {
        StartCoroutine(PausarYIrALink());
    }

    private IEnumerator PausarYIrALink()
    {
        if (videoPlayer != null)
            videoPlayer.Stop();

        if (audioSource != null)
            audioSource.Stop();

        yield return null; // Esperar un frame

        Application.OpenURL(url);
    }
}