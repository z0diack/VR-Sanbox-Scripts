using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SupermanMovement : MonoBehaviour
{
    //Scipt used to handle the superman like movement 

    //Variable delcaration
    public float maxSpeed = 40f;
    public Transform rightController;
    public Transform leftController;
    private Rigidbody _rigidbody;
    public OVRCameraRig rig;


    /// <summary>
    /// Gets the rigidbody component for the VR rig in the environment.
    /// </summary>
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Checks for triggers pressed, if one is pressed move at a certain speed in the direction of the controller that has had the trigger pressed. 
    /// The maxSpeed will be reached when both triggers are pressed.
    /// </summary>
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            Vector3 direction = Vector3.zero;
            Quaternion rotation = rightController.rotation;
            direction = rotation * Vector3.forward;
            direction *= (maxSpeed / 2) * Time.deltaTime;
            _rigidbody.MovePosition(_rigidbody.position + direction);
        }

        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
        {
            Vector3 direction = Vector3.zero;
            Quaternion rotation = rightController.rotation;
            direction = rotation * Vector3.forward;
            direction *= (maxSpeed / 2) * Time.deltaTime;
            _rigidbody.MovePosition(_rigidbody.position + direction);
        }

        if ((OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)) && (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger)))
        {
            Vector3 direction = Vector3.zero;
            Quaternion rotation = rightController.rotation;
            direction = rotation * Vector3.forward;
            direction *= (maxSpeed) * Time.deltaTime;
            _rigidbody.MovePosition(_rigidbody.position + direction);
        }
    }
}


