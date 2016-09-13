using UnityEngine;
using System.Collections;

/// <summary>
/// Object that spawns Foliage. For more detailed comments, please see the BuildingSpawner script. This script works in the exact same way.
/// </summary>
public class FoliageSpawner : MonoBehaviour {
    public GameObject foliage;

    public enum SpawnSide { Left, Right, Both};

    public Vector3 enemySpawnValues;     // a vector 3 used to set the area in which you want one of the game objects to spawn

    public SpawnSide sideToSpawnFoliage = SpawnSide.Both;
    public bool droppingTrees = false;
    public float frequency;
                              
    // Use this for initialization
    void Start () {
        // setFoliage('B', 0.5f);
	}

    private void createTree()
    {
        SpawnSide currentSpawn;

        if (sideToSpawnFoliage == SpawnSide.Both)
        {
            currentSpawn = Random.Range(-1, 1) < 0 ? SpawnSide.Left : SpawnSide.Right;
        }else
        {
            currentSpawn = sideToSpawnFoliage;
        }

        Vector3 spawnPosition;
        Quaternion spawnRotation;

        if (currentSpawn == SpawnSide.Left)
        {
            spawnPosition = new Vector3(
                Random.Range(-33, -17),         // again pick a random X value but I have just manually entered them here
                Random.Range(enemySpawnValues.y, enemySpawnValues.y + 10),      // reusing the Vector3 spawn values for Y and z
                enemySpawnValues.z);

            // set the rotation
            spawnRotation = Quaternion.identity;
        }
        else
        {
            // same as above, but using the other side  random X values
            spawnPosition = new Vector3(
                Random.Range(17, 33),
                Random.Range(enemySpawnValues.y, enemySpawnValues.y + 10),
                enemySpawnValues.z);
            spawnRotation = Quaternion.identity;
        }

        Instantiate(foliage, spawnPosition, spawnRotation);
    }

    // Update is called once per frame
    IEnumerator SpawnFoliage () {
        while (droppingTrees)
        {
            int randomNumOfTrees = (int)Random.Range(1, 5);
            for (int i = 0; i < randomNumOfTrees; i++)
            {
                createTree();
            }
            yield return new WaitForSeconds(frequency);
        }
        yield break;
	}

    public void setFoliage(char side, float frequency)
    {
        switch (side)
        {
            case 'L':
                sideToSpawnFoliage = SpawnSide.Left;
                break;
            case 'R':
                sideToSpawnFoliage = SpawnSide.Right;
                break;
            case 'B':
                sideToSpawnFoliage = SpawnSide.Both;
                break;
        }
        this.frequency = frequency;

        if (!droppingTrees)
        {
            droppingTrees = true;
            StartCoroutine(SpawnFoliage());
        }
    }

    public void stopFoliage()
    {
        droppingTrees = false;
    }
}
