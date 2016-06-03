using UnityEngine;
using System.Collections;

// controls the scrolling background
public class scrolling : MonoBehaviour {

    // public variables
    public float scrollSpeed;       // this is base scroll speed (how fast you want the screen to scroll by default)
    public float topSpeed;          // this is the fastest we want the screen to scroll
    public float topSlow;           // this is the slowest we want the screen to scroll
    public float speedFactor;       // the rate at which the screen speeds up or slows down towards top or bottom speed

    private float currentSpeed;     // the current rate of scroll

    public float tileSize;          // the size of our background tile

    private Vector3 startPosition;  // the starting positon of the background

	void Start()
    {
        // set the start positon and current speeds
        startPosition = transform.position;
        currentSpeed = scrollSpeed;
    }

	void FixedUpdate () {

        // check to see if player is pushing against top
        if (Manager.Instance.topped)
        {
            // if we haven't reached top speed yet
            if(currentSpeed < topSpeed)
            {
                // increase the current speed by the speed factor
                currentSpeed += speedFactor;
            }
        }
        // check to see if player is pushing against bottom
        else if(Manager.Instance.bottomed)
        {
            // if we havne't reached top slow yet
            if(currentSpeed > topSlow)
            {
                // decrease the current speed by the speed factor
                currentSpeed -= speedFactor;
            }
        }
        // if the player isn't pushing against either top or bottom
        else
        {
            // if the current speed is faster or slower than our default scroll speed, adjust accordingly
            if(currentSpeed > scrollSpeed)
            {
                currentSpeed -= speedFactor;
            } else if(currentSpeed < scrollSpeed)
            {
                currentSpeed += speedFactor;
            }
        }

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
