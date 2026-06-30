using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyStoreMusicTrigger : MonoBehaviour
{
    //public MusicState musicToPlay;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Debug.Log("PLayer Confirmed - Switching Music");
            //Debug.Log("HIT TRIGGER OBJECT: " + gameObject.name);
            //Debug.Log("HIT BY: " + other.name);
            AudioManager.instance.PlayMusic(MusicState.Supply);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //Debug.Log("PLayer Confirmed - Switching Music");
            AudioManager.instance.PlayMusic(MusicState.Default);
        }
    } 
}
