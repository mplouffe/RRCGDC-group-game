using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Simple script used to change the game state from the game over screen, to the main menu screen after waiting for 5 seconds.
/// </summary>
public class GameOverManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(LevelChanger());
	}
	
    IEnumerator LevelChanger()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
}
