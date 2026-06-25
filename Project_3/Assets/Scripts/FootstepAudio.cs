using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepAudio : MonoBehaviour
{
    public AudioSource footstepSource;
    public AudioClip[] footstepClips;
    public void PlayFootstep()
    {
        if(footstepClips.Length == 0)
            return;
        int index = Random.Range(0, footstepClips.Length);
        footstepSource.PlayOneShot(footstepClips[index]);
    }
}
