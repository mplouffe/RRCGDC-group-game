using UnityEngine;
using System.Collections;

/// <summary>
/// The movement script for the suicidal pedestrians. They home in on the player.
/// </summary>
public class PedestrianMotion : MonoBehaviour {

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalMoveFactor;

        // check which side to approach towards player.
        if(Manager.Instance.player.position.x - this.transform.position.x < -1)
        {
            horizontalMoveFactor = -0.55F;
        }
        else if(Manager.Instance.player.position.x - this.transform.position.x > 1)
        {
            horizontalMoveFactor = 0.55F;
        }else
        {
            horizontalMoveFactor = 0;
        }

        // move the position of the enemy along the y axis by the current speed
        transform.position = new Vector3(transform.position.x + horizontalMoveFactor, transform.position.y - (WorldSpeed.Instance.currentWorldSpeed - 0.1F), 0.0F);
    }
}
