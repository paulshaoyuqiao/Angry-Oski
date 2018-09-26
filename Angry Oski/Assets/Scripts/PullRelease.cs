using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullRelease : MonoBehaviour {

    //The Default Position
    Vector2 startPos;

    //The Default Force Added to Oski upon its Release
    public float force = 100;
    public float destroyAfter = 15f;

    //Initialization of the Position
    private void Start()
    {
        startPos = transform.position;
    }

    private void OnMouseUp()
    {
        //Disable the isKinematic Attribute, so now oski will be affected by gravity and drag
        GetComponent<Rigidbody2D>().isKinematic = false;

        //Apply the Force
        Vector2 dir = -(Vector2)transform.position + startPos;
        GetComponent<Rigidbody2D>().AddForce(dir * force);

        // Add oski count in game maneger
        GameManager.oskiCount += 1;

        // Destroy this object after setted seconds
        TimerDestroyer destroyer = gameObject.AddComponent<TimerDestroyer>();
        destroyer.timer = destroyAfter;

        //Remove the Script's Effect
        Destroy(this);

    }

    private void OnMouseDrag()
    {
        //Convert the mouse position to the world position in the game
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Maintain the drag radius 
        float radius = 3.5f;
        Vector2 dir = pos - startPos;
        if (dir.sqrMagnitude > radius){
            dir = dir.normalized * radius;
        }

        //Set the position
        transform.position = startPos + dir;

    }
}
