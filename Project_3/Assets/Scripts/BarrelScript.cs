using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    // get the debris game object
    public GameObject debris;

    // Serialize for making it a prefab
    [SerializeField] private ParticleSystem explosionTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision hit: " + collision.gameObject.name);
    }


    // Create Explosion launch
    public void explode()
    {
        // create an instance of the explosion
        ParticleSystem explosion = Instantiate(
            explosionTime,
            transform.position,
            Quaternion.identity
            );

        explosion.Play();

        // remove explosion once done
        Destroy(explosion.gameObject, 
            explosion.main.duration + explosion.main.startLifetime.constantMax);

        // remove the barrel after its destruction
        gameObject.SetActive(false);
        debris.SetActive(true);
    }
}
