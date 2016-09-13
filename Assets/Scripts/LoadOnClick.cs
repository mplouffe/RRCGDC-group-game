using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// The simple functions for the main menu buttons (don't really get used much as you can press 'fire' to start and escape to quit)
/// </summary>
public class LoadOnClick : MonoBehaviour {

    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level);
    }

    public void ExitGme()
    {
        Application.Quit();
    }
}
