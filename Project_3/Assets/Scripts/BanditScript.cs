using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditScript : MonoBehaviour
{
    // Public Vars
    public Animator animator;
    public AudioSource deathSound;
    public AudioSource taunt_01, taunt_02, taunt_03;

    // Private Variables
    private float tauntCounter = 10f;
    private bool alive = true;
    private int tauntNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Whats the taunt num: " + tauntNum + "Time and Speak time: " + Time.time + " " + tauntCounter);

        if (Time.time >= tauntCounter && alive)
        {
            Debug.Log("Whats the taunt num: " + tauntNum + "Time and Speak time: " + Time.time + " " + tauntCounter);

            switch (tauntNum)
            {
                case 0:
                    taunt_01.Play();
                    break;
                case 1:
                    taunt_02.Play();
                    break;
                case 2:
                    taunt_03.Play();
                    break;
            }

            tauntNum = Random.Range(0, 2);
            tauntCounter = Random.Range(10f, 50f) + Time.time;
        }
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
        alive = false;
    }
}
