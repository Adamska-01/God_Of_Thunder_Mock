using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    private Coroutine coroutine;
    private bool duringDialogue = false;

    public static Dialogue dialogueMngr;
    private AudioSource clip;


    void Start()
    {
        dialogueMngr = this;

        textDisplay.gameObject.SetActive(false);
    }

    //make waitforseconds ignore timescale = 0
    public IEnumerator WaitForRealSeconds(float time)
    {
        float start = Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < start + time)
        {
            yield return null;
        }
    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            clip = SFXManager.GlobalAudioMix.PlayAndReturnSFX(SFXManager.SFXType.TypeWriter);

            textDisplay.text += letter;
           
            yield return StartCoroutine(WaitForRealSeconds(typingSpeed));
        }
    }

    public void NextSentence()
    {
        if (textDisplay.text == sentences[index])
        {
            if (index < sentences.Length - 1)
            {
                ++index;
                textDisplay.text = string.Empty;
                coroutine = StartCoroutine(Type());
            }
            else
            {
                textDisplay.text = string.Empty;
            }
        }
        else
        {
            StopCoroutine(coroutine);
            textDisplay.text = sentences[index];
        }
    }

    public void StartDialogue()
    {
        textDisplay.text = string.Empty;
        coroutine = StartCoroutine(Type());
    }

    public void ResetText()
    {
        textDisplay.text = string.Empty;
        StopCoroutine(coroutine);
    }

    public void ToggleText()
    {
        textDisplay.gameObject.SetActive(!textDisplay.gameObject.activeSelf);
    }

    public void ToggleDuringDialogue()
    {
        duringDialogue = !duringDialogue;
    }

    public void SetIndex(int p_index)
    {
        index = p_index;
    }  

    public bool GetDuringDialogue()
    {
        return duringDialogue;
    }
    
    public int GetIndex()
    {
        return index;
    }
}
