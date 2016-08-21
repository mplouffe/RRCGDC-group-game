using UnityEngine;
using System.Collections;

public class FoliageMovement : MonoBehaviour {
	
	// Update is called once per frame
	void FixedUpdate () {
        // move the position of the enemy along the y axis by the current speed
        transform.position = new Vector3(transform.position.x, transform.position.y - WorldSpeed.Instance.currentWorldSpeed, 0.0f);
    }
}
