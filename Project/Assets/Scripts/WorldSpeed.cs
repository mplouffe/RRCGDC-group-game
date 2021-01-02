using UnityEngine;
using System.Collections;

/// <summary>
/// Used by various objects to simulate a consistent rate of speed relative to the player.
/// </summary>
public class WorldSpeed : MonoBehaviour {
    // public variables
    public float scrollSpeed;       // this is base scroll speed (how fast you want the screen to scroll by default)
    public float topSpeed;          // this is the fastest we want the screen to scroll
    public float topSlow;           // this is the slowest we want the screen to scroll
    public float speedFactor;       // the rate at which the screen speeds up or slows down towards top or bottom speed

    public float currentWorldSpeed;     // the current rate of scroll

    /// <summary>
    /// Create an Instance of the class so we can access the variables
    /// Make set private so that we can't create more than one or recreate the Instance
    /// </summary>
    public static WorldSpeed Instance { get; private set; }

    void Awake()
    {
        // check to make sure the Instance is null, or not set to anything else
        if (Instance != null && Instance != this)
        {
            // if the instance isn't null, or there is something other than this in there, destroy it
            Destroy(gameObject);
        }

        // set the instance to this object
        Instance = this;
    }

    void FixedUpdate () {

        // check to see if player is pushing against top
        if (Manager.Instance.topped)
        {
            // if we haven't reached top speed yet
            if (currentWorldSpeed < topSpeed)
            {
                // increase the current speed by the speed factor
                currentWorldSpeed += speedFactor;
            }
        }
        // check to see if player is pushing against bottom
        else if (Manager.Instance.bottomed)
        {
            // if we havne't reached top slow yet
            if (currentWorldSpeed > topSlow)
            {
                // decrease the current speed by the speed factor
                currentWorldSpeed -= speedFactor;
            }
        }
        // if the player isn't pushing against either top or bottom
        else
        {
            // if the current speed is faster or slower than our default scroll speed, adjust accordingly
            if (currentWorldSpeed > scrollSpeed)
            {
                currentWorldSpeed -= speedFactor;
            }
            else if (currentWorldSpeed < scrollSpeed)
            {
                currentWorldSpeed += speedFactor;
            }
        }
    }
}
