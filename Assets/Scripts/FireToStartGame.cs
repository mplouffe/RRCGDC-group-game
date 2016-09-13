using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Simple script attached to the main menu that lets you press the fire button to start the game, and the escape button to quit.
/// </summary>
public class FireToStartGame : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButton("Fire1"))
        {
            Application.LoadLevel(1);
        }

        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
