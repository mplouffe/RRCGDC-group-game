using UnityEngine;
using System.Collections;

[System.Serializable]
/// Boundary
/// This class functions to hold the x and y constraints for player movement
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

/// <summary>
/// The basic player movement script.
/// </summary>
public class PlayerMovement : MonoBehaviour {

    public float speed;             // the base speed multipler used by the car
    public Boundary boundary;       // the boundaries in which the car can move

    public float drift;             // a modifier for the left and right speed
    public float accelerate;        // a modifier for the forward speed
    public float breaks;            // a modifier for the backwards speed

     void FixedUpdate()
    { 
    // get the direcitonal input from the player (returns -1, 0, 1)
    float movementX = Input.GetAxis("Horizontal");
    float movementY = Input.GetAxis("Vertical");

        // depending on the up or down direction the player has input
        // either add accelerate or subtract the brakes from the movmentY
        if(movementY > 0)
        {
            movementY += accelerate;
        } else if(movementY< 0)
        {
            movementY -= breaks;
        }

        // same as above for the x axis
        // except plus or minus the drift value
        if(movementX > 0)
        {
            movementX += drift;
        } else if (movementX< 0)
        {
            movementX -= drift;
        }

        // create a new vector based on our calculated movementX and movementY and apply it to the rigidbody of the player object
        Vector3 movement = new Vector3(movementX, movementY, 0.0f);
        GetComponent<Rigidbody>().velocity = movement * speed;

        // before we bind our player to our boundary, check to see if they are above it (ie pushing against the top)
        // or below it (ie pushing agains the bottom)
        // if they are, set the topped or bottom to true
        if (GetComponent<Rigidbody>().position.y > boundary.yMax)
        {
            Manager.Instance.topped = true;
        }
        else if(GetComponent<Rigidbody>().position.y<boundary.yMin)
        {
            Manager.Instance.bottomed = true;
        }
        else
        {
            // if the player isn't pushing against the top or bottom, set them to false
            Manager.Instance.topped = false;
            Manager.Instance.bottomed = false;
        }

        // keeping our player within the boundary
        // if they are outside the boundary, reset their position to just inside the boundary
        GetComponent<Rigidbody>().position = new Vector3
           (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(GetComponent<Rigidbody>().position.y, boundary.yMin, boundary.yMax),
            0.0f
            );
    }
}