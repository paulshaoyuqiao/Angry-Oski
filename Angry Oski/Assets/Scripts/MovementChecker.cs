using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementChecker : MonoBehaviour {

    static public HashSet<MovementCheckerChild> bodyChildren;
    public float velocityLimit = 2.23f;

    [HideInInspector]
    public bool moving = false;

    private void OnEnable()
    {
        bodyChildren = new HashSet<MovementCheckerChild>();
    }

    void FixedUpdate () {
        foreach (MovementCheckerChild c in bodyChildren){
            if (c.GetComponent<Rigidbody2D>().velocity.sqrMagnitude > velocityLimit*velocityLimit){
                moving = true;
                return;
            }
        }
        moving = false;
	}
}
