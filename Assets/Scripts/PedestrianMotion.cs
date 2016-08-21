using UnityEngine;
using System.Collections;

public class PedestrianMotion : MonoBehaviour {

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalMoveFactor;

        if(Manager.Instance.player.position.x - this.transform.position.x < -1)
        {
            horizontalMoveFactor = -0.5F;
        }
        else if(Manager.Instance.player.position.x - this.transform.position.x > 1)
        {
            horizontalMoveFactor = 0.5F;
        }else
        {
            horizontalMoveFactor = 0;
        }

        // move the position of the enemy along the y axis by the current speed
        transform.position = new Vector3(transform.position.x + horizontalMoveFactor, transform.position.y - (WorldSpeed.Instance.currentWorldSpeed - 0.1F), 0.0F);
    }
}
