using UnityEngine;
using System.Collections;

/// <summary>
/// On a collsion between two objects, destroy both objects.
/// Before enemy health was built in, this was used to have the enemys just destroyed
/// when hit by bullets that had this script attached.
/// </summary>
public class HealthPickup : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boundary")
        {
            // when anything is instantiated, it will come into contact with the Boundary box
            // so when it does, just return, don't destroy either object
            return;
        }

        if (other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().GetHealth(2);
        }

        Destroy(gameObject);            // destroy this object
    }
}
