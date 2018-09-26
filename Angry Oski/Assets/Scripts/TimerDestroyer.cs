using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDestroyer : MonoBehaviour {

    public float timer = 10f;

	void Start () {
        Invoke("KillMe", timer);
	}
	
    void KillMe(){
        Destroy(this.gameObject);
    }
}
