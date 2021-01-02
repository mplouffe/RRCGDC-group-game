using UnityEngine;
using System.Collections;

/// <summary>
/// The script for when a pedestrian object collides with the car.
/// </summary>
public class PedestrianCollisionScript : MonoBehaviour {

    public GameObject explosion;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponentInChildren<PlayerHealth>().TakeDamage(1);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
