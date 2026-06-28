using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{
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

    // look for the collision
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            explode();
            Destroy(collision.gameObject);
        }
    }


    // Create Explosion launch
    void explode()
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
        Destroy(gameObject);
    }
}
