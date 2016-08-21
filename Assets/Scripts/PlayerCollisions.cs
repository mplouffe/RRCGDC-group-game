using UnityEngine;
using System.Collections;

public class PlayerCollisions : MonoBehaviour {

    public Collider playerCollider;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            this.GetComponentInChildren<PlayerHealth>().TakeDamage(1);
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (transform.position.y < -16)
            {
                if (transform.position.y < collision.transform.position.y)
                {
                    collision.gameObject.GetComponent<Death>().Die();
                    this.GetComponentInChildren<PlayerHealth>().Die();
                }
            }
        }
    }
}
