using UnityEngine;
using System.Collections;

/// <summary>
/// This was an attempt to try and get the particle system that is spawning the flames comming off the pedestrian to generate in the proper direction
/// Cannot remember if I got this working properly or not, but the script is attached to the pedestrian object, so I've left this script in the project
/// </summary>
public class FireDirection : MonoBehaviour {

    public Transform gameObjectTransform;
    public ParticleSystem flames;

    void Start()
    {
        flames = this.GetComponent<ParticleSystem>();
    }

	void FixedUpdate () {
        flames.startRotation = gameObjectTransform.rotation.z;
	}
}
