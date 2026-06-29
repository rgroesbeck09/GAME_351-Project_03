using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherController : MonoBehaviour
{
    // Public Variables
    public GameObject weather;

    // Private Variables
    private float weatherTracker;
    private bool weatherStatus = false;

    // Start is called before the first frame update
    void Start()
    {
        weatherTracker = Random.Range(60f, 300f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > weatherTracker)
        {
            // Flips the weather status
            weatherStatus = !weatherStatus;
            weather.SetActive(weatherStatus);

            // sets the new weather tracker swap
            weatherTracker = Time.time + Random.Range(60f, 300f);
        }
    }
}
