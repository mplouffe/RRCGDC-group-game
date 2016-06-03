using UnityEngine;
using System.Collections;

/// <summary>
/// This class functions to hold global variables.
/// </summary>
public class Manager : MonoBehaviour{

    public bool topped = false;     // set to true if the player is pushing against the top of the screen
    public bool bottomed = true;    // set to true if the player is pushing agains the bottom of the screen

    /// <summary>
    /// Create an Instance of the class so we can access the variables
    /// Make set private so that we can't create more than one or recreate the Instance
    /// </summary>
    public static Manager Instance { get; private set; }

    void Awake()
    {
        // check to make sure the Instance is null, or not set to anything else
        if(Instance != null && Instance != this)
        {
            // if the instance isn't null, or there is something other than this in there, destroy it
            Destroy(gameObject);
        }

        // set the instance to this object
        Instance = this;

        // this is uncessary right now because we don't have multiple scenes, but this will allow the object
        // to persist through scene changes
        DontDestroyOnLoad(gameObject);
    }
}
