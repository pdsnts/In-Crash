using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    [Header("Quest Ativa Atual")]
    public QuestData questAtual;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // Chamado quando o jogador coleta um item
    public void TentarProgredirQuestItem(ItemData itemColetado)
    {
        if (questAtual != null && !questAtual.questConcluida)
        {
            if (questAtual.itemNecessario == itemColetado)
            {
                questAtual.quantidadeAtual++;
                Debug.Log($"Progresso da Quest ({questAtual.tituloQuest}): {questAtual.quantidadeAtual}/{questAtual.quantidadeNecessaria}");

                if (questAtual.quantidadeAtual >= questAtual.quantidadeNecessaria)
                {
                    ConcluirQuest();
                }
            }
        }
    }

    public void ConcluirQuest()
    {
        if (questAtual != null)
        {
            questAtual.questConcluida = true;
            Debug.Log($"Quest Concluída: {questAtual.tituloQuest}!");
            
            // Aqui podes disparar um diálogo de vitória ou abrir a próxima parte da história
            DialogueManager dm = FindObjectOfType<DialogueManager>();
            if (dm != null)
            {
                dm.ShowDialogue("Missão concluída: " + questAtual.tituloQuest);
            }
        }
    }
}   