using UnityEngine;

public class QuestCompleteTrigger : MonoBehaviour
{
    [Header("Quest a Concluir")]
    [SerializeField] private QuestData questAlvo;
    [TextArea] [SerializeField] private string mensagemAoConcluir;

    private bool jaFoiConcluido = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!jaFoiConcluido && other.CompareTag("Player"))
        {
            if (questAlvo != null && QuestManager.Instance != null)
            {
                // Verifica se esta é a quest ativa atual
                if (QuestManager.Instance.questAtual == questAlvo && !questAlvo.questConcluida)
                {
                    questAlvo.questConcluida = true;
                    Debug.Log("Quest Concluída por Chegar ao Local: " + questAlvo.tituloQuest);

                    // Mostra a mensagem de vitória/conclusão
                    if (!string.IsNullOrEmpty(mensagemAoConcluir))
                    {
                        DialogueManager dm = FindObjectOfType<DialogueManager>();
                        if (dm != null)
                        {
                            dm.ShowDialogue(mensagemAoConcluir);
                        }
                    }

                    jaFoiConcluido = true;
                    gameObject.SetActive(false);
                }
            }
        }
    }
}