using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// This updates the player lives HUD. Also responsible for respawning the player if they still have lives, or ending the game if they are out of lives
/// </summary>
public class LevelStateManager : MonoBehaviour {

    // properties
    public GameObject playerPrefab;
    public ClearForSpawning playerSpawnBox;
    public Text playerLivesText;
    private bool gameOverCalled;

    // setting up the properties with the required objects
    void Start()
    {
        GameObject playerLivesTextObject = GameObject.FindGameObjectWithTag("playerLives");
        playerLivesText = playerLivesTextObject.GetComponent<Text>();
        playerLivesText.text = "Lives: " + Manager.Instance.playerLives;
        gameOverCalled = false;
        FindObjectOfType<Manager>().Reset();
    }

    /// <summary>
    /// If the player is not alive, respawns them, or ends the game.
    /// </summary>
    void FixedUpdate()
    {
        if (!Manager.Instance.playerIsAlive)
        {
            if (Manager.Instance.playerLives >= 1 && playerSpawnBox.spawnAreaClear)
            {
                playerLivesText.text = "Lives : " + Manager.Instance.playerLives;                   // update playerLivesUI
                Instantiate(playerPrefab, new Vector3(0.0F, 0.0F, 0.0F), Quaternion.identity);      // spawn a player
                Manager.Instance.playerIsAlive = true;                                              // set the playerIsAlive boolean to true
                Manager.Instance.ResetPlayerReference();                                            // have the manager update its reference to the player transform to the new player object
            }
            else if (Manager.Instance.playerLives <= 0 && Application.loadedLevel == 1)
            {
                playerLivesText.text = "Lives : " + Manager.Instance.playerLives;                   // update the playerLivesUI
                if (!gameOverCalled)
                {
                    gameOverCalled = true;                                                          // set game over called to true (otherwise it will call game over every update)
                    DungeonMaster dm = GetComponent<DungeonMaster>();                               // turn off all the coroutines
                    dm.StopAllCoroutines();
                    dm.foliageSpawner.StopAllCoroutines();
                    dm.buildingSpawner.StopAllCoroutines();
                    StartCoroutine(LoadGameOver());                                                 // load game over
                }
            }
        }

        // put this in here for during demos
        // if anything in the game goes wrong, you can just press escape to get back to the main menu
        if(Input.GetKey(KeyCode.Escape))
        {
            gameOverCalled = true;
            DungeonMaster dm = GetComponent<DungeonMaster>();
            dm.StopAllCoroutines();
            dm.foliageSpawner.StopAllCoroutines();
            dm.buildingSpawner.StopAllCoroutines();
            SceneManager.LoadScene(0);
        }
    }

    /// <summary>
    /// The load game over is separated out into it's own method so we can make use of the WaitForSeconds function to wait 3 seconds before
    /// transitioning to the end game screen.
    /// </summary>
    /// <returns></returns>
    IEnumerator LoadGameOver()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(2);
    }
}
