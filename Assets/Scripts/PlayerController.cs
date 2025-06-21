using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float tourqueAmount = 1f;
    [SerializeField] float boostSpeed = 20f;
    [SerializeField] float slowSpeed = 10f;
    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        RespondToBoost();
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            surfaceEffector2D.speed = slowSpeed;
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(tourqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-tourqueAmount);
        }
    }
}
