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
}
