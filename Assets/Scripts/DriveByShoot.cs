using UnityEngine;
using System.Collections;

public class DriveByShoot : MonoBehaviour {

    public GameObject shot;                 // the shot that the will be generated
    public Transform target;                // a reference to the player for targeting purposes

    /* NOTE: I designed this script for a double barreled turret
             hence why there are two shot spawn transforms to spawn the two bullets
    */
    public Transform shotSpawnLeft;         // the left hand shot spawner
    public Transform shotSpawnRight;        // the right hand shot spawner

    public float fireRate = 0.1F;           // the rate at which the turret will fire
    public float nextFire = 0.0F;           // used to calculate when the turret should fire next


    void Start()
    {
        // if the player is alive
        if (Manager.Instance.playerIsAlive)
        {
            // get a reference to the player's transform and set it as the target
            target = Manager.Instance.player;
        }
    }

    // each Update, check if the turret should be firing
    void Update()
    {

        // if the current time has passed the nextFire time, and the playerIsAlive
        // NOTE: have the turrets checking if the player is alive because there is no game over script
        // currently, hence if the player dies the turrets just keep shooting at nothing
        if (Time.time > nextFire && Manager.Instance.playerIsAlive && checkRange(14))
        {
            // set the time the turret can shoot next
            nextFire = Time.time + fireRate;

            // fire a shot from each turret barrel
            GameObject enemyRightShot = Instantiate(shot, shotSpawnRight.position, shotSpawnRight.rotation) as GameObject;
        }
        else if(Time.time > nextFire && Manager.Instance.playerIsAlive && checkRange(-14))
        {
            nextFire = Time.time + fireRate;
            GameObject leftRightShot = Instantiate(shot, shotSpawnLeft.position, shotSpawnLeft.rotation) as GameObject;
        }
    }

    /// <summary>
    /// Calculate's if the Player car is in the target window of the cop car for a drive by
    /// This code basically usesa formula to calculate a triangle off of each side of the cop car to the edge of the road,
    /// then uses a formula to calculate if the target is in that triangle
    /// if the target is in the triangle, the shots are fired
    /// </summary>
    /// <returns></returns>
    bool checkRange(float xOfRoadEdge)
    {
        float oppEdge = Mathf.Tan(50) * Mathf.Abs(xOfRoadEdge - this.transform.position.x);

        float x1 = this.transform.position.x;
        float y1 = this.transform.position.y;

        float x2 = xOfRoadEdge;
        float y2 = this.transform.position.y + oppEdge;

        float x3 = xOfRoadEdge;
        float y3 = this.transform.position.y - oppEdge;

        float a = ((y2 - y3) * (target.position.x - x3) + (x3 - x2) * (target.position.y - y3)) / ((y2 - y3) * (x1 - x3) + (x3 - x2) * (y1 - y3));
        float b = ((y3 - y1) * (target.position.x - x3) + (x1 - x3) * (target.position.y - y3)) / ((y2 - y3) * (x1 - x3) + (x3 - x2) * (y1 - y3));
        float c = 1 - a - b;

        return (0 <= a && a <= 1 && 0 <= b && b <= 1 && 0 <= c && c <= 1);
    }
}
