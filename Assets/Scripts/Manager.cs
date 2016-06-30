using UnityEngine;
using System.Collections;

/// <summary>
/// This class functions to hold global variables.
/// </summary>
public class Manager : MonoBehaviour{

    public bool topped = false;     // set to true if the player is pushing against the top of the screen
    public bool bottomed = false;    // set to true if the player is pushing agains the bottom of the screen
    public bool playerIsAlive = true;   // used by enemies to activate their behaviour if the player is alive
    public Transform player;            // holds a reference to the player's tansform so that targeting scripts can access it without having to use a GetComponent<>() call.

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

        // get a reference to the player's transform and set it as the target
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
