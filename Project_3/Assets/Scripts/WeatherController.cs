using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    // Public Variables
    public GameObject weather;
    public GameObject lighting;

    // Private Variables
    private float weatherTracker;
    private bool weatherStatus = false;

    // Start is called before the first frame update
    void Start()
    {
        weatherTracker = Random.Range(5f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > weatherTracker)
        {
            // Flips the weather status
            weatherStatus = !weatherStatus;
            weather.SetActive(weatherStatus);

            // turn on/off lighting 
            lighting.SetActive(!weatherStatus);

            // sets the new weather tracker swap
            weatherTracker = Time.time + Random.Range(7f, 10f);
        }
    }
}
