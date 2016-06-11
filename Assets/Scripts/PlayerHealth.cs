using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// PlayerHealth Script
/// </summary>
public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 5;      // starting health (set to 5)
                                        // NOTE: if this changes, you want to adjust the values of the Health Slider to match (Max on slider = starting health)
    public int currentHealth;           // current health

    public Slider healthSlider;         // reference to the slider on the UI
    public Image damageImage;           // reference to a UI image used to flash the screen when taking damage

    public float flashSpeed = 5f;       // the duration of the damage inidication flash
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);  // the colour of the damage indicator

    bool isDead;                        // if the player is dead
    bool damaged;                       // if the player is damaged

    public GameObject explosion;        // reference to the explosion game object that is created when player dies
    public GameObject player;           // reference to the player

    void Awake()
    {
        // set the current health to the starting health
        currentHealth = startingHealth;
    }

    void Update()
    {
        // if te player is damaged, set the color of the damage overlay to the flash color
        if(damaged)
        {
            damageImage.color = flashColor;
        }
        else if(damageImage.color != Color.clear)
        {
            // lerp the overlay color back to clear over the flash duration
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);

            // set damaged to false
            damaged = false;
        }
    }

    /// <summary>
    /// Called by damage dealing object to deal damage to player
    /// </summary>
    /// <param name="amount">The amount of damage to take</param>
    public void TakeDamage(int amount)
    {
        // set damaged to true in order to actiave the screen flash
        damaged = true;
        // subtract the damage
        currentHealth -= amount;
        // adjust the health slider
        healthSlider.value = currentHealth;

        if (currentHealth <= 0 && Manager.Instance.playerIsAlive)
        {
            // if damage 0 or less and the player is alive, call death
            Death();
        }
    }

    /// <summary>
    /// Death
    /// Handles the killing of the player
    /// </summary>
    void Death()
    {
        // the player is dead
        Manager.Instance.playerIsAlive = false;
        // create an explosion
        Instantiate(explosion, transform.position, transform.rotation);
        // destroy the player
        Destroy(player);
    }
}
