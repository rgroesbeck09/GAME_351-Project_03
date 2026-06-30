using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MusicState
{
    Default,
    Suspense,
    Fight, 
    Supply
}

public class AudioManager: MonoBehaviour
{

    public static AudioManager instance;
    [Header("Music Sources")]
    public AudioSource deafulttrack;
    public AudioSource suspensetrack;
    public AudioSource fighttrack;
    public AudioSource supplyStoreTrack;

    [Header("Fade Settings")]
    public float fadeTime = 1.5f;

    private MusicState currentState;
    private Coroutine fadeRoutine;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Debug.LogError("Duplicate AudioManager", gameObject);
    }

    // Start is called before the first frame update 
    private void Start()
    {
        currentState = MusicState.Default;
        deafulttrack.volume = .5f;
        deafulttrack.Play();
    }

    public void PlayMusic(MusicState newState)
    {
        //Debug.Log("PlayMusic called with: " + newState);
        if(newState == currentState)
            return;
        currentState = newState;
        if(fadeRoutine != null)
            StopCoroutine(fadeRoutine);
        fadeRoutine = StartCoroutine(FadeToTrack(newState));
    }
    
    private IEnumerator FadeToTrack(MusicState newState) 
    {
        AudioSource target = GetSource(newState);
        AudioSource[] allSources = {deafulttrack, suspensetrack, fighttrack, supplyStoreTrack};

        foreach (AudioSource source in allSources)
        {
            if(source != target && source.isPlaying)
                StartCoroutine(FadeOut(source));
        }

        target.volume = 0f;
        if (!target.isPlaying)
            target.Play();
        float timer = 0f;
        while(timer < fadeTime)
        {
            timer += Time.deltaTime;
            target.volume = Mathf.Lerp(0f, 1f, timer/fadeTime);
            yield return null;
        }
        target.volume = .5f;
    }

    private IEnumerator FadeOut(AudioSource source)
    {
        float startVolume = source.volume;
        float timer = 0f;
        while(timer < fadeTime)
        {
            timer += Time.deltaTime;
            source.volume = Mathf.Lerp(startVolume, 0f, timer/fadeTime);
            yield return null;
        }
        source.Stop();
        source.volume = .5f;
    }

    private AudioSource GetSource(MusicState state)
    {
        switch(state)
        {
            case MusicState.Suspense:
                return suspensetrack;
            case MusicState.Fight:
                return fighttrack;
            case MusicState.Supply:
                return supplyStoreTrack;
            default:
                return deafulttrack;
        }
    }
}
