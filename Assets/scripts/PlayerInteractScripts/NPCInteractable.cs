using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    [SerializeField] private string interactText;
    public void Interact()
    {
        FindObjectOfType<DialogueManager>().ShowDialogue("Olá, aventureiro!");
    }

    public string  GetInteractText()
    {
        return interactText;
    }
}
