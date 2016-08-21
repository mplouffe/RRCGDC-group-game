using UnityEngine;
using System.Collections;

public class CamRot : MonoBehaviour {

    float rotateSpeed, zTarget;
    bool turning, clockwise;

	// Use this for initialization
    // right now just making an initial call of changeCameraAngle for testing purposes
	void Start () {
	}

    /// <summary>
    /// Update()
    /// uses the turning and clockwise flags to check if the camera should be turning
    /// if yes, rotates it by the rotation speed around the z axis towards the zTarget (zTarget is set by the changeCameraAngle method
    /// if the camera has moved far enough, turning and clockwise are turned off
    /// </summary>
    void Update()
    {
        if(turning && clockwise)
        {
            if (this.transform.rotation.z < zTarget)
            {
                this.transform.Rotate(Vector3.forward, rotateSpeed);
            }
            else
            {
                turning = false;
                clockwise = false;
            }
        }

        else if(turning && !clockwise)
        {
            if(this.transform.rotation.z > zTarget)
            {
                this.transform.Rotate(Vector3.forward, -rotateSpeed);
            }else
            {
                turning = false;
                clockwise = false;
            }
        }
    }

    /// <summary>
    /// changeCameraAngle()
    /// Sets the target and speed for the turn based on the parameters passed in. There is no checking for values passed in so you use at it your own risk.
    /// Suggested values are in this comment section.
    /// </summary>
    /// <param name="amountToRotate">Positive for clockwise, negative counter clockwise, use numbers between 1 and 0 (smaller better)</param>
    /// <param name="rotateSpeed">How much turn per update frame. Smaller for smoother turns. (like 0.3)</param>
    public void changeCameraAngle(float amountToRotate, float rotateSpeed)
    {
        turning = true;
        clockwise = amountToRotate > 0;
        zTarget = transform.rotation.z + amountToRotate;
        this.rotateSpeed = rotateSpeed;
    }
}
