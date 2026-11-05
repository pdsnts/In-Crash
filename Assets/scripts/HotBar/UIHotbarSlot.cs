using UnityEngine;
using UnityEngine.UI;

public class UIHotbarSlot : MonoBehaviour
{
    public Image iconImage;
    public Image highlightBorder;

    public void ConfigurarSlot(Sprite icone)
    {
        if (icone != null)
        {
            iconImage.sprite = icone;
            iconImage.enabled = true;
        }
        else
        {
            iconImage.sprite = null;
            iconImage.enabled = false;
        }
    }

    public void DefinirSelecionado(bool estaSelecionado)
    {
        if (highlightBorder != null)
        {
            highlightBorder.enabled = estaSelecionado;
        }
    }
}