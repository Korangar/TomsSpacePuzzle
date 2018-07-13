using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityRelativeLookDirection : MonoBehaviour {

    private Animator myAnimator;
    private Rigidbody2D playerRigidbody;

	// Use this for initialization
	void Start () {
        playerRigidbody = GetComponentInParent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 velocity = transform.worldToLocalMatrix * playerRigidbody.velocity;
        myAnimator.SetFloat("velocity_X", velocity.x);
        myAnimator.SetFloat("velocity_Y", velocity.y);
	}
}
