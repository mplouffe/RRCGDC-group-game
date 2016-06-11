using UnityEngine;
using System.Collections;

/// <summary>
/// PlayerShotMover Script
/// Used to control the player's shots
/// Same has regular shot mover, except won't react to colliding with player
/// this is because since the turret is on the roof, the bullet is spawned within the bounds of the player box
/// collider and would immediately be destroyed and hit the player with every shot.
/// </summary>
public class PlayerShotMover : MonoBehaviour
{

    public float speed;             // speed of the shot
    public GameObject shotSpark;    // a reference to the explosion that is generate when the shot hits something
    public int damage = 1;          // the damage the shot deals

    bool hit;                       // flag for if a hit has occured

    
    void Start()
    {
        // fire the bullet forward at the bullet's speed
        GetComponent<Rigidbody>().velocity = transform.up * speed;
    }

    void OnTriggerEnter(Collider other)
    {
        // on a collision we need to make sure we're colliding with the enemy otherwise the shot will be destroyed
        // when it collides with the boundary collider, or the player collider
        if (other.tag == "Enemy")
        {
            // deal damage to the enemy that you just collided with
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
            // flip the flag that you've hit something
            hit = true;
        }

        // if you've hit something
        if (hit)
        {
            // create the shot spark
            Instantiate(shotSpark, transform.position, transform.rotation);
            // destroy the game object
            Destroy(gameObject);

            // NOTE: currently this section of code could just be put in under the enemy tag check, but by seperating it out
            // we can add other tags later and still have the bullet destroy itself (like if there are buildings, or rocks
            // that the bullet can hit
        }
    }


}

