using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// PlayerHealth Script
/// </summary>
public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 10;      // starting health (set to 5)
                                        // NOTE: if this changes, you want to adjust the values of the Health Slider to match (Max on slider = starting health)
    public int currentHealth;           // current health
    private Slider healthSlider;
    bool isDead;                        // if the player is dead

    public GameObject explosion;        // reference to the explosion game object that is created when player dies
    public GameObject player;           // reference to the player
    private bool beingHit;

    void Start()
    {
        // set the current health to the starting health
        healthSlider = GameObject.FindGameObjectWithTag("healthUI").GetComponent<Slider>();
        currentHealth = startingHealth;
        healthSlider.value = currentHealth;
    }



    /// <summary>
    /// Called by damage dealing object to deal damage to player
    /// </summary>
    /// <param name="amount">The amount of damage to take</param>
    public void TakeDamage(int amount)
    {
        if (Manager.Instance.playerIsAlive)
        {
            beingHit = true;
            // set damaged to true in order to actiave the screen flash
            Manager.Instance.damaged = true;
            // subtract the damage
            currentHealth -= amount;
            // adjust the health slider
            if (healthSlider != null)
            {
                healthSlider.value = currentHealth;
            }

            if (currentHealth <= 0 && this != null)
            {
                // if damage 0 or less and the player is alive, call death
                Die();
            }
        }
    }

    /// <summary>
    /// Called by the healing object to heal the player
    /// </summary>
    /// <param name="amount">The amount of health given</param>
    public void GetHealth(int amount)
    {
        // set healed to true in order to activate the screen flash
        Manager.Instance.healed = true;

        // add the health
        currentHealth += amount;

        // make sure the player can't exceed the max health
        currentHealth = currentHealth > startingHealth ? 10 : currentHealth;

        // update the health slider
        healthSlider.value = currentHealth;
    }

    /// <summary>
    /// Death
    /// Handles the killing of the player
    /// </summary>
    public void Die()
    {
        // the player is dead
        Manager.Instance.playerIsAlive = false;
        Manager.Instance.playerLives--;

        // create an explosion
        Instantiate(explosion, transform.position, transform.rotation);
        // destroy the player
        if (player != null)
        {
            Destroy(player);
        }
    }
}
