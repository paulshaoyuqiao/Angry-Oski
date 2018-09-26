using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioAdjuster : MonoBehaviour {

    /// <summary>
    /// The sfx BUG fixer.
    /// </summary>

    public AudioMixerGroup sfxGroup;
	void Start () {
        sfxGroup.audioMixer.SetFloat("sfxVol", -80f);
        Invoke("SetVol", 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetVol(){
        sfxGroup.audioMixer.SetFloat("sfxVol", 0f);
    }
}
