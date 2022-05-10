using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelDialogue : MonoBehaviour
{
    public int min = 6;
    public int max = 6;

    public Grid background;
    private bool canCloseDialogue = false;


    void Start()
    {
        background.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Dialogue.dialogueMngr.GetIndex() > max && 
            Dialogue.dialogueMngr.GetDuringDialogue() && canCloseDialogue )
        {
            EndDialogue();
        }
    }

    //start is called in UnlockJewel before it destroys
    public void StartDialogue()
    { 
        Time.timeScale = 0;
        canCloseDialogue = true;

        Dialogue.dialogueMngr.SetIndex(min);
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
