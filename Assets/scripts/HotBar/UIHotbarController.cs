using System.Collections.Generic;
using UnityEngine;

public class UIHotbarController : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private List<UIHotbarSlot> hotbarSlots;

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (inventoryManager == null) return;

        for (int i = 0; i < hotbarSlots.Count; i++)
        {
            // Lê diretamente do array hotbarSlots do InventoryManager
            ItemData item = inventoryManager.hotbarSlots[i];
            
            if (item != null)
            {
                hotbarSlots[i].UpdateSlot(item);
            }
            else
            {
                hotbarSlots[i].UpdateSlot(null);
            }
        }
    }
}