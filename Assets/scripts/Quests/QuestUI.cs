using UnityEngine;
using TMPro;

public class QuestUI : MonoBehaviour
{
    [Header("Elementos de UI")]
    [SerializeField] private GameObject painelQuest; // O painel visual no ecrã
    [SerializeField] private TextMeshProUGUI textoTitulo;
    [SerializeField] private TextMeshProUGUI textoProgresso;

    void Update()
    {
        if (QuestManager.Instance != null && QuestManager.Instance.questAtual != null)
        {
            QuestData quest = QuestManager.Instance.questAtual;

            // Se a quest estiver ativa, mostra o painel e atualiza os textos
            if (!quest.questConcluida)
            {
                if (painelQuest != null) painelQuest.SetActive(true);

                if (textoTitulo != null)
                    textoTitulo.text = quest.tituloQuest;

                if (textoProgresso != null)
                    textoProgresso.text = $"{quest.descricao} ({quest.quantidadeAtual}/{quest.quantidadeNecessaria})";
            }
            else
            {
                // Se terminou, esconde o painel da quest atual
                if (painelQuest != null) painelQuest.SetActive(false);
            }
        }
        else
        {
            if (painelQuest != null) painelQuest.SetActive(false);
        }
    }
}