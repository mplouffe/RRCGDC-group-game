using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// A simple script used on the menu and game over screen to shift the hue on the titles from red to black, back and forth.
/// </summary>
public class TextColorShifter : MonoBehaviour {

    public float redValue;
    private bool isGoingUp;
    private Text textObject;

    void Start()
    {
        if(textObject == null)
        {
            textObject = this.GetComponent<Text>();
            isGoingUp = false;
        }
    }
	// Update is called once per frame
	void FixedUpdate () {
	    
        if(isGoingUp)
        {
            redValue += 0.05f;
        }else
        {
            redValue -= 0.05f;
        }

        if(redValue < 0)
        {
            isGoingUp = true;
        }

        if(redValue > 1)
        {
            isGoingUp = false;
        }

        Color newShade = new Color(redValue, 41f/255f, 41f/255f);

        this.textObject.color = newShade;
	}
}
