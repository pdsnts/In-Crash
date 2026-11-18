using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    [Header("Configuração da Quest")]
    [SerializeField] private QuestData questParaAtivar;
    [TextArea] [SerializeField] private string mensagemAoAtivar;

    private bool jaFoiAtivado = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!jaFoiAtivado && other.CompareTag("Player"))
        {
            if (questParaAtivar != null && QuestManager.Instance != null)
            {
                // Inicia a quest sem a marcar como concluída
                QuestManager.Instance.questAtual = questParaAtivar;
                questParaAtivar.questConcluida = false;
                questParaAtivar.quantidadeAtual = 0;

                // Mostra o diálogo inicial, se houver
                if (!string.IsNullOrEmpty(mensagemAoAtivar))
                {
                    DialogueManager dm = FindObjectOfType<DialogueManager>();
                    if (dm != null)
                    {
                        dm.ShowDialogue(mensagemAoAtivar);
                    }
                }

                jaFoiAtivado = true;
                gameObject.SetActive(false); // Desativa o trigger para não repetir
            }
        }
    }
}