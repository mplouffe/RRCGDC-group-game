using UnityEngine;
using System.Collections;

/// <summary>
/// On a collsion between two objects, destroy both objects.
/// Before enemy health was built in, this was used to have the enemys just destroyed
/// when hit by bullets that had this script attached.
/// </summary>
public class DestroyByContact : MonoBehaviour {

    public GameObject exposion;     // reference to an explosion game object

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boundary")
        {
            // when anything is instantiated, it will come into contact with the Boundary box
            // so when it does, just return, don't destroy either object
            return;
        }

        Instantiate(exposion, transform.position, transform.rotation);      // instantiate the explosion at the point of the collision
        Destroy(other.gameObject);      // destroy the thing collided into
        Destroy(gameObject);            // destroy this object
    }
}
