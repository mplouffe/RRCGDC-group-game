using UnityEngine;
using System.Collections;

/// <summary>
/// PointAtPlayer Script
/// Script to have the turrets constantly point at the player.
/// 
/// IDEAS: adjust the script so that the turrets are shooting a bit ahead of the player (leading shots)
/// </summary>
public class PointAtPlayer : MonoBehaviour {

    public Transform target;            // referece to the target to be pointing at

    void Start()
    {
        // if the player is alive
        if (Manager.Instance.playerIsAlive)
        {
            // get a reference to the player's transform and set it as the target
            target = Manager.Instance.player;
        }
    }

    void Update()
    {
        // if the player is alive
        if (Manager.Instance.playerIsAlive)
        {
            // point at the player
            // I simply pulled this script from online, so I wouldn't be able to explain the math of it yet.
            // important part is that it will only rotate the cannon along the z axis
            Vector3 diff = target.position - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
    }
}
