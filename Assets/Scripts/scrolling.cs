using UnityEngine;
using System.Collections;

// controls the scrolling background
public class scrolling : MonoBehaviour {

    // public variables
    public WorldSpeed globalSpeed;

    private float currentSpeed;     // the current rate of scroll

    public float tileSize;          // the size of our background tile

    private Vector3 startPosition;  // the starting positon of the background

	void Start()
    {
        // set the start positon and current speeds
        startPosition = transform.position;
        currentSpeed = globalSpeed.currentWorldSpeed;
    }

	void FixedUpdate () {

        currentSpeed = globalSpeed.currentWorldSpeed;

        // move the position of the background along the y axis by the current speed
        transform.position = new Vector3(0.0f, transform.position.y - currentSpeed, 0.0f);

        // if the background has moved its entire height away from its start position
        if(transform.position.y <= startPosition.y - tileSize)
        {
            // rest the position back to start
            transform.position = startPosition;
        }
	}
}
