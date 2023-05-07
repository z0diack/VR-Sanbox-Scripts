using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMenu : MonoBehaviour
{
    //Scipt that is used for enabling/disabling the spawning menu.

    //Variable declaration
    public Canvas menu;
    public GameObject gazePointer;

    /// <summary>
    /// Sets the pointer to false as well as the menu.
    /// </summary>
    private void Start()
    {
        menu.enabled = false;
        gazePointer.active = false;
    }

    /// <summary>
    /// Checks for if the start button is pressed and if it is the menu is either opened or closed depending on the current state of it.
    /// Also does the same for the pointer and enables/disables if depending on its current state.
    /// </summary>
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start))
        {
            bool menuActive = menu.isActiveAndEnabled;
            bool gazePointerActive = gazePointer.active;
            gazePointer.active = !gazePointerActive;
            menu.enabled = !menuActive;
        }
    }
}
