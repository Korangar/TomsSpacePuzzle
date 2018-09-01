using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToolSlotBehaviour : MonoBehaviour {

    Collider2D toolSlotDockingArea;
    private Transform closestDockingPoint;
    private float closestDistance;

    private void OnEnable()
    {
        InvokeRepeating("UpdateClosestDockingPoint", 0, 0.5f);         
    }

    private void OnDisable()
    {
        CancelInvoke("UpdateClosestDockingPoint");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        float distance = Vector3.Distance(collision.transform.position, transform.position);
        if (!(closestDockingPoint && (distance < closestDistance)))
        {
            closestDockingPoint = collision.transform;
            closestDistance = distance;
        }

    }

    private void Update()
    {
        if (closestDockingPoint) {
            Debug.DrawLine(closestDockingPoint.position, transform.position, Color.green);
        }
    }
}
