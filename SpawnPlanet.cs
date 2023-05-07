using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPlanet : MonoBehaviour
{
    //Script used to intiantiate new planets

    //Variable declaration, used to set what planet will be spawned in.
    public GameObject prefab;
    public GameObject ovrparent;
    GameObject solarSystem;

    public GameObject spawnPos;

    /// <summary>
    /// Finds the solar system so that the array can be updated when spawned in as well as movement be disabled when spawned in.
    /// </summary>
    void Start()
    {
        solarSystem = GameObject.Find("Solar System");
    }
  
    /// <summary>
    /// Method used to create the new prefab, then picks up the planet as well as updates the 
    /// planet array with the new planet and disables the movement of other plants.
    /// </summary>
    public void InstantiatePrefab()
    {
        GameObject newPrefab = Instantiate(prefab, spawnPos.transform);
        ovrparent.GetComponent<Pickup>().itemPickedUp = newPrefab;
        solarSystem.GetComponent<SolarSystem>().updateArray();
        solarSystem.GetComponent<SolarSystem>().disableMovement();
    }

}
