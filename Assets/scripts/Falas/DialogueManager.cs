using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;

    [Header("Configurações do Texto")]
    [SerializeField] private float typingSpeed = 0.04f;

    public bool IsDialogueActive { get; private set; }
    
    private Coroutine typingCoroutine;
    private string currentFullText;
    private bool isTyping;
    private bool justOpened;

    public void ShowDialogue(string text)
    {
        dialogueText.text = "";
        dialoguePanel.SetActive(true);
        IsDialogueActive = true;
        justOpened = true;

        currentFullText = text;

        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        typingCoroutine = StartCoroutine(TypeSentence(text));
    }

    private IEnumerator TypeSentence(string text)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in text.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    public void HideDialogue()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        dialoguePanel.SetActive(false);
        IsDialogueActive = false;
        isTyping = false;
    }

    private void LateUpdate()
    {
        if (!IsDialogueActive) return;

        if (justOpened)
        {
            justOpened = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isTyping)
            {
                StopCoroutine(typingCoroutine);
                dialogueText.text = currentFullText;
                isTyping = false;
            }
            else
            {
                HideDialogue();
            }
        }
    }
}