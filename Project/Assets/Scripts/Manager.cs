using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// This class functions to hold global variables.
/// </summary>
public class Manager : MonoBehaviour{

    public bool topped = false;     // set to true if the player is pushing against the top of the screen
    public bool bottomed = false;    // set to true if the player is pushing agains the bottom of the screen
    public bool playerIsAlive = true;   // used by enemies to activate their behaviour if the player is alive
    private Transform playerTransform;

    // holds a reference to the player's transform so other objects can access this rather than having to 
    // get the player's transform themself
    // if the player doesn't exist (they have just died, etc.) then it returns the transform of itself instead
    public Transform player
    {
        get
        {
            if(playerTransform == null)
            {
                return this.transform;
            }else
            {
                return playerTransform;
            }
        }

        set
        {
            playerTransform = value;
        }
    }// holds a reference to the player's tansform so that targeting scripts can access it without having to use a GetComponent<>() call.

    public bool damaged;                       // if the player is damaged
    public bool healed;                        // if the player is healed

    public Image damageImage;           // reference to a UI image used to flash the screen when taking damage

    public float flashSpeed = 5f;       // the duration of the damage inidication flash
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);  // the colour of the damage indicator
    public Color healColor = new Color(0f, 1f, 0f, 0.1f);

    public int playerLives = 3;

    public Slider healthSlider;         // reference to the slider on the UI

    /// <summary>
    /// Create an Instance of the class so we can access the variables
    /// Make set private so that we can't create more than one or recreate the Instance
    /// </summary>
    public static Manager Instance
    { get; private set; }

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
    }

    void Start()
    {
        // get a reference to the player's transform and set it as the target
        player = GameObject.FindGameObjectWithTag("Player").transform;
        damageImage = GameObject.FindGameObjectWithTag("damageImage").GetComponent<Image>();
    }

    /// <summary>
    /// Used to reset the player's transform when the player is respawned after dying.
    /// </summary>
    public void ResetPlayerReference()
    {
        GameObject tempPlayer = GameObject.FindGameObjectWithTag("Player");
        player = tempPlayer.transform;
    }

    /// <summary>
    /// Originally put this here when I had this class persisting throughout the diffent levels
    /// This was an attempt to fix issues I was having, but I ended up just not making this class persistent and that solved the issues
    /// This might not be necessary but hasn't been removed yet
    /// </summary>
    public void Reset()
    {
        playerLives = 3;
        ResetPlayerReference();
    }

    /// <summary>
    /// This handles the flashing and color changing of the screen if the player is hit. We can't have the player handle this because when they die, the transition back
    /// to a clear colour wouldn't work.
    /// This should maybe be moved out into a seperate class that handles all the UI suff.
    /// </summary>
    void FixedUpdate()
    {
        if (Application.loadedLevel == 1)
        {
            if (damageImage == null)
            {
                damageImage = GameObject.FindGameObjectWithTag("damageImage").GetComponent<Image>();
            }

            // if the player is damaged, set the color of the damage overlay to the flash color
            if (damaged)
            {
                damageImage.color = flashColor;
                // set damaged to false
                damaged = false;
            }
            else if (healed)
            {
                damageImage.color = healColor;
                // set healed to false
                healed = false;
            }
            else if (damageImage.color != Color.clear)
            {
                // lerp the overlay color back to clear over the flash duration
                damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            }
        }
    }
}
