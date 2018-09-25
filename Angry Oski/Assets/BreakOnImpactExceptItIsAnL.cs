using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOnImpactExceptItIsAnL : MonoBehaviour {

    public float minimumForce = 1000;

    float collisionForce(Collision2D coll)
    {
        //Estimate the force of collision 
        float speed = coll.relativeVelocity.sqrMagnitude;
        if (coll.collider.GetComponent<Rigidbody2D>())
        {
            return speed * coll.collider.GetComponent<Rigidbody2D>().mass;
        }
        return speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collisionForce(collision) >= minimumForce)
        {
            Destroy(gameObject);
        }
    }
}
