using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Public Variables
    public GameObject bullet;
    public Transform shootPoint;
    public float impulseForce  = 170000.0f;
    public float impulseTorque = 3000.0f;
    public float kickForce = 40f; 
    public float kickRange = 2f;
    public int randomKick;
    public kickTrigger kickTrigger;
    public GameObject hero;
    public float shootDelay = 1f;
    public bool canMove = false;

    // Private Variables
    private float nextShot = 0f;

    Animator animController;
    Rigidbody rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        // get references to the animation controller of hero
        // character and player's corresponding rigid body
        animController = hero.GetComponent<Animator> ();
        rigidBody      = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
	// Don't allow player input until cutscene is over
	if (!canMove)
            return;     
        // kick only when player is standing upright or moving
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // kick animation
            Kick();    
        }

        if (Input.GetKeyDown(KeyCode.F) && Time.time >= nextShot)
        {
            // Shoots the bullet
            shoot();

            // prevent next shot until cooldown happens
            nextShot = Time.time + shootDelay;
        }
        

        // W/A/S/D input as a combined rotation and movement vector
        Vector3 input = new Vector3(0, Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // allow movement when input detected and not crouching
        if (input.magnitude > 0.001 && !animController.GetBool ("Crouch"))
        {
            // rotations are about y axis
            rigidBody.AddRelativeTorque(new Vector3(0, input.y * impulseTorque * Time.deltaTime, 0));
            // motion is forward/backward (about z axis)
            rigidBody.AddRelativeForce(new Vector3(0, 0, input.z * impulseForce * Time.deltaTime));

            animController.SetBool("Walk", true);
        }
        else
        {
            animController.SetBool("Walk", false);

            // crouching with 'C' key (only when not moving)
            if (Input.GetKey(KeyCode.C))
                animController.SetBool("Crouch", true);
            else
                animController.SetBool("Crouch", false);
        }


    }

    // kick function, selects at random one of 3 kick animations
    void Kick()
    {
        // get random number from 1 to 3 for random kick 
        int randomKick = UnityEngine.Random.Range(1, 4);

        // select random kick based on randomKick 
        animController.SetInteger("kickType", randomKick);
        animController.SetTrigger("kick");

        Invoke("applyKickForce", .25f);
    }
    
    // applies kick force when kicking objects
    public void applyKickForce()
    {
        if(kickTrigger.currentObject == null)
        {
            return;
        }

        kickTrigger.currentObject.AddForce(
            transform.forward * kickForce,
            ForceMode.Impulse);
    }

    // Shoot the bullets
    public void shoot()
    {
        Instantiate(
             bullet,
             shootPoint.position,
             shootPoint.rotation
        );
    }
}
