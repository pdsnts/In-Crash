using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVoice : MonoBehaviour
{
    [Header("Referências")]
    public DialogueManager dialogueManager;

    [Header("Frases do Personagem")]
    [TextArea(2, 4)]
    public string[] frasesAleatorias;

    [Tooltip("Tempo em segundos entre cada fala automática")]
    public float intervaloFalas = 15f;

    void Start()
    {
        // Procura automaticamente o DialogueManager na cena se não estiver atribuído
        if (dialogueManager == null)
        {
            dialogueManager = FindObjectOfType<DialogueManager>();
        }

        // Inicia o ciclo de conversas automáticas se houver frases cadastradas
        if (frasesAleatorias.Length > 0)
        {
            StartCoroutine(CicloDeFalasAutomaticas());
        }
    }

    IEnumerator CicloDeFalasAutomaticas()
    {
        while (true)
        {
            // Espera o tempo configurado antes de dizer a próxima frase
            yield return new WaitForSeconds(intervaloFalas);

            // Só fala se o jogador não estiver já a ver outro diálogo importante
            if (dialogueManager != null && !dialogueManager.IsDialogueActive)
            {
                int index = Random.Range(0, frasesAleatorias.Length);
                string fraseEscolhida = frasesAleatorias[index];

                // Aciona o teu DialogueManager existente para escrever a frase no ecrã
                dialogueManager.ShowDialogue(fraseEscolhida);
            }
        }
    }

    // Podes chamar esta função publicamente quando o jogador fizer algo (ex: apanhar a chave de fenda)
    public void FalarFraseEspecifica(string frase)
    {
        if (dialogueManager != null)
        {
            dialogueManager.ShowDialogue(frase);
        }
    }
}