using UnityEngine;

public class ItemWorldInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemData itemData;
    [SerializeField] private string interactText = "Coletar Item";
    
    [Header("Diálogo ao Coletar")]
    [TextArea(2, 4)]
    [SerializeField] private string falaAoColetar; // Escreves a frase personalizada no Inspector!

    public void Interact()
    {
        // 1. Procura o inventário do jogador
        InventoryManager playerInventory = FindObjectOfType<InventoryManager>();

        if (playerInventory != null && itemData != null)
        {
            // Tenta adicionar o item à hotbar
            bool coletou = playerInventory.AdicionarItem(itemData);

            if (coletou)
            {
                // Se o inventário coube o item, mostra a fala (se houver uma escrita)
                if (!string.IsNullOrEmpty(falaAoColetar))
                {
                    DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
                    if (dialogueManager != null)
                    {
                        dialogueManager.ShowDialogue(falaAoColetar);
                    }
                }

                // Se coube, destrói o objeto no mundo
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Inventário cheio!");
            }
        }
        if (QuestManager.Instance != null)
{
    QuestManager.Instance.TentarProgredirQuestItem(itemData);
}
    }

    public string GetInteractText()
    {
        return interactText;
    }
}