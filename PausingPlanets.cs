using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PausingPlanets : MonoBehaviour
{
    //Script used for handling pausing planets


    //Variable declaration
    GameObject solarSystem;
    public GameObject pauseText;

    /// <summary>
    /// Finds the solar system game objects and sets the pauseText UI element to false.
    /// </summary>
    void Start()
    {
        solarSystem = GameObject.Find("Solar System");
        pauseText.SetActive(false);
    }

    /// <summary>
    /// Listens to when the pause button is pressed, if pressed the planets will either be paused or unpaused depending on their current state.
    /// Also will enable or disable the pause UI element depending if the planets are paused or not.
    /// </summary>
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            bool paused = pauseText.active;
            solarSystem.GetComponent<SolarSystem>().boolMovement(!paused);
            paused = !paused;
            pauseText.SetActive(paused);
        }
    }
}

