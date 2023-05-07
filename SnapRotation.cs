using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapRotation : MonoBehaviour
{
    //Script used for the snap rotation in the camera.

    //Variable declaration
    public OVRCameraRig CameraRig;
    public float RotationAngle = 45.0f;
    private bool ReadyToSnapTurn;

    /// <summary>
    /// Checks if the joystick has been moved either right or left and then changes the cameras rotation by the rotation angle set.
    /// </summary>
    void FixedUpdate()
    {
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickLeft))
        {
            if (ReadyToSnapTurn)
            {
                ReadyToSnapTurn = false;
                transform.RotateAround(CameraRig.centerEyeAnchor.position, new Vector3(0, 1, 0), -RotationAngle);
            }

        }
        else if (OVRInput.Get(OVRInput.Button.SecondaryThumbstickRight))
        {
            if (ReadyToSnapTurn)
            {
                ReadyToSnapTurn = false;
                transform.RotateAround(CameraRig.centerEyeAnchor.position, new Vector3(0, 1, 0), RotationAngle);
            }
        }
        else
            ReadyToSnapTurn = true;
        
    }
}
