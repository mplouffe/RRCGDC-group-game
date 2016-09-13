using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

    public GameObject explosion;
    public float spawnLane = -100;

    /// <summary>
    /// Death
    /// function to handle the killing of the enemy
    /// </summary>
    public virtual void Die()
    {
        // if the object being killed has been given a spawn lane, return it to the pool
        if (spawnLane != -100)
        {
            GameObject.FindObjectOfType<EnemySpawner>().spawnLanes.Add(spawnLane);
        }

        // create the explosion     
        Instantiate(explosion, transform.position, transform.rotation);

        // destroy this object
        Destroy(gameObject);
    }
}
