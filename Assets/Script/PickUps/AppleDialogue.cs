using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleDialogue : MonoBehaviour
{
    public int indexMin = 9;
    public int indexMax = 9;

    public Grid background;
    private bool canCloseDialogue = false;


    void Start()
    {
        background.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Dialogue.dialogueMngr.GetIndex() > indexMax && 
            Dialogue.dialogueMngr.GetDuringDialogue() && canCloseDialogue)
        {
            EndDialogue();

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartDialogue();
        }
    }

    private void StartDialogue()
    {
        Time.timeScale = 0;
        canCloseDialogue = true;

        Dialogue.dialogueMngr.SetIndex(indexMin);
        
        background.gameObject.SetActive(true);
        Dialogue.dialogueMngr.ToggleDuringDialogue();
        Dialogue.dialogueMngr.ToggleText();
        Dialogue.dialogueMngr.StartDialogue();
    }

    private void EndDialogue()
    {
        Dialogue.dialogueMngr.ToggleText();
        Dialogue.dialogueMngr.ToggleDuringDialogue();
        background.gameObject.SetActive(false);

        Dialogue.dialogueMngr.ResetText();

        Time.timeScale = 1;
        canCloseDialogue = false;
    }
}
