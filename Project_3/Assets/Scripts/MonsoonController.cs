using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsoonController : MonoBehaviour
{
    // public variables
    public ParticleSystem rain;

    public Transform player;

    [Range(100, 20000)]
    public float rainRate = 1000;

    public Light lightningLight;
    public AudioSource thunderAudio;
    public AudioSource windAudio;
    public AudioSource rainAudio;
    public float minLightningTime = 5f;
    public float maxLightningTime = 15f;
    public GameObject lightningBolt;

    // private variables
    private float monsoonTracker;
    private bool monsoonOn = false;

    void Start()
    {
        monsoonTracker = Random.Range(60f, 300f);

        /* start lightning
        StartCoroutine(LightningRoutine());

        // start wind audio
        windAudio.Play();

        // start rain
        var emission = rain.emission;
        emission.rateOverTime = rainRate;
        // start rain audio
        rainAudio.Play();*/
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > monsoonTracker)
        {
            Debug.Log("I made it here" + monsoonOn);
            if (!monsoonOn)
            {
                Debug.Log("I made the rain");

                // start lightning
                StartCoroutine(LightningRoutine());

                // start wind audio
                windAudio.Play();

                // start rain
                var emission = rain.emission;
                emission.rateOverTime = rainRate;

                // start rain audio
                rainAudio.Play();

                // set monsoon tracker
                monsoonTracker = Random.Range(60f, 300f);
            }
            else
            {
                Debug.Log("I stopped the rain");

                StopCoroutine(LightningRoutine());

                windAudio.Stop();

                // start rain
                var emission = rain.emission;
                emission.rateOverTime = 0;
                
                // start rain audio
                rainAudio.Play();

                // set monsoon tracker
                monsoonTracker = Random.Range(60f, 300f);
            }
        }
        
    }

    void LateUpdate()
    {
        transform.position = new Vector3(
            player.position.x, transform.position.y,
            player.position.z);
    }

    // lightning flash coroutine
    IEnumerator LightningRoutine()
    {
        while(true)
        {
            float waitTime = Random.Range(minLightningTime, maxLightningTime);
            yield return new WaitForSeconds(waitTime);

            // first lightning bolt 
            lightningBolt.SetActive(true);
            // random location for bolt strike
            Vector3 pos = lightningBolt.transform.localPosition;
            pos.x = Random.Range(-30f, 30f);
            //pos.y = Random.Range(20f, 60f);
            lightningBolt.transform.localPosition = pos;

            // first lightning flash
            lightningLight.enabled = true;
            yield return new WaitForSeconds(0.06f);
            lightningBolt.SetActive(false);
            lightningLight.enabled = false;
            yield return new WaitForSeconds(0.08f);

            // second lightning bolt 
            lightningBolt.SetActive(true);
            // random location for bolt strike
            pos.x = Random.Range(-30f, 30f);
            //pos.y = Random.Range(20f, 60f);
            lightningBolt.transform.localPosition = pos;

            // second lightning flash
            lightningLight.enabled = true;
            yield return new WaitForSeconds(0.04f);
            lightningBolt.SetActive(false);
            lightningLight.enabled = false;

            // create a delay before thunder
            yield return new WaitForSeconds(Random.Range(0.5f, 2f));

            // play thunder audio
            thunderAudio.Play();
        }
    }
}
