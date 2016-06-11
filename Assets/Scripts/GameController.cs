using UnityEngine;
using System.Collections;

/// <summary>
/// GameController Script
/// A basic script that is used to simply spawn enemies.
/// Good to use to test the enemies you've created.
/// Will eventually be replaced by the the procedurally generation scripts.
/// </summary>
public class GameController : MonoBehaviour {

    public GameObject garbageTruck;             // reference to one of the game objects you want created
    public GameObject turret;                   // reference to another game object to create
    public Vector3 garbageTruckSpawnValues;     // a vector 3 used to set the area in which you want one of the game objects to spawn

    public float spawnGTWaitMax, spawnGTWaitMin;    // used to set the duration between when the game objects spawn
    public float startWait;                         // used to set an initial wait time until game objects begin to spawn

	void Start ()
    {
        // since I'm spawning two different types of enemies, I have two scripts, one for each enemy being spawned
        StartCoroutine(SpawnGarbageWaves());
        StartCoroutine(SpawnTurretWaves());
	}
	
    /// <summary>
    /// Spawns waves of GarbageTrucks
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnGarbageWaves()
    {
        // wait for the inital start offset before spawning
        yield return new WaitForSeconds(startWait);

        // using an infinite loop so that garbage trucks will just continue spawning endlessly for testing purposes
        while (true)
        {
            // set the position where the garbage truck will be spawned
            Vector3 spawnPosition = new Vector3(
                    Random.Range(-garbageTruckSpawnValues.x, garbageTruckSpawnValues.x),    // give me a random X to spaw the truck on based on that Vector 3
                    garbageTruckSpawnValues.y,                                              // spawn it at the Y from Vector3
                    garbageTruckSpawnValues.z);                                             // spawn it at the Z from the Vector3
            Quaternion spawnRotation = Quaternion.identity;                                 // sets the rotation of the spawn
            Instantiate(garbageTruck, spawnPosition, spawnRotation);                        // spawn the truck

            // set the wait time to a random value between the min and max spawn time
            float spawnWait = Random.Range(spawnGTWaitMin, spawnGTWaitMax);

            // wait for the spawn time
            yield return new WaitForSeconds(spawnWait);
        }
    }

    /// <summary>
    /// Spawns waves of turrets
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnTurretWaves()
    {
        // wait for the inital start wait before spawning waves
        yield return new WaitForSeconds(startWait * 2);

        // again, infinite loop so turrets just keep spawning
        while(true)
        {
            // since there are two turret lanes (one on other side of the road), randomly pick one
            float sideToSpawnTurret = Random.Range(-1, 1);
            if (sideToSpawnTurret < 0)
            {
                Vector3 spawnPosition = new Vector3(
                    Random.Range(-25, -17),         // again pick a random X value but I have just manually entered them here
                    garbageTruckSpawnValues.y,      // reusing the Vector3 spawn values for Y and z
                    garbageTruckSpawnValues.z);

                // set the rotation and spawn the enemy
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(turret, spawnPosition, spawnRotation);
            } else
            {
                // same as above, but using the other side  random X values
                Vector3 spawnPosition = new Vector3(Random.Range(17, 25), garbageTruckSpawnValues.y, garbageTruckSpawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(turret, spawnPosition, spawnRotation);
            }

            // wait for the spawn time
            //NOTE: I just multiplied the max wait time by two because I wanted infrequent turrets and didn't care
            // so much about them occuring at random intervals.
            yield return new WaitForSeconds(spawnGTWaitMax * 2);
        }

    }
}
