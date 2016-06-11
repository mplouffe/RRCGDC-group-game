using UnityEngine;
using System.Collections;

public class Rotational : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(0.0F, 0.0F, Mathf.PingPong(Time.deltaTime * 1000, 500F));
	}
}
