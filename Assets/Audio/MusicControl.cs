using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MusicControl : MonoBehaviour
{
    public float TimeToTransition;

    public AudioMixerSnapshot MenuMusic;
    public AudioMixerSnapshot GameMusic;
    public AudioMixerSnapshot NoMusic;

    public static MusicControl controlMusic;


    void Start()
    {
        controlMusic = this;
    }

    public void transitToMenuMusic()
    {
        MenuMusic.TransitionTo(0);
    }
    
    public void transitToGameMusic()
    {
        GameMusic.TransitionTo(0);
    }

    public void transitToNoMusic()
    {
        NoMusic.TransitionTo(0);
    }

    public void noMusic()
    {
        NoMusic.TransitionTo(0);
    }
}
