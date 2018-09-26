using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOnImpact : MonoBehaviour {

    public int initialHP = 100;
    public float ignoreImpactUnder = 3f;
    public int score = 10000;
    public AudioClip hitSFX;
    public AudioClip destroySFX;

    [Header("Will defalutly find AudioSource on this object.")]
    public AudioSource audioSource;

    private int currentHP;
    private Vector2 lastMomentum;
    private Rigidbody2D rb;

    private void Start()
    {
        currentHP = initialHP;
        rb = GetComponent<Rigidbody2D>();
        if (!audioSource)
        {
            audioSource = GetComponent<AudioSource>();
        }
        lastMomentum = rb.velocity * rb.mass;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 momentum = rb.velocity * rb.mass;
        float impactMag = (momentum - lastMomentum).magnitude;
        if (impactMag >= ignoreImpactUnder){
            HitBy(impactMag);
        }
        Debug.Log(impactMag.ToString()+" "+currentHP.ToString());
    }

    private void FixedUpdate()
    {
        if (currentHP <= 0)
        {
            DieForNetImpact();
        }
        lastMomentum = rb.velocity * rb.mass;
    }

    private void HitBy(float impactMag){
        currentHP -= (int)impactMag;
        if (audioSource && !audioSource.isPlaying) {
            float impactVolum = Mathf.Clamp(impactMag, 0f, 10f)/10f;
            audioSource.clip = hitSFX;
            audioSource.volume = impactVolum;
            audioSource.Play();
        }
    }

    private void DieForNetImpact()
    {
        GameManager.score += score;
        if (audioSource)
        {
            GameObject audioContainerObejct = new GameObject("dieAudioContainerObejct");
            AudioSource audioContainer = audioContainerObejct.AddComponent<AudioSource>();
            audioContainer.outputAudioMixerGroup = audioSource.outputAudioMixerGroup;
            audioContainer.clip = destroySFX;
            audioContainer.Play();
            audioContainer.loop = false;
            audioContainerObejct.AddComponent<TimerDestroyer>();
        }
        // Add animation here
        Destroy(this.gameObject);
    }
}
