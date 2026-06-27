using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kickTrigger : MonoBehaviour
{
    public Rigidbody currentObject;

    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody != null)
        {
            currentObject = other.attachedRigidbody;
            Debug.Log("Entered " + currentObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.attachedRigidbody == currentObject)
        {
            Debug.Log("Exited: " + currentObject.name);
            currentObject = null;
        }
    }
}
