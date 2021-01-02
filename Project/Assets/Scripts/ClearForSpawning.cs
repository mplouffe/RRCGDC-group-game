using UnityEngine;
using System.Collections;

/// <summary>
/// This function is constantly checking the player spawn box to see if it is clear or not.
/// Used when instanting a new player after death to ensure that the player isn't spawned
/// right on top of an enemy.
/// 
/// </summary>
public class ClearForSpawning : MonoBehaviour {

    public bool spawnAreaClear = true;
	
	// Update is called once per frame
    // by default say that the are is clear
	void FixedUpdate () {
        spawnAreaClear = true;
	}

    // if something is collding with our trigger, set the spawn area to clear to false
    void OnTriggerStay(Collider other)
    {
        spawnAreaClear = false;
    }
}
