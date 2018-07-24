using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetThrustBehaviour : MonoBehaviour
{
    public float thrusterStrength = 0.5f;

    private Rigidbody2D playerRigidbody;
    private ParticleSystem thrusterParticles;
    private Animator thrusterAnimator;

    void Awake ()
    {
        playerRigidbody = GetComponentInParent<Rigidbody2D>();
        thrusterAnimator = GetComponentInChildren<Animator>();
        thrusterParticles = GetComponentInChildren<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 thrusterPosition = transform.position;
        Vector2 thrusterForce = transform.up * thrusterStrength;
        playerRigidbody.AddForceAtPosition(thrusterForce, thrusterPosition);
	}

    private void OnEnable()
    {
        thrusterAnimator.SetBool("enabled", true);
        thrusterParticles.Play();
    }

    private void OnDisable()
    {
        thrusterAnimator.SetBool("enabled", false);
        thrusterParticles.Stop();
    }
}
