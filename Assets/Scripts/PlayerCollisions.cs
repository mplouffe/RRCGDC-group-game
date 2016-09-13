using UnityEngine;
using System.Collections;

/// <summary>
/// A basic collision system for the player. If colliding with an enemy object, take damage. If collding with an enemy object while you're along the bottom of the screen,
/// destroy the enemy object.
/// An earlier implementation had the player dying when they collided along the bottom of the screen, but that was a little harsh.
/// THIS NEEDS TO BE FIXED A LOT.
/// We should implement a much more robust collision and physics system than the one that is currently in the game.
/// </summary>
public class PlayerCollisions : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            this.GetComponentInChildren<PlayerHealth>().TakeDamage(1);
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (transform.position.y < -16)
            {
                if (transform.position.y < collision.transform.position.y)
                {
                    collision.gameObject.GetComponent<Death>().Die();
                }
            }
        }
    }
}
