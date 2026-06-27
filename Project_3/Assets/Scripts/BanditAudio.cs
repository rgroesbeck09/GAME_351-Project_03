using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditAudio : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource audioSource;

    [Header("Taunts")]
    public AudioClip[] taunts;
    public float minTauntDelay = 10f;
    public float maxTauntDelay = 30f;

    [Header("Pain / Death")]
    public AudioClip[] painSounds;
    public AudioClip[] deathSounds;

    private void Start()
    {
        ScheduleNextTaunt();
    }

    private void ScheduleNextTaunt()
    {
        float delay = Random.Range(minTauntDelay, maxTauntDelay);
        Invoke(nameof(PlayRandomTaunt), delay);
    }

    private void PlayRandomTaunt()
    {
        PlayRandomClip(taunts);
        ScheduleNextTaunt();
    }

    public void PlayPainSound()
    {
        PlayRandomClip(painSounds);
    }

    public void PlayDeathSound()
    {
        PlayRandomClip(deathSounds);
        CancelInvoke();
    }

    private void PlayRandomClip(AudioClip[] clips)
    {   
        if(clips == null || clips.Length == 0)
            return;
        int index = Random.Range(0, clips.Length);
        audioSource.PlayOneShot(clips[index]);
    }
}
