using UnityEngine;
using System.Collections;

/// <summary>
/// Idea is to have this control the camera and have it gradually rotate it after an interval so the game changes angle on occasion
/// THIS DRAFT DOES NOT WORK!
/// Need to implement Jerry's CoRoutine based solution
/// </summary>
public class CameraRotation : MonoBehaviour {

    public float timeUntilTurn;

    public float turnTime;
    public float turnDegreeMin;
    public float turnDegreeMax;

    float turnNow;
    bool turningCamera = false;
    float cameraRotationTurns = 0;

    void Start()
    {
        turnNow = Time.time + timeUntilTurn;
    }

	// Update is called once per frame
	void Update () {

        // Debug.Log("Time.time : " + Time.time);
        // Debug.Log("turnNow : " + turnNow);

        if(Time.time >= turnNow && !turningCamera)
        {
            Debug.Log("Calling Turn Now");
            turningCamera = true;
            cameraRotationTurns = 5;

            Debug.Log("newCameraAngle: " + cameraRotationTurns);
        }

        if(turningCamera)
        {
            Vector3 diff = new Vector3(this.transform.position.x + 0.01F, this.transform.position.y + 0.01F, this.transform.position.z) - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            cameraRotationTurns--;

            Debug.Log("CameraRotationTurns: " + cameraRotationTurns);
            if (cameraRotationTurns <= 0)
            {
                Debug.Log("Finished Turning");
                turningCamera = false;
                turnNow = Time.time + timeUntilTurn;
            }
        }
	}
}
