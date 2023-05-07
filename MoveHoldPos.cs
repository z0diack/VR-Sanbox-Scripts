using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHoldPos : MonoBehaviour
{
    //Script used to move the hold pos for once planets are picked up. 

    //Variable declaration
    public GameObject holdPos;
    private bool ReadySnapMove;


    /// <summary>
    /// Listens to if the right joystick has been moved up or down to then move the holdPos of the planet.
    /// Used for when planet are picked up and want to be either moved away or close from the player.
    /// Works in a snap movement of the planet so that it can be done in chunks.
    /// </summary>
    void FixedUpdate()
    {
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickUp))
        {
            if (ReadySnapMove)
            {
                ReadySnapMove = false;
                holdPos.transform.position += holdPos.transform.TransformDirection(Vector3.forward)*20f;
            }

        }
        else if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickDown))
        {
            if (ReadySnapMove)
            {
                ReadySnapMove = false;
                holdPos.transform.position += holdPos.transform.TransformDirection(Vector3.back) *20f;
            }
        }
        else
            ReadySnapMove = true;
    }
}
