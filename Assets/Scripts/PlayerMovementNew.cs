using UnityEngine;
using System.Collections;

[System.Serializable]

/// <summary>
/// The basic player movement script.
/// </summary>
public class PlayerMovementNew : MonoBehaviour {

    public float speed;             // the base speed multipler used by the car
    public Boundary boundary;       // the boundaries in which the car can move

    public float drift;             // a modifier for the left and right speed
    public float accelerate;        // a modifier for the forward speed
    public float breaks;            // a modifier for the backwards speed

    public float decelerationFactor;
    public Rigidbody playerRigidbody;
    public float velocityCutOff;

     void FixedUpdate()
    { 
        // get the direcitonal input from the player (returns -1, 0, 1)
        float movementX = Input.GetAxis("Horizontal");
        float movementY = Input.GetAxis("Vertical");

        // depending on the up or down direction the player has input
        // either add accelerate or subtract the brakes from the movmentY
        if (movementY != 0)
        {
            if (movementY > 0)
            {
                movementY += accelerate;
            }
            else if (movementY < 0)
            {
                movementY -= breaks;
            }
            playerRigidbody.AddForce(new Vector3(0.0f, movementY, 0.0f));
        }
        else if(Mathf.Abs(playerRigidbody.velocity.y) > velocityCutOff)
        {
            float multiplier = playerRigidbody.velocity.y > 0 ? -1:1;

            playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, playerRigidbody.velocity.y + (decelerationFactor * multiplier), playerRigidbody.velocity.z);
        }
        else
        {
            playerRigidbody.velocity = new Vector3(
                playerRigidbody.velocity.x, 0.0f, playerRigidbody.velocity.z);
        }

        if (movementX != 0)
        {
            if (movementX > 0)
            {
                movementX += drift;
            }
            else if (movementX < 0)
            {
                movementX -= drift;
            }
            playerRigidbody.AddForce(new Vector3(movementX, 0.0f, 0.0f));
        }
        else if (Mathf.Abs(playerRigidbody.velocity.x) > velocityCutOff)
        {
            float multiplier = playerRigidbody.velocity.x > 0 ? -1 : 1;

            playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x + (decelerationFactor * multiplier), playerRigidbody.velocity.y, playerRigidbody.velocity.z);
        }
        else
        {
            playerRigidbody.velocity = new Vector3(
                0.0f, playerRigidbody.velocity.y, playerRigidbody.velocity.z);
        }
    }
}