using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public UIHotbarController hotbarUI;

    [Header("Configurações")]
    public int hotbarSize = 5;
    public ItemData[] hotbarSlots;
    public int selectedSlot = 0;

    void Start()
    {
        hotbarSlots = new ItemData[hotbarSize];
    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        // Alternar slots com a roda do mouse
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0f)
        {
            selectedSlot = (selectedSlot - 1 + hotbarSize) % hotbarSize;
            AtualizarSelecao();
        }
        else if (scroll < 0f)
        {
            selectedSlot = (selectedSlot + 1) % hotbarSize;
            AtualizarSelecao();
        }

        // Alternar slots com as teclas 1 a 5
        for (int i = 0; i < hotbarSize; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                selectedSlot = i;
                AtualizarSelecao();
            }
        }
    }

    void AtualizarSelecao()
    {
        // Aqui você pode adicionar a lógica visual para mostrar qual slot está ativo na UI
        Debug.Log("Slot selecionado: " + selectedSlot);
    }

    // Método para coletar itens pelo mundo
public bool AdicionarItem(ItemData novoItem)
{
    for (int i = 0; i < hotbarSize; i++)
    {
        if (hotbarSlots[i] == null)
        {
            hotbarSlots[i] = novoItem;
            
            // Atualiza a UI se a referência estiver atribuída
            if (hotbarUI != null)
            {
                hotbarUI.AtualizarTodaUI();
            }
            
            return true;
        }
    }

    return false;
}
}
