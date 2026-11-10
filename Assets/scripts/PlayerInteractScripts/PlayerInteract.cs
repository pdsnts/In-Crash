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

        if (Input.GetKeyDown(KeyCode.E))
        {
            IInteractable interactableObject = GetInteractableObject();
            if (interactableObject != null)
            {
                interactableObject.Interact();
            }
        }
    }

    public IInteractable GetInteractableObject()
    {
        if (dialogueManager != null && dialogueManager.IsDialogueActive)
        {
            return null;
        }

        List<IInteractable> interactableList = new List<IInteractable>();
        float interactRange = 4f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        
        foreach (Collider collider in colliderArray)
        {
            // Procura por qualquer objeto que tenha a interface IInteractable (NPC ou Item)
            if (collider.TryGetComponent(out IInteractable interactable))
            {
                interactableList.Add(interactable);
            }
        }

        IInteractable closestInteractable = null;
        foreach (IInteractable interactable in interactableList)
        {
            if (closestInteractable == null)
            {
                closestInteractable = interactable;
            }
            else
            {
                // Compara as distâncias para escolher o interagível mais próximo
                Transform interactableTransform = (interactable as MonoBehaviour).transform;
                Transform closestTransform = (closestInteractable as MonoBehaviour).transform;

                if (Vector3.Distance(transform.position, interactableTransform.position) <
                    Vector3.Distance(transform.position, closestTransform.position))
                {
                    closestInteractable = interactable;
                }
            }
        }

        return closestInteractable;
    }
}