using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ButtonSFX : MonoBehaviour {

    public AudioClip buttonUpSFX;
    public AudioClip buttonDownSFX;
    public AudioSource sfxSource;

    public void PlayButtonUpSFX(){
        sfxSource.clip = buttonUpSFX;
        sfxSource.Play();
    }

    public void PlayButtonDownSFX()
    {
        sfxSource.clip = buttonDownSFX;
        sfxSource.Play();
    }
}
