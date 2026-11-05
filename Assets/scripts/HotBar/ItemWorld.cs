using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public ItemData itemData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryManager inventory = other.GetComponent<InventoryManager>();
            if (inventory != null)
            {
                bool coletou = inventory.AdicionarItem(itemData);
                if (coletou)
                {
                    Destroy(gameObject); // Remove o item do mundo ao coletar
                }
            }
        }
    }
}