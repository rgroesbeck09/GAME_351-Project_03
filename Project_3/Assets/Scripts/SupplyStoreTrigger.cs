using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyStoreMusicTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            AudioManager.instance.PlayMusic(MusicState.Suspense);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            AudioManager.instance.PlayMusic(MusicState.Default);
        }
    }
}
