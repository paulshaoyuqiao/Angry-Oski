using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    //Oski Prefab that will be spawned
    public GameObject oskiPrefab;
    public MovementChecker movementChecker;

    //Checks if there is an Oski in the Trigger Area
    bool present = false;

    private void FixedUpdate(){
        //If the Oski is no longer within the trigger area, time to spawn the next Oski!
        if(!present && !movementChecker.moving){
            spawnNext();
        }
    }

    void spawnNext(){
        Instantiate(oskiPrefab, transform.position, Quaternion.identity);
        present = true;
    }

    bool sceneMoving(){
        //Inspect all current Rigidbodies and check if any of them is still having significant movement
        Rigidbody2D[] bodies = FindObjectsOfType(typeof(Rigidbody2D)) as Rigidbody2D[];
        foreach (Rigidbody2D rb in bodies){
            if (rb.velocity.sqrMagnitude > 5){
                return true;
            }
        }
        return false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            present = false;
        }
        collision.tag = "Projectile";
    }
}
