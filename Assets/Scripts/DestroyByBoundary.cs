using UnityEngine;
using System.Collections;

/// <summary>
/// Used to automatically destroy objects that leave the playing field (bullets, enemies, etc.)
/// Attach to a box collider that is set to the size of the playing area
/// </summary>
public class DestroyByBoundary : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        // if the object has left the boundary box colider:
        // if it is another object with a death element, call it's Die function
        // if it doesn't have a death object, just destroy it
        if (other.gameObject.GetComponent<Death>())
        {
            other.gameObject.GetComponent<Death>().Die(false);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }    
}
