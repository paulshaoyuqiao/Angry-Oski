using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCheckerChild : MonoBehaviour {

    private void Start()
    {
        if (!MovementChecker.bodyChildren.Contains(this))
        {
            MovementChecker.bodyChildren.Add(this);
        }
    }
    
    private void OnDestroy()
    {
        MovementChecker.bodyChildren.Remove(this);
    }
}
