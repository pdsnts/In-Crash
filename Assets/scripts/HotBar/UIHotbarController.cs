using UnityEngine;

public class UIHotbarController : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public UIHotbarSlot[] slotsUI;

    void Start()
    {
        AtualizarTodaUI();
    }

    void Update()
    {
        AtualizarSelecaoUI();
    }

    public void AtualizarTodaUI()
    {
        if (inventoryManager == null) return;

        for (int i = 0; i < slotsUI.Length; i++)
        {
            if (i < inventoryManager.hotbarSlots.Length)
            {
                ItemData item = inventoryManager.hotbarSlots[i];
                Sprite icone = (item != null) ? item.icon : null;
                slotsUI[i].ConfigurarSlot(icone);
            }
        }
    }

    void AtualizarSelecaoUI()
    {
        if (inventoryManager == null) return;

        for (int i = 0; i < slotsUI.Length; i++)
        {
            bool estaSelecionado = (i == inventoryManager.selectedSlot);
            slotsUI[i].DefinirSelecionado(estaSelecionado);
        }
    }
}