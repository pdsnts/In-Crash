using UnityEngine;
using UnityEngine.UI;

public class UIHotbarSlot : MonoBehaviour
{
    [SerializeField] private Image iconImage; // O componente de imagem que arrastaste no passo anterior

    public void UpdateSlot(ItemData item)
    {
        if (item != null && item.icon != null)
        {
            iconImage.sprite = item.icon; // Define a imagem do item (ex: a caixa)
            iconImage.gameObject.SetActive(true); // Liga o desenho na tela
        }
        else
        {
            iconImage.sprite = null;
            iconImage.gameObject.SetActive(false); // Esconde o ícone se o slot estiver vazio
        }
    }
}
