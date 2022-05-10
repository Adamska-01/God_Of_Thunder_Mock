using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public enum SFXType
    {
        AppleEat,
        Death,
        DrainMagic,
        JewelCollect,
        Negative,
        Play,
        PlayerHurt,
        HammerHit,
        TypeWriter,
        Unlock,
        Whoosh,
        HitEnemy,
        Potion,
        Key,
        Victory
    }

    public List<SFXType> clipNames = new List<SFXType>();
    public List<AudioClip> clipList = new List<AudioClip>();

    private Dictionary<SFXType, AudioClip> SFX_Lib =
            new Dictionary<SFXType, AudioClip>();

    public GameObject SFX_Prefab;

    public static SFXManager GlobalAudioMix;

    // Start is called before the first frame update
    void Start()
    {
        GlobalAudioMix = this;

        for (int i = 0; i < clipNames.Count; i++)
        {
            SFX_Lib.Add(clipNames[i], clipList[i]);
        }
    }

    public void PlaySFX(SFXType clipName)
    {
        if (SFX_Lib.ContainsKey(clipName))
        {
            AudioSource SFX = Instantiate(SFX_Prefab).GetComponent<AudioSource>();
            SFX.PlayOneShot(SFX_Lib[clipName]);
            Destroy(SFX.gameObject, SFX_Lib[clipName].length);
        }
    }

    public AudioSource PlayAndReturnSFX(SFXType clipName)
    {
        if (SFX_Lib.ContainsKey(clipName))
        {
            AudioSource SFX = Instantiate(SFX_Prefab).GetComponent<AudioSource>();
            SFX.PlayOneShot(SFX_Lib[clipName]);
            Destroy(SFX.gameObject, SFX_Lib[clipName].length);

            return SFX;
        }

        return null;
    }
}

