using UnityEngine;
using System.Collections;

/// <summary>
/// Object that spawns building objects.
/// </summary>
public class BuildingSpawner : MonoBehaviour
{
    public GameObject building;                     // the prefab to be generated

    public enum SpawnSide { Left, Right, Both };    // and enum for which side objects should be spawned on

    public Vector3 enemySpawnValues;                // a vector 3 used to set the area in which you want one of the game objects to spawn

    public SpawnSide sideToSpawnBuildings;          // holds the side the building spawner is spawning buildings on
    public bool droppingBuildings = false;          // boolean used to in the Coroutine to spawn buildings
    public float frequency;                         // holds the wait period between coroutine calls

    // Use this for initialization
    void Start()
    {
        // use this if you want to initialize the building spawner with a value for testing purpose
        // setBuildings('B', 3);
    }

    /// <summary>
    /// Spawns a building object based upon the currently set variables
    /// </summary>
    private void createBuilding()
    {
        // setting up variables
        Vector3 spawnPosition;
        Quaternion spawnRotation;
        SpawnSide currentSpawn;     // the side on which we're gonna spawn a building

        // if the sideToSpawnBuildings == both, pick a random side to spawn a building on, else set the curentSpawn to the sideToSpawnBuildings
        if (sideToSpawnBuildings == SpawnSide.Both)
        {
            currentSpawn = Random.Range(-1, 1) < 0 ? SpawnSide.Left : SpawnSide.Right;
        }
        else
        {
            currentSpawn = sideToSpawnBuildings;
        }

        // set the variables based on which side currentSpawn is set to
        if (currentSpawn == SpawnSide.Left)
        {
            spawnPosition = new Vector3(
                Random.Range(-30, -22),         // again pick a random X value but I have just manually entered them here
                Random.Range(enemySpawnValues.y, enemySpawnValues.y + 10),      // reusing the Vector3 spawn values for Y and z
                enemySpawnValues.z);

            // set the rotation
            spawnRotation = Quaternion.identity;
        }
        else
        {
            // same as above, but using the other side  random X values
            spawnPosition = new Vector3(
                Random.Range(22, 30),
                Random.Range(enemySpawnValues.y, enemySpawnValues.y + 10),
                enemySpawnValues.z);
            spawnRotation = Quaternion.identity;
        }

        // instantiate the object
        Instantiate(building, spawnPosition, spawnRotation);
    }

    /// <summary>
    /// The Coroutine that calls itself repeatedly, pausing the frequency duration before calling
    /// </summary>
    /// <returns></returns>
    IEnumerator SpawnBuildings()
    {
        while (droppingBuildings)
        {
            createBuilding();
            yield return new WaitForSeconds(frequency);
        }
        yield break;
    }

    /// <summary>
    /// Call this to start spawning buildings. This sets up the buidling spawning values and starts the Coroutine
    /// </summary>
    /// <param name="side">The side to spawn buildings on</param>
    /// <param name="frequency">How long to wait before spawning the next building.</param>
    public void setBuildings(char side, float frequency)
    {
        switch (side)
        {
            case 'L':
                sideToSpawnBuildings = SpawnSide.Left;
                break;
            case 'R':
                sideToSpawnBuildings = SpawnSide.Right;
                break;
            case 'B':
                sideToSpawnBuildings = SpawnSide.Both;
                break;
        }
        this.frequency = frequency;

        if (!droppingBuildings)
        {
            droppingBuildings = true;
            StartCoroutine(SpawnBuildings());
        }
    }

    /// <summary>
    /// Call this to stop spawning buildings.
    /// </summary>
    public void stopBuildings()
    {
        droppingBuildings = false;
    }
}

