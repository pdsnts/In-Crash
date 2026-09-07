using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInteract : MonoBehaviour
{
    private DialogueManager dialogueManager;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    private void Update()
    {
        if (dialogueManager != null && dialogueManager.IsDialogueActive)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray) {
                if (collider.TryGetComponent(out NPCInteractable npcInteractable))
                {
                    npcInteractable.Interact();
                    break;
                }
            }
        }     
    }

    public NPCInteractable GetInteractableObject()
    {
        if (dialogueManager != null && dialogueManager.IsDialogueActive)
        {
            return null;
        }
        List<NPCInteractable> npcInteractableList = new List<NPCInteractable>();
        float interactRange = 4f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out NPCInteractable npcInteractable))
            {
                npcInteractableList.Add(npcInteractable);
                return npcInteractable;
            }
        }

        NPCInteractable closestNPCInteractable = null;
        foreach (NPCInteractable npcInteractable in npcInteractableList)
        {
            if (closestNPCInteractable == null)
            {
                closestNPCInteractable = npcInteractable;
            } else
            {
                if (Vector3.Distance(transform.position, npcInteractable.transform.position) < 
                Vector3.Distance(transform.position, closestNPCInteractable.transform.position))
                {
                    closestNPCInteractable = npcInteractable;
                }
            } 
        }

        return closestNPCInteractable;
    }
}