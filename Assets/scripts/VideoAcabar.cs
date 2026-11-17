using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Video;

public class VideoAcaba : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public RawImage rawimage;
    public float TempoDelay;

    void Start()
    {
        // Obtém o componente VideoPlayer no mesmo objeto
        videoPlayer = GetComponent<VideoPlayer>();

        if (videoPlayer != null)
        {
            // Inscreve o método no evento loopPointReached
            videoPlayer.loopPointReached += OnVideoFinished;
        }

        Invoke("PlaySoundCrash", TempoDelay);
    }

    // Método chamado automaticamente quando o vídeo acaba
    void OnVideoFinished(VideoPlayer vp)
    {
        Debug.Log("O vídeo terminou de ser reproduzido!");
       rawimage.enabled = false;
    }

    void OnDestroy()
    {
        // Boa prática: remove a inscrição do evento ao destruir o objeto para evitar vazamentos de memória
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= OnVideoFinished;
        }
    }

    void PlaySoundCrash ()
    {
        GetComponent<AudioSource>().Play();
    }
}