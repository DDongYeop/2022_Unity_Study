using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TankMover : MonoBehaviour
{
    public TankMovementData movementData;

    private Rigidbody2D rigidbody2D;
    private Vector2 movementVector;
    private float currentSpeed = 0;
    private float currentForewardDirection = 1;

    public UnityEvent<float> EngineSound = new UnityEvent<float>();

    private void Awake()
    {
        rigidbody2D = GetComponentInParent<Rigidbody2D>();
    }

    public void Move(Vector2 movementVector)
    {
        this.movementVector = movementVector;
        CalculateSpeed(movementVector);
        if (movementVector.y > 0)
        {
            currentForewardDirection = 1;
        }
        else if(movementVector.y < 0)
        {
            currentForewardDirection = -1;
        }
        EngineSound?.Invoke(this.movementVector.magnitude);
    }

    private void CalculateSpeed(Vector2 movementVector)
    {
        if (Mathf.Abs(movementVector.y) > 0)
        {
            currentSpeed += movementData.acceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed -= movementData.deacceleration * Time.deltaTime;
        }

        currentSpeed=Mathf.Clamp(currentSpeed,0, movementData.maxSpeed);
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = (Vector2)transform.up * currentSpeed * currentForewardDirection * Time.fixedDeltaTime;
        rigidbody2D.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * movementData.rotationSpeed * Time.fixedDeltaTime));
    }
}
