using UnityEngine;

public class ItemWorldInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemData itemData;
    [SerializeField] private string interactText = "Coletar Item";

    public void Interact()
    {
        // Procura o inventário do jogador
        InventoryManager playerInventory = FindObjectOfType<InventoryManager>();

        if (playerInventory != null && itemData != null)
        {
            // Tenta adicionar o item à hotbar
            bool coletou = playerInventory.AdicionarItem(itemData);
            
            if (coletou)
            {
                // Se coube, destrói o objeto no mundo
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Inventário cheio!");
            }
        }
    }

    public string GetInteractText()
    {
        return interactText;
    }
}