using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingAudio : MonoBehaviour
{
    public AudioSource gunshotSource;
    public float fightMusicDuration = 8f;
    private float fightTimer;
    public void Shoot()
    {
        gunshotSource.Play();
        AudioManager.instance.PlayMusic(MusicState.Fight);
        fightTimer = fightMusicDuration;
    }

    // Update is called once per frame
    private void Update()
    {
        if(fightTimer > 0f)
        {
            fightTimer -= Time.deltaTime;
            if(fightTimer <= 0f)
            {
                AudioManager.instance.PlayMusic(MusicState.Default);
            }
        }
    }
}
