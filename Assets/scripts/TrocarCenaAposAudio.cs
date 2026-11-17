using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para gerenciar cenas

public class TrocarCenaAposAudio : MonoBehaviour
{
    [Header("Configurações")]
    public AudioSource audioSource; // Arraste seu AudioSource aqui no Inspetor
    public string nomeDaProximaCena; // Nome exato da cena para onde deseja ir

    private bool audioJaTerminou = false;

    void Start()
    {
        // Se o AudioSource não foi atribuído no Inspetor, tenta pegar no mesmo objeto
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Garante que o áudio começou a tocar
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    void Update()
    {
        // Verifica se o AudioSource existe, se está tocando e se já terminou
        if (audioSource != null && !audioJaTerminou)
        {
            // Se o áudio estava tocando e agora parou (e o tempo chegou ao fim)
            if (!audioSource.isPlaying && audioSource.time >= audioSource.clip.length)
            {
                audioJaTerminou = true;
                MudarDeCena();
            }
        }
    }

    void MudarDeCena()
    {
        Debug.Log("O áudio acabou! Trocando de cena...");
        SceneManager.LoadScene(nomeDaProximaCena);
    }
}