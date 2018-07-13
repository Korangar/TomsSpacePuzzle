using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedRelativeCameraDistanceBehaviour : MonoBehaviour {

    private const float hPi = Mathf.PI / 2;

    public float speedDivisor = 5f;
    public float minAngle = 45;
    public float maxAngle = 90;

    [Header("Damping")]
    public float smoothTime = 1f;
    public float maxSpeed = 1f;
    private float dampingVelocity = 0f;


    private Camera myCamera;
    private Rigidbody2D playerRigidbody;

    // Use this for initialization
    void Start () {
        myCamera = GetComponent<Camera>();
        playerRigidbody = GetComponentInParent<Rigidbody2D>();	
	}
	
	void Update () {
        float variableAngle = (maxAngle - minAngle) * Mathf.Atan(playerRigidbody.velocity.magnitude / speedDivisor) / hPi;
        float currentAngle = Mathf.SmoothDamp(myCamera.fieldOfView, minAngle + variableAngle, ref dampingVelocity, smoothTime, maxSpeed);
        myCamera.fieldOfView = currentAngle;
    }
}
