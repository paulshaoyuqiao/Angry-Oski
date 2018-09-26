using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubberAction : MonoBehaviour {

    //Declaring the Rubber Objects
    public Transform leftRubber;
    public Transform rightRubber;

    void adjustRubber(Transform oski, Transform rubber){

        //Account for Rotation
        Vector2 direction = rubber.position - oski.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rubber.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //Account for Elongation/Shrinking
        float distance = Vector3.Distance(oski.position, rubber.position);
        distance = distance + oski.GetComponent<Collider2D>().bounds.extents.x;
        rubber.localScale = new Vector2(distance/2, 1);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Account for Stretching the Slingshot Rubber
        if (collision.CompareTag("Player"))
        {
            adjustRubber(collision.transform, leftRubber);
            adjustRubber(collision.transform, rightRubber);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Readjust the Rubber 
            leftRubber.localScale = new Vector2(0, 1);
            rightRubber.localScale = new Vector2(0, 1);
    }
}
