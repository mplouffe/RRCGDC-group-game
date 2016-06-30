using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {

    public GameObject explosion;

    /// <summary>
    /// Death
    /// function to handle the killing of the enemy
    /// </summary>
    public virtual void Die()
    {
        // create the explosion     
        Instantiate(explosion, transform.position, transform.rotation);
        // destroy this object
        Destroy(gameObject);
    }
}
