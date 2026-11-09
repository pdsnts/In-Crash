using UnityEngine;

public class ItemInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string interactText = "Coletar Item";
    [SerializeField] private ItemData itemData;

    public void Interact()
    {
        InventoryManager playerInventory = FindObjectOfType<InventoryManager>();

        if (playerInventory != null && itemData != null)
        {
            bool coletou = playerInventory.AdicionarItem(itemData);
            if (coletou)
            {
                Destroy(gameObject);
            }
        }
    }

    public string GetInteractText()
    {
        return interactText;
    }
}