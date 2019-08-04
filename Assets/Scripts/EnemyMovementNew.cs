using UnityEngine;
using System.Collections;

/// <summary>
/// EnemyMovement Script
/// NOTE: currently this script only moves the enemy along the Y axis.
/// </summary>
public class EnemyMovementNew : MonoBehaviour {

    // public variables
    public float moveSpeed;         // the base speed of the enemy
    public float startingSpeed;

    public Rigidbody enemyRigidbody;
    void Start()
    {
        enemyRigidbody.velocity = (new Vector3(0.0f, startingSpeed, 0.0f));
    }

    void FixedUpdate()
    {
        enemyRigidbody.AddRelativeForce(new Vector3(0.0f, moveSpeed, 0.0f));
    }
}
