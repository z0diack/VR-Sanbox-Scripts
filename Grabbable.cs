using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Grabbable : MonoBehaviour
{
    //Script used to be assigned to items that are grabbable in order to change their settings if has been picked up or not.

    //Variable declaration
    Rigidbody rb;
    SphereCollider sphereCollider;


    /// <summary>
    /// Gets the rigidbody and the collider for the object that it has been assigned to.
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sphereCollider = GetComponent<SphereCollider>();
    }

    /// <summary>
    /// Used to change the settings for the object being picked up, sets the object to kinematic so that gravity is not applied.
    /// Changes it parent so that it can be moved using the hold parameter.
    /// Sets the collider to false so it cannot interact with other objects in the environment.
    /// </summary>
    /// <param name="hold">Object that the picked up object will be assigned with to be moved.</param>
    public void SetPickedUpState(Transform hold)
    { 
        rb.isKinematic = true;
        transform.parent = hold;
        sphereCollider.enabled = false;
    }

    /// <summary>
    /// Resets the values that were changed in the SetPickedUpState function, 
    /// Sets kinematic to false, sets the parent back to null as well as enables the collider again.
    /// </summary>
    /// <param name="hold">Hold pos that the object will be placed back down in, will be the same as the picked up pos as it gets held there</param>
    public void SetDroppedState(Transform hold)
    {
        rb.isKinematic = false;
        transform.parent = null;
        sphereCollider.enabled = true;
    }
}
