using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    private float transitionTime = 1.8f; 

    public void LoadNextLevel()
    {
        SFXManager.GlobalAudioMix.PlaySFX(SFXManager.SFXType.Play);

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadCurrentScene()
    {
        SFXManager.GlobalAudioMix.PlaySFX(SFXManager.SFXType.Play);
        
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void LoadMenu()
    {
        SFXManager.GlobalAudioMix.PlaySFX(SFXManager.SFXType.Play);

        StartCoroutine(LoadLevel(0));
    }

    public void ExitApp()
    {
        SFXManager.GlobalAudioMix.PlaySFX(SFXManager.SFXType.Negative);

        Application.Quit(0);
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        Time.timeScale = 1; //allows Restarting after winning

        //play animation
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        //Load scene
        SceneManager.LoadScene(levelIndex);

        if (levelIndex > 0)
            MusicControl.controlMusic.transitToGameMusic();
        else
            MusicControl.controlMusic.transitToMenuMusic();
    }
}
