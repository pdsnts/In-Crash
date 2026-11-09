using UnityEngine;

public class NPCInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private string interactText = "Falar com NPC";

    public void Interact()
    {
        FindObjectOfType<DialogueManager>().ShowDialogue("Olá, aventureiro!");
    }

    public string GetInteractText()
    {
        return interactText;
    }
}