using UnityEngine;

[CreateAssetMenu(fileName = "NovaQuest", menuName = "Quests/QuestData")]
public class QuestData : ScriptableObject
{
    public string questID;
    public string tituloQuest;
    [TextArea] public string descricao;
    
    public ItemData itemNecessario; // O item que ele precisa coletar (opcional)
    public int quantidadeNecessaria = 1;
    [HideInInspector] public int quantidadeAtual = 0;
    
    public bool questConcluida = false;
}