using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Pickup : MonoBehaviour
{
    //Script used for handlihg the pickup within the game/

    //Variable declaratio 
    public Transform rightController;
    public Transform leftController;
    public Transform rightHoldPos;
    public bool ReadyToPickup;
    public GameObject itemPickedUp;

    GameObject solarSystem;

    public Material highlightMaterial;
    Material originalMaterial;
    GameObject lastHighlightedObject;


    /// <summary>
    /// Sets the solar system variable as well as sets boolean value for readyToPickup as true
    /// </summary>
    void Start()
    {
        solarSystem = GameObject.Find("Solar System");
        ReadyToPickup = true;
    }

    /// <summary>
    /// Draws the ray from the controllers within the scene view, used for testing the ray is hitting the objects, runs the PickupCheck method to see if an object has been picked up or not.
    /// </summary>
    void Update()
    {
        Debug.DrawRay(rightController.transform.position, rightController.TransformDirection(Vector3.forward) * 100f, Color.blue);
        Debug.DrawRay(leftController.transform.position, leftController.TransformDirection(Vector3.forward) * 100f, Color.red);
        PickupCheck();
    }


    /// <summary>
    /// Checks if the rays are hitting a grabbable object, then if it is and the grip triggers have been pressed then the object will be picked up. 
    /// Once pickeded up it will continue to check to see when the item is placed back down.
    /// </summary>
    private void PickupCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(rightController.transform.position, rightController.TransformDirection(Vector3.forward), out hit, 1f * Mathf.Infinity))
        {
            if (hit.transform.gameObject.layer == 8)
            {
                if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger) && ReadyToPickup == true)
                {
                    rightHoldPos.position = hit.transform.position;
                    solarSystem.GetComponent<SolarSystem>().disableMovement();
                    hit.transform.gameObject.GetComponent<Grabbable>().SetPickedUpState(rightHoldPos);
                    itemPickedUp = hit.transform.gameObject;
                    ReadyToPickup = false;
                }
                GameObject hitObject = hit.collider.gameObject;
                HighlightObject(hitObject);
            }
        }
        else
            ClearHighlighted();

        if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger) && ReadyToPickup == false)
        {
            solarSystem.GetComponent<SolarSystem>().enableMovement();
            itemPickedUp.GetComponent<Grabbable>().SetDroppedState(rightHoldPos);
            ReadyToPickup = true;
            itemPickedUp = null;
        }
    }


    /// <summary>
    /// Used to change the material of the object once the ray is hit the object, to show the user which object has been highlighted ready to be picked up.
    /// </summary>
    /// <param name="gameObject"> Object that will have the material changed</param>
    void HighlightObject(GameObject gameObject)
    {
        if (lastHighlightedObject != gameObject)
        {
            ClearHighlighted();
            originalMaterial = gameObject.GetComponent<MeshRenderer>().sharedMaterial;
            gameObject.GetComponent<MeshRenderer>().sharedMaterial = highlightMaterial;
            lastHighlightedObject = gameObject;
        }

    }
    /// <summary>
    /// Clears the highlighted material and resets it back to the original material that the object has
    /// </summary>
    void ClearHighlighted()
    {
        if (lastHighlightedObject != null)
        {
            lastHighlightedObject.GetComponent<MeshRenderer>().sharedMaterial = originalMaterial;
            lastHighlightedObject = null;
        }
    }
}
