using UnityEngine;
using System.Collections;

public class BuildingSpawner : MonoBehaviour
{
    public GameObject building;

    public enum SpawnSide { Left, Right, Both };

    public Vector3 enemySpawnValues;     // a vector 3 used to set the area in which you want one of the game objects to spawn

    public SpawnSide sideToSpawnBuildings = SpawnSide.Both;
    public bool droppingBuildings = false;
    public float frequency;

    // Use this for initialization
    void Start()
    {
        setBuildings('B', 3);
    }

    private void createBuilding()
    {
        SpawnSide currentSpawn;

        if (sideToSpawnBuildings == SpawnSide.Both)
        {
            currentSpawn = Random.Range(-1, 1) < 0 ? SpawnSide.Left : SpawnSide.Right;
        }
        else
        {
            currentSpawn = sideToSpawnBuildings;
        }

        Vector3 spawnPosition;
        Quaternion spawnRotation;

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

        Instantiate(building, spawnPosition, spawnRotation);
    }

    // Update is called once per frame
    IEnumerator SpawnBuildings()
    {
        while (droppingBuildings)
        {
            createBuilding();
            yield return new WaitForSeconds(frequency);
        }
        yield break;
    }

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

    public void stopBuildings()
    {
        droppingBuildings = false;
    }
}

