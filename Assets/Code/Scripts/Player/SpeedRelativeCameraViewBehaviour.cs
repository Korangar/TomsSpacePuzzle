using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SpeedRelativeCameraViewBehaviour : MonoBehaviour {

    private const float hPi = Mathf.PI / 2;

    public Rigidbody2D playerRigidbody;

    [Header("Aim Inclination")]
    public float speedScaling_Aim = 1f;
    public float maxLookAhead = 1f;

    [Header("Field of View Angle")]
    public float speedScaling_Fov = 5f;
    public float minAngle = 45;
    public float maxAngle = 90;

    [Header("Damping")]
    public float smoothTime = 1f;
    public float maxSpeed = 1f;

    private Camera myCamera;
    private AimConstraint myAim;
    private float dampingVelocity = 0f;

    // Use this for initialization
    void Start () {
        myCamera = GetComponent<Camera>();
        myAim = GetComponent<AimConstraint>();
        myAim.enabled = true;
        if (!playerRigidbody) playerRigidbody = GetComponentInParent<Rigidbody2D>();	
	}
	
	void Update () {
        float flightVelocity = playerRigidbody.velocity.magnitude;
        Vector3 flightDirection = playerRigidbody.velocity.normalized;

        float variableAngle = (maxAngle - minAngle) * Mathf.Atan(flightVelocity / speedScaling_Fov) / hPi;
        float currentAngle = Mathf.SmoothDamp(myCamera.fieldOfView, minAngle + variableAngle, ref dampingVelocity, smoothTime, maxSpeed);
        myCamera.fieldOfView = currentAngle;

        float variableInclination = maxLookAhead * Mathf.Atan(flightVelocity / speedScaling_Aim) / hPi ;
        myAim.aimVector = Vector3.forward + -flightDirection * variableInclination;
    }
}
