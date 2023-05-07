using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScaleUI : MonoBehaviour
{
    //Used to control the timescale UI element

    //Variable declaration
    public GameObject timeScaleText;
    TimescaleController tsc;
    Text timeScaleTextRenderer;


    /// <summary>
    /// Sets all the variables to the objects within the UI.
    /// </summary>
    void Start()
    {

        timeScaleTextRenderer = timeScaleText.GetComponent<Text>();
        tsc = GetComponent<TimescaleController>();
        float displayTimeScale = tsc.currentTimeScale;
        Debug.Log(displayTimeScale);
    }

    /// <summary>
    /// Updates the UI depending on the timescale changes.
    /// </summary>
    void Update()
    {
        float displayTimeScale = tsc.currentTimeScale;
        timeScaleTextRenderer.text = (Mathf.Round(displayTimeScale * 100f) / 100f).ToString() + "x";
    }
}

