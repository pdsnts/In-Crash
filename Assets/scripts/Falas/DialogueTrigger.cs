using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Configuração da Fala")]
    [TextArea(2, 4)]
    [SerializeField] private string fraseParaFalar;

    [Tooltip("Tempo em segundos que a fala fica visível antes de fechar sozinha (0 para não fechar sozinho)")]
    [SerializeField] private float tempoNaTela = 4f;

    private bool jaFoiAtivado = false;

    private void OnTriggerEnter(Collider other)
    {
        // Verifica se foi o jogador a entrar na área e se o trigger ainda não disparou
        if (!jaFoiAtivado && other.CompareTag("Player"))
        {
            DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();

            if (dialogueManager != null && !string.IsNullOrEmpty(fraseParaFalar))
            {
                // Mostra a fala instantaneamente sem precisar de apertar E
                dialogueManager.ShowDialogue(fraseParaFalar);

                // Se quiseres que feche sozinho após alguns segundos:
                if (tempoNaTela > 0f)
                {
                    StartCoroutine(FecharFalaAposTempo(dialogueManager, tempoNaTela));
                }

                // Marca como ativado para não repetir a cada passo
                jaFoiAtivado = true;
            }
        }
    }

    private IEnumerator FecharFalaAposTempo(DialogueManager manager, float tempo)
    {
        yield return new WaitForSeconds(tempo);
        
        // Fecha o diálogo automaticamente se o jogador ainda estiver a ver esta mesma frase
        manager.HideDialogue();
    }
}