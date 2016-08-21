using UnityEngine;
using System.Collections;

public class Troubleshooting : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " Entered");
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name + " Exited");
    }

    void Update()
    {
        if (Input.GetButton("Fire1"));
        {
            Debug.Log("X :" + this.transform.position.x);
            Debug.Log("Y :" + this.transform.position.y);
        }
    }
}
