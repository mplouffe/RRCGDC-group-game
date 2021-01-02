using UnityEngine;
using System.Collections;

/// <summary>
/// ShotMove Script
/// Used on enemy bullets.
/// </summary>
public class ShotMover : MonoBehaviour {

    public float speed;             // speed of the shot
    public GameObject shotSpark;    // reference to the explosion created when the shot is destroyed
    public int damage = 1;          // the damage dealt by the shot

    bool hit;                       // flag for if something has been hit


	void Start () {
        // fire the bullet forward at the bullet's speed
        GetComponent<Rigidbody>().velocity = transform.up * speed;
	}

    void OnTriggerEnter(Collider other)
    {
        // if the bullet hit the player
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
            hit = true;
        }

        // if the bullet hit the other enemy
        if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealth>().TakeDamage(damage);
            hit = true;
        }

        // what to do when there is a hit
        if (hit)
        {
            Instantiate(shotSpark, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        // NOTE: for more detailed comments, see the PlayerShotMover script
    }

	
}
