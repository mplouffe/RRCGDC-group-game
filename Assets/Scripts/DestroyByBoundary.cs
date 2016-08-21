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
        // if the object has left the boundary box colider, destroy it
        if (other.gameObject.GetComponent<Death>())
        {
            EnemySpawner.Instance.spawnLanes.Add(other.gameObject.GetComponent<Death>().spawnLane);
        }

        Destroy(other.gameObject);
    }    
}
