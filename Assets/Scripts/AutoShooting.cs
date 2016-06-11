using UnityEngine;
using System.Collections;

/// <summary>
/// This script is for an auto shooting Enemy.
/// </summary>
public class AutoShooting : MonoBehaviour {

    public GameObject shot;                 // the shot that the will be generated

    /* NOTE: I designed this script for a double barreled turret
             hence why there are two shot spawn transforms to spawn the two bullets
    */ 
    public Transform shotSpawnLeft;         // the left hand shot spawner
    public Transform shotSpawnRight;        // the right hand shot spawner

    public float fireRate = 0.2F;           // the rate at which the turret will fire
    public float nextFire = 0.0F;           // used to calculate when the turret should fire next
    public float openFireWait = 1.0F;       // used to delay between when the turret is created, and when it begins firing


    void Awake()
    {
        // set up so that the turret will wait from the time it was spawned (Time.time) until after the openFireWait time
        nextFire = Time.time + openFireWait;
    }

    // each Update, check if the turret should be firing
    void Update () {

        // if the current time has passed the nextFire time, and the playerIsAlive
        // NOTE: have the turrets checking if the player is alive because there is no game over script
        // currently, hence if the player dies the turrets just keep shooting at nothing
        if (Time.time > nextFire && Manager.Instance.playerIsAlive)
        {
            // set the time the turret can shoot next
            nextFire = Time.time + fireRate;

            // fire a shot from each turret barrel
            GameObject enemyLeftShot = Instantiate(shot, shotSpawnLeft.position, shotSpawnLeft.rotation) as GameObject;
            GameObject enemyRightShot = Instantiate(shot, shotSpawnRight.position, shotSpawnRight.rotation) as GameObject;
        }
    }
}
