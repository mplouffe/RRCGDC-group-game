using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// GameController Script
/// A basic script that is used to simply spawn enemies.
/// Good to use to test the enemies you've created.
/// Will eventually be replaced by the the procedurally generation scripts.
/// </summary>
public class EnemySpawner : MonoBehaviour
{

    public GameObject garbageTruck;             // reference to one of the game objects you want created
    public GameObject turret;                   // reference to another game object to create
    public GameObject copCar;
    public GameObject ambulance;
    public GameObject pedestrian;
    public GameObject multiSpriteEnemy;

    public Vector3 enemySpawnValues;     // a vector 3 used to set the area in which you want one of the game objects to spawn
    public List<float> spawnLanes = new List<float>(); // a list of floats that represent the spawn points of the lanes
                                                       // as enemies spawn and die they will pull spawn lanes from the array and then pop them back on when they are done with them

    /// <summary>
    /// Sets up the array of spawn lanes. The values were just added manually are spaced out approximately the width of 1 garbage truck sprite
    /// </summary>
    void Start()
    {
        spawnLanes.Add(-12.5F);
        spawnLanes.Add(-10F);
        spawnLanes.Add(-7.5F);
        spawnLanes.Add(-5F);
        spawnLanes.Add(-2.5F);
        spawnLanes.Add(0F);
        spawnLanes.Add(2.5F);
        spawnLanes.Add(5F);
        spawnLanes.Add(7.5F);
        spawnLanes.Add(10F);
        spawnLanes.Add(12.5F);
    }

    /// <summary>
    /// Spawns a GarbageTruck
    /// </summary>
    /// <returns></returns>
    public void SpawnGarbageTruck()
    {
        if (spawnLanes.Count > 0)
        {
            int randomIndex = (int)(Random.Range(0, spawnLanes.Count));
            float spawnPositionX = spawnLanes[randomIndex];
            spawnLanes.RemoveAt(randomIndex);

            // set the position where the garbage truck will be spawned
            Vector3 spawnPosition = new Vector3(
                    spawnPositionX,                                                          // give me a random X to spaw the truck on based on that Vector 3
                    enemySpawnValues.y,                                              // spawn it at the Y from Vector3
                    enemySpawnValues.z);                                             // spawn it at the Z from the Vector3
            Quaternion spawnRotation = Quaternion.identity;                                 // sets the rotation of the spawn

            GameObject newGarbageTruck = (GameObject)Instantiate(garbageTruck, spawnPosition, spawnRotation);                        // spawn the truck
            newGarbageTruck.GetComponent<Death>().spawnLane = spawnPositionX;
        }
    }

    /// <summary>
    /// Spawns a CopCar
    /// </summary>
    /// <returns></returns>
    public void SpawnCopCar()
    {
        if (spawnLanes.Count > 0)
        {
            int randomIndex = (int)(Random.Range(0, spawnLanes.Count));
            float spawnPositionX = spawnLanes[randomIndex];
            spawnLanes.RemoveAt(randomIndex);

            // set the position where the garbage truck will be spawned
            Vector3 spawnPosition = new Vector3(
                    spawnPositionX,                                                          // give me a random X to spaw the truck on based on that Vector 3
                    -enemySpawnValues.y,                                              // spawn it at the Y from Vector3
                    enemySpawnValues.z);                                             // spawn it at the Z from the Vector3
            Quaternion spawnRotation = Quaternion.identity;                                 // sets the rotation of the spawn

            GameObject newCopCar = (GameObject)Instantiate(copCar, spawnPosition, spawnRotation);                        // spawn the truck
            newCopCar.GetComponent<Death>().spawnLane = spawnPositionX;
        }
    }

    /// <summary>
    /// Spawns an Ambulance
    /// </summary>
    /// <returns></returns>
    public void SpawnAmbulance()
    {
        if (spawnLanes.Count > 0)
        {
            int randomIndex = (int)Random.Range(0, spawnLanes.Count);
            float spawnPositionX = spawnLanes[randomIndex];
            spawnLanes.RemoveAt(randomIndex);

            // set the position where the garbage truck will be spawned
            Vector3 spawnPosition = new Vector3(
                    spawnPositionX,                                                          // give me a random X to spaw the truck on based on that Vector 3
                    enemySpawnValues.y,                                              // spawn it at the Y from Vector3
                    enemySpawnValues.z);                                             // spawn it at the Z from the Vector3
            Quaternion spawnRotation = Quaternion.identity;                                 // sets the rotation of the spawn

            GameObject newAmbulance = (GameObject)Instantiate(ambulance, spawnPosition, spawnRotation);                        // spawn the truck
            newAmbulance.GetComponent<Death>().spawnLane = spawnPositionX;
        }
    }
    /// <summary>
    /// Spawns waves a turret, picks a random side to spawn it on.
    /// </summary>
    /// <returns></returns>
    public void SpawnTurret()
    {
            // since there are two turret lanes (one on other side of the road), randomly pick one
            float sideToSpawnTurret = Random.Range(-1, 1);
            if (sideToSpawnTurret < 0)
            {
                Vector3 spawnPosition = new Vector3(
                    Random.Range(-25, -17),         // again pick a random X value but I have just manually entered them here
                    enemySpawnValues.y,      // reusing the Vector3 spawn values for Y and z
                    enemySpawnValues.z);

                // set the rotation and spawn the enemy
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(turret, spawnPosition, spawnRotation);
            }
            else
            {
                // same as above, but using the other side  random X values
                Vector3 spawnPosition = new Vector3(Random.Range(17, 25), enemySpawnValues.y, enemySpawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(turret, spawnPosition, spawnRotation);
            }
     }

    /// <summary>
    /// Spawns a pedestrian, picks a random side to spawn them on.
    /// </summary>
    public void SpawnPedestrian()
    {
        float sideToSpawnPedestrian = Random.Range(-1, 1);
        Vector3 spawnPosition;
        if(sideToSpawnPedestrian < 0)
        {
            spawnPosition = new Vector3(
                Random.Range(-30, -20),
                enemySpawnValues.y,
                enemySpawnValues.z);
        }
        else
        {
            spawnPosition = new Vector3(
                Random.Range(20, 30),
                enemySpawnValues.y,
                enemySpawnValues.z);
        }

        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(pedestrian, spawnPosition, spawnRotation);
    }

    /// <summary>
    /// Spawns a 'car' object which is an object with multiple sprites
    /// </summary>
    public void SpawnCar()
    {
        if (spawnLanes.Count > 0)
        {
            int randomIndex = (int)(Random.Range(0, spawnLanes.Count));
            float spawnPositionX = spawnLanes[randomIndex];
            spawnLanes.RemoveAt(randomIndex);

            // set the position where the garbage truck will be spawned
            Vector3 spawnPosition = new Vector3(
                    spawnPositionX,                                                          // give me a random X to spaw the truck on based on that Vector 3
                    enemySpawnValues.y,                                              // spawn it at the Y from Vector3
                    enemySpawnValues.z);                                             // spawn it at the Z from the Vector3
            Quaternion spawnRotation = Quaternion.identity;                                 // sets the rotation of the spawn

            GameObject newCar = (GameObject)Instantiate(multiSpriteEnemy, spawnPosition, spawnRotation);                        // spawn the truck
            newCar.GetComponent<Death>().spawnLane = spawnPositionX;
            newCar.GetComponent<MultiSpriteManager>().setSprite((int)Random.Range(0, 15));  // picks a random value to set the sprite to
        }
    }
}
