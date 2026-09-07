using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    public void Interact()
    {
        FindObjectOfType<DialogueManager>().ShowDialogue("Olá, aventureiro!");
    }
}
