using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditScript : MonoBehaviour
{
    // Public Vars
    public Animator animator;
    public AudioSource deathSound;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Public Functions
    /******************
     * void Die()
     * -------------------
     * this function will be called if a bandit is hit by a bandit
     */
    public void Die()
    {
        deathSound.Play();
        animator.SetTrigger("Die");
    }
}
