using UnityEngine;
using System.Collections;

/// <summary>
/// Enemy health script.
/// - keeps track of enemy health
/// - kills the enemy when health drops below zero
/// - creates an explosion where the destroyed enemy was
/// </summary>
public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 3;      // the starting health of the enemy (just threw in a default value of 5)
    public int currentHealth;           // the current of the enemy
    public Death death;

    bool isDead;                        // if the enemy is alive or not

    void Awake()
    {
        // set the current health to the startingHealth
        currentHealth = startingHealth;
    }

    /// <summary>
    /// TakeDamage
    /// used to deal damage to the enemy. function is called by the damage dealing source
    /// </summary>
    /// <param name="amount">The amount of damage dealt to the enemy</param>
    public void TakeDamage(int amount)
    {
        if(isDead)
        {
            // if the enemy is dead, don't deal damage, just return
            return;
        }

        // subtract the damage from the current health
        currentHealth -= amount;

        if(currentHealth <= 0 && !isDead)
        {
            isDead = true;
            // if the current health is 0 or less, call the death function
            if (death != null)
            {
                death.Die();
            }
        }
    }
}
