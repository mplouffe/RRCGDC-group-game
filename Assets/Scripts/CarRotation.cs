using UnityEngine;
using System.Collections;

public class CarRotation : MonoBehaviour {

    public float rotate;

	// Update is called once per frame
	void FixedUpdate () {


        // rotate the player along the z axis based on the horizontal speed of the player * the rotation value
        GetComponent<Transform>().rotation = Quaternion.Euler(0.0f, 0.0f, (GetComponentInParent<Rigidbody>().velocity.x * -rotate));

    }
}
