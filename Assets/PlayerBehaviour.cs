﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Joystick joystick;
    public float joystickSensitivity;
    public float horizontalForce;
    public float jumpForce;
    public float maximumVelocityX;
    public Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this._Move();
    }

    private void _Move()
    {
        if (joystick.Horizontal > joystickSensitivity)
        {
            // move to the right
            rigidbody2D.AddForce(Vector2.right * horizontalForce * Time.deltaTime);
            Debug.Log("move Right");
        }
        if (joystick.Horizontal < -joystickSensitivity)
        {
            // move to the left
            rigidbody2D.AddForce(Vector2.left * horizontalForce * Time.deltaTime);
            Debug.Log("move Left");
        }
    }
}
