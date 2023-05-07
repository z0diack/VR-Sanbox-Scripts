using UnityEngine;
using UnityEngine.XR;

public class TimescaleController : MonoBehaviour
{
    //Script used for the changing of the timescale within the game.

    //Variable delcaration
    private Vector2 joystickAxis;
    private float minTimeScale = 0.5f;
    private float maxTimeScale = 4f;
    private float speed = 0.01f;
    public float currentTimeScale;
    public bool timescaleEnabled = true;

    /// <summary>
    /// Gets the current timescale at the start of the game and sets it to currentTimeScale variable.
    /// </summary>
    private void Start()
    {
        currentTimeScale = Time.timeScale;
    }

    /// <summary>
    /// Checks if the controlers left joystick has been moved either right or left and then changes the timescale appropriately.
    /// Also checks if the Y button has been pressed in order to reset the timescale back to 1.
    /// </summary>
    private void Update()
    {
        if (timescaleEnabled)
        {
            currentTimeScale = Time.timeScale;
            InputDevice leftHand = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
            if (leftHand.TryGetFeatureValue(CommonUsages.primary2DAxis, out joystickAxis))
            {
                if (joystickAxis.x < 0)
                {
                    currentTimeScale = Mathf.Max(Time.timeScale - speed, minTimeScale);
                    Time.timeScale = currentTimeScale;
                }
                else if (joystickAxis.x > 0)
                {
                    currentTimeScale = Mathf.Min(Time.timeScale + speed, maxTimeScale);
                    Time.timeScale = currentTimeScale;
                }
            }

            if (leftHand.TryGetFeatureValue(CommonUsages.secondaryButton, out bool yIsPressed))
            {
                if (yIsPressed)
                {
                    Time.timeScale = 1f;
                }
            }
        }
    }
}
