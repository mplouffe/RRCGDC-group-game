using UnityEngine;
using System.Collections;

/// <summary>
/// Shooting Class
/// the shooting script for the player
/// </summary>
public class Shooting : MonoBehaviour {

    public GameObject shot;             // reference to the object that will be spawned by the shot
    public Transform shotSpawn;         // reference to the location where the shot will be spawned
    public float fireRate = 0.5F;       // a wait time between shots
    public float nextFire = 0.0F;       // used to calculate if enough time has passed so you can shoot again

    void Update()
    {
        // if player is pressing shot and enough time has passed to shoot again
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            // set the next time the player can shoot
            nextFire = Time.time + fireRate;
            // create th shot at the spawn position
            GameObject clone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
        }
    }
}
