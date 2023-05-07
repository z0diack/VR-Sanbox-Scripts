using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SolarSystem : MonoBehaviour
{
    //Script used to handle the gravity and initial velocity for the objects within the solar system.

    //Variable declaration
    readonly float G = 100f;
    GameObject[] planets;
    GameObject[] stars;
    public GameObject[] all_solarsystem;


    /// <summary>
    /// Runs updateArray method to get all the objects that are marked as planets within the system and 
    /// collects them into an array ready for the initial velocity and gravity to be applied.
    /// Also applies the initial velocity to these objects.
    /// </summary>
    void Start()
    {
        updateArray();
        InitialVelocity();
    }

    /// <summary>
    /// Runs the gravity method at each fixed timestep.
    /// </summary>
    private void FixedUpdate()
    {
        Gravity();
    }

    /// <summary>
    /// Calculates the gravity force that will be applied to all orbiting objects within the scene during the FixedUpdate(), using the newtonian physics equation.
    /// </summary>
    void Gravity()
    {
        foreach (GameObject a in all_solarsystem)
        {
            foreach (GameObject b in all_solarsystem)
            {
                if (!a.Equals(b))
                {
                    float m1 = a.GetComponent<Rigidbody>().mass;
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);

                    a.GetComponent<Rigidbody>().AddForce((b.transform.position - a.transform.position).normalized * (G * (m1 * m2) / (r * r)));

                }
            }
        }
    }
    /// <summary>
    ///Works out the initial velocity of the planet by using gravity and the distance between each other planet in the solar system
    ///</summary>
    public void InitialVelocity()
    {
        foreach (GameObject a in all_solarsystem)
        {
            foreach (GameObject b in all_solarsystem)
            {
                if (!a.Equals(b))
                {
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);
                    a.transform.LookAt(b.transform);

                    a.GetComponent<Rigidbody>().velocity += a.transform.right * Mathf.Sqrt((G * m2) / r);

                }

            }
        }
    }

    /// <summary>
    /// Freezes the position of all the planets within the game, used when spawning in objects as well as moving planets.
    /// </summary>
    public void disableMovement()
    {
        foreach (GameObject p in planets)
        {
            p.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        }
    }

    /// <summary>
    /// Unfreezes the objects that have been paused as well as giving them their initial velocity back in order to start them moving again.
    /// </summary>
    public void enableMovement()
    {
        foreach (GameObject p in planets)
        {
            p.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        }
        InitialVelocity();
    }

    /// <summary>
    /// Updates the array of objects that need gravity/intial velocity applied to them.
    /// </summary>
    public void updateArray()
    {
        all_solarsystem = null;

        planets = GameObject.FindGameObjectsWithTag("planet");
        stars = GameObject.FindGameObjectsWithTag("star");

        all_solarsystem = planets.Concat(stars).ToArray();
    }

    /// <summary>
    /// Similar to the enable/disable method but in the format as boolean to either freeze or unfreeze the planets.
    /// </summary>
    /// <param name="tf">Boolean of either true or false to be passed in</param>
    public void boolMovement(bool tf)
    {
        if(tf == true)
        {
            foreach (GameObject p in planets)
            {
                p.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
            }
        }
        if(tf == false)
        {
            foreach (GameObject p in planets)
            {
                p.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            }
            InitialVelocity();
        }
    }
}
