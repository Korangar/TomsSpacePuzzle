﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetThrustBehaviour : MonoBehaviour {

    public float thrusterStrength = 0.5f;
    public Color thrustEnabledColor = Color.red;

    Rigidbody2D playerRigidbody;
    SpriteRenderer thrusterSprite;
    Color memorizedColor;

    void Start () {
        playerRigidbody = GetComponentInParent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 thrusterPosition = transform.position;
        Vector2 thrusterForce = transform.up * thrusterStrength;
        playerRigidbody.AddForceAtPosition(thrusterForce, thrusterPosition);
	}

    private void OnEnable()
    {
        if (!thrusterSprite) thrusterSprite = GetComponent<SpriteRenderer>();
        memorizedColor = thrusterSprite.color;
        thrusterSprite.color = thrustEnabledColor;
    }

    private void OnDisable()
    {
        thrusterSprite.color = memorizedColor;
    }
}
