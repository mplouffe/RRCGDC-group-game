using UnityEngine;
using System.Collections;

/// <summary>
/// EnemyMovement Script
/// NOTE: currently this script only moves the enemy along the Y axis.
/// TO DO: have the script project forward and check for collisions and adjust the horizontal movement of the vehicle accordingly
/// </summary>
public class EnemyMovementUpwards : MonoBehaviour {

    // public variables
    public float moveSpeed;         // the base speed of the enemy
    public float topSpeed;          // the top speed of the enemy
    public float topSlow;           // the slowest speed of the enemy
    public float speedFactor;       // the rate at which the enemy speeds up or slows down towards top or bottom speed
    private float currentSpeed;     // the current rate of the enemy

    void Start()
    {
        // set the start positon and current speeds
        currentSpeed = moveSpeed;
    }

    void FixedUpdate()
    {
        float horizontalMove = getHorizontalMove();
        float verticalMove = getVerticalMove();

        // move the position of the enemy along the y axis by the current speed
        transform.position = new Vector3(transform.position.x + horizontalMove, transform.position.y + currentSpeed, 0.0f);
    }

    /// <summary>
    /// Calculate the vertical speed to apply to the vehicle
    /// </summary>
    /// <returns></returns>
    float getVerticalMove()
    {
        // check to see if player is pushing against top
        if (Manager.Instance.topped)
        {
            // if we haven't reached top speed yet
            if (currentSpeed < topSpeed)
            {
                // increase the current speed by the speed factor
                currentSpeed -= speedFactor;
            }
        }
        // check to see if player is pushing against bottom
        else if (Manager.Instance.bottomed)
        {
            // if we havne't reached top slow yet
            if (currentSpeed > topSlow)
            {
                // decrease the current speed by the speed factor
                currentSpeed += speedFactor;
            }
        }
        // if the player isn't pushing against either top or bottom
        else
        {
            // if the current speed is faster or slower than our default scroll speed, adjust accordingly
            if (currentSpeed > moveSpeed)
            {
                currentSpeed += speedFactor;
            }
            else if (currentSpeed < moveSpeed)
            {
                currentSpeed -= speedFactor;
            }
        }

        return currentSpeed;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    float getHorizontalMove()
    {
        return 0.0F;
    }
}
