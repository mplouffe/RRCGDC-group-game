using UnityEngine;
using System.Collections;

public class CarRotation : MonoBehaviour {

    public float rotate;

	// Update is called once per frame
	void FixedUpdate () {


        // rotate the player along the z axis based on the horizontal speed of the player * the rotation value
        // NOTE: the "+ 270" is a hack that I'm using because my player sprite is default facing the left
        // with a properly oriented sprite, this would not be necessary
        GetComponent<Transform>().rotation = Quaternion.Euler(0.0f, 0.0f, (GetComponentInParent<Rigidbody>().velocity.x * -rotate) + 270);

    }
}
